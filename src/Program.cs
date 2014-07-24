using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace DebugConsole
{
    static class Program
    {
        static DebugOutput dOutput;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            dOutput = new DebugConsole();
         
            //Application.Run(new Form1());
            Thread windowThread = new Thread(new ThreadStart(RunWindow));
            Thread pipeThread = new Thread(new ThreadStart(RunPipe));
            //windowThread.SetApartmentState(ApartmentState.STA);
            //pipeThread.SetApartmentState(ApartmentState.STA);
            windowThread.Start();
            //pipeThread.Start();
            //while (windowThread.IsAlive)
           // {
            //}
            RunPipe();
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        static void RunWindow()
        {
            ((DebugConsole)dOutput).ShowDialog();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        static void RunPipe()
        {
            NamedPipe pipe;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("~~~~~ Waiting for input...");

                dOutput.PipeMessage("Creating pipe...");
                try
                {
                    pipe = new NamedPipe("\\\\.\\pipe\\LpErrOut");//newPath);
                }
                catch (Exception e)
                {

                    dOutput.PipeMessage(e.Message);
                    MessageBox.Show(e.Message);
                    return;
                }

                dOutput.PipeMessage("Waiting for game to start...");
                if (!pipe.WaitForConnection())
                {
                    MessageBox.Show("Could not establish client connection!");
                    return;
                }

                string message;
                string name, value;
                int i;

                dOutput.PipeMessage("Receiving messages.");
                
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                dOutput.PipeMessage("Began to talk to program at " + System.DateTime.Now);
                Console.WriteLine();
                
                dOutput.GameStart();
                
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;

                while ((message = pipe.GetNextMessage()) != null)
                {
                    // Parse out the new lines.
                    message = message.Replace("^%^", System.Environment.NewLine);
                    /*bool isOnlyWhiteSpace = true;
                    char[] chars = message.ToCharArray();
                    foreach (char c in chars)
                    {
                        if (!Char.IsWhiteSpace(c))
                        {
                            isOnlyWhiteSpace = false;
                            break;
                        }
                    }
                    if (isOnlyWhiteSpace)
                    {
                        message = "";
                        continue;
                    }*/

                    i = message.IndexOf("@");
                    if (i < 0)
                    {
                        name = "";
                        value = message;
                        dOutput.Write(message);
                    }
                    else
                    {
                        name = message.Substring(0, i);
                        value = message.Remove(0, i + 1);
                        dOutput.Set(name, value);
                    }
                    
                    
                   // dConsole.Update(name, value);
       /*             if (name.ToLower() == "color")
                    {
                        value = value.ToLower();
                        if (value == "red")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        if (value == "blue")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        if (value == "white")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        //continue;
                    }
        * */
                    if (name == "")//!= "fps")
                    {
                        message = message.Replace("^%^", System.Environment.NewLine);
                        //Console.Write(message);
                    }
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                dOutput.GameFinish();
                dOutput.PipeMessage("~~~~~ Program finished at " + System.DateTime.Now);
                pipe.Close();
            }
        }

    }
}