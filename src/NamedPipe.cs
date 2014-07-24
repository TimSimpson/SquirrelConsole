using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace DebugConsole
{

    class NamedPipe
    {
        [StructLayout(LayoutKind.Sequential)]
        class SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateNamedPipe(string lpName, uint dwOpenMode,
           uint dwPipeMode, uint nMaxInstances, uint nOutBufferSize, uint nInBufferSize,
           uint nDefaultTimeOut, IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateNamedPipe(string lpName, uint dwOpenMode,
           uint dwPipeMode, uint nMaxInstances, uint nOutBufferSize, uint nInBufferSize,
           uint nDefaultTimeOut, SECURITY_ATTRIBUTES lpSecurityAttributes);

        [DllImport("coredll.dll", SetLastError=true)]
        static extern Int32 GetLastError();

        [DllImport("kernel32.dll")]
        static extern bool ConnectNamedPipe(IntPtr hNamedPipe,
           [In] ref System.Threading.NativeOverlapped lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        static extern bool ReadFile(IntPtr hFile, byte[] lpBuffer,
           uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

        [Flags]
        private enum pipeFlags : uint
        {
            PIPE_ACCESS_DUPLEX = 0x00000003,
            PIPE_ACCESS_INBOUND = 0x00000001,
            PIPE_ACCESS_OUTBOUND = 0x00000002,
            PIPE_TYPE_BYTE = 0x00000000,
            PIPE_TYPE_MESSAGE = 0x00000004,
            PIPE_READMODE_BYTE = 0x00000000,
            PIPE_READMODE_MESSAGE = 0x00000002,
            FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,
            FILE_FLAG_WRITE_THROUGH = 0x80000000,
            FILE_FLAG_OVERLAPPED = 0x40000000,
            PIPE_WAIT = 0x00000000,
            PIPE_NOWAIT = 0x00000001,
            NMPWAIT_NOWAIT = 0x00000001,
            NMPWAIT_WAIT_FOREVER = 0xffffffff,
            NMPWAIT_USE_DEFAULT_WAIT = 0x00000000,
            //INVALID_HANDLE_VALUE = -1,
            ERROR_PIPE_CONNECTED = 535,
        }

        const int BUFFERSIZE = 4096;
        bool connected;
        IntPtr pipeHandle;
        byte[] buffer = new byte[BUFFERSIZE];

        /// <summary>
        ///  Because the read operation doesn't just stop at the end of a string, we
        /// read in lots of bits, make one big string, then cut it into little strings
        /// based on the null terminator ('\0').  Then we put them in a queue and the
        /// next message function just pulls from that queue.  When its empty we read
        /// from the pipe again and repeat.
        /// </summary>
        System.Collections.Generic.Queue<string> pendingMessages;

        /// <summary>
        /// This is what's "left over" from any previous string that we got from the read pipe command.
        /// This is because sometimes the pipe will just chop off awkard blocks, even if its in between
        /// messages (DAMN YOU PIPE!!)  It gets prepended to the next bit of characters read in.
        /// </summary>
        string leftOver;

        private static SECURITY_ATTRIBUTES getNullDacl()
        {
            // Build NULL DACL (Allow everyone full access)
            RawSecurityDescriptor gsd = new RawSecurityDescriptor(ControlFlags.DiscretionaryAclPresent, null, null, null, null);

            // Construct SECURITY_ATTRIBUTES structure
            SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
            sa.nLength = Marshal.SizeOf(typeof(SECURITY_ATTRIBUTES));
            sa.bInheritHandle = 1;

            // Get binary form of the security descriptor and copy it into place
            byte[] desc = new byte[gsd.BinaryLength];
            gsd.GetBinaryForm(desc, 0);
            sa.lpSecurityDescriptor = Marshal.AllocHGlobal(desc.Length); // This Alloc is Freed by the Disposer or Finalizer
            Marshal.Copy(desc, 0, sa.lpSecurityDescriptor, desc.Length);

            return sa;
        }


        public NamedPipe(string path)
        {
            connected = false;

            pipeHandle = CreateNamedPipe(
                path,
                (uint) pipeFlags.PIPE_ACCESS_INBOUND,
                (uint)pipeFlags.PIPE_TYPE_BYTE | (uint) pipeFlags.PIPE_WAIT,
                1,
                (uint) BUFFERSIZE,
                (uint) BUFFERSIZE,
                (uint)pipeFlags.NMPWAIT_WAIT_FOREVER,//.NMPWAIT_USE_DEFAULT_WAIT,
                getNullDacl());
            if (pipeHandle == ((IntPtr)(-1))) //pipeFlags.INVALID_HANDLE_VALUE);
            {
                throw new Exception("Could not create pipe \"" + path + "\".");
            }
            connected = true;
            pendingMessages = new Queue<string>();
            leftOver = "";
        }

        public void Close()
        {
            CloseHandle(pipeHandle);
        }

        private bool readPipe()
        {
            if (!connected)
                return false;
            uint bytesRead = 0;
            bool success;
            success = ReadFile(pipeHandle, buffer, (uint)buffer.Length, out bytesRead, (IntPtr)(null));
            if (!success || bytesRead <= 0)
            {
                return false;
            }
            char[] chars = System.Text.ASCIIEncoding.ASCII.GetChars(buffer, 0, (int)bytesRead);
            // Split this char into the several messages the client meant to sent, but can't.
            string big = leftOver + new string(chars);
            string[] dif = big.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            int endAt = dif.Length;
            if (!big.EndsWith("\0"))
            {
                endAt--;
                leftOver = dif[endAt];
                // CHANGE OF GAME PLAN, gentlemen.
                // It seems that the dangling bit in leftOver isn't followed by anything
                // useful - as in the missing piece - its like the pipe just stops sending
                // the message half way through and then never ever sends it.
                // So instead just throw leftOver away, the poor wretch that it is ... :'(
                leftOver = "";
            }
            for (int i = 0;  i < endAt; i ++)
            {
                if (dif[i].Length >= 2 && dif[i][0] == dif[i][dif[i].Length - 1])
                {
                    pendingMessages.Enqueue(dif[i].Substring(1, dif[i].Length - 2));
                }
            }
            return true;
        }

        public string GetNextMessage()
        {
            while (pendingMessages.Count < 1 )
            {
                if (!readPipe())
                {
                    return null;
                }
            }
            return pendingMessages.Dequeue();
        }

        public bool WaitForConnection()
        {
            if (!connected)
                return false;
            System.Threading.NativeOverlapped nol = new System.Threading.NativeOverlapped();
            if (!ConnectNamedPipe(pipeHandle, ref nol) &&
                GetLastError() != (int) pipeFlags.ERROR_PIPE_CONNECTED)
            {
                return false;
            }
            return true;
        }

    }
}
