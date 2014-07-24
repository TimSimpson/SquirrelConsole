using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DebugConsole
{
    public partial class DebugConsole : Form, DebugOutput
    {
        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
            int msg, int wParam, int lParam);
        private const int EM_LINESCROLL = 0x00B6;

        private DataTable memoryTable;
        private DataTable watchTable;

        public static void ScrollRichTextBoxToBottom(IntPtr richTextBoxHWnd, int lines)
        {
            SendMessage(richTextBoxHWnd, EM_LINESCROLL, 0, lines);
        }

        private delegate void SetDelegate(string s1, string s2);
        private delegate void WriteDelegate(string s1);
        private delegate void ChangeStatusDelegate(string s1, System.Drawing.Color col);
        private delegate void BlankParmsDelegate();

        //private TestList testList;

        public DebugConsole()
        {
            InitializeComponent();
            initWatchTable();
            initMemoryTable();

            //testList = new TestList();
            //tpScripts.Controls.Add(testList);
            //testList.Dock = DockStyle.Fill;
            //testList.FillList(Paths.TestRootPath);
            //testList.GoToErrorOut = new TestList.VoidMethod(testRun);
        }

        private void initWatchTable()
        {
            if (InvokeRequired)
            {
                this.Invoke(new BlankParmsDelegate(initWatchTable));
            }
            else
            {

                watchTable = new DataTable("Watch");
                watchTable.Columns.Add("Name", typeof(string));
                watchTable.Columns.Add("Value", typeof(string));
                watchTable.PrimaryKey = new DataColumn[] { watchTable.Columns[0] };

                dgvWatch.DataSource = watchTable;
            }
        }

        private void initMemoryTable()
        {
            if (InvokeRequired)
            {
                this.Invoke(new BlankParmsDelegate(initMemoryTable));
            }
            else
            {

                memoryTable = new DataTable("Memory");
                memoryTable.Columns.Add("Name", typeof(string));
                memoryTable.Columns.Add("Type", typeof(string));
                memoryTable.Columns.Add("Size", typeof(int));
                memoryTable.Columns.Add("Instances", typeof(int));
                memoryTable.PrimaryKey = new DataColumn[] { memoryTable.Columns[0] };

                dgvMemory.DataSource = memoryTable;
            }
        }


        private void changeStatus(string status, System.Drawing.Color color)
        {
            if (InvokeRequired)
            {
                this.Invoke(new ChangeStatusDelegate(changeStatus), new object[] { status, color });
            }
            else
            {
                lblStatus.Text = status;
                lblStatus.ForeColor  = color;
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.rtbOutput.Clear();
        }

        int currentLine = 0;


        public void GameStart()
        {
            if (InvokeRequired)
            {
                this.Invoke(new BlankParmsDelegate(GameStart));
                return;
            }
            changeStatus("Communication in Progress", Color.DarkGreen);
            watchTable.Clear();
            initWatchTable();
            initMemoryTable();
            timer1.Enabled = true;

            if (cbClearOnStart.Checked)
            {
                rtbOutput.Clear();
            }
        }

        public void GameFinish()
        {
            changeStatus("no connection established", Color.DarkRed);
            timer1.Enabled = false;
        }

        public void Set(string name, string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new SetDelegate(Set), new object[] { name, value });
            }
            else
            {
                value = value.TrimEnd(new char[] { '\r', '\n', '\t', ' ' });
                // Check for special values
                if (name.StartsWith("__MEM_"))
                {
                    string[] memParms = value.Split(new char[] { Convert.ToChar((byte)17) }, StringSplitOptions.None);
                    string memName = memParms[0];

                    DataRow memRow = memoryTable.Rows.Find(memName);
                    if (name == "__MEM_MALLOC")
                    {
                        string memSize = memParms[2];
                        if (memRow == null)
                        {
                            memoryTable.Rows.Add(new object[] { memName, "", Convert.ToInt32(memSize), 1 });
                        }
                        else
                        {
                            int wtfCSharp = (int)memRow[3];
                            wtfCSharp++;
                            memRow[3] = wtfCSharp;
                        }
                    }
                    else if (name == "__MEM_FREE")
                    {
                        try
                        {
                            if (((int)memRow[3]) < 1)
                            {
                                memoryTable.Rows.Remove(memRow);
                            }
                            else
                            {
                                int wtfCSharp = (int)memRow[3];
                                wtfCSharp--;
                                memRow[3] = wtfCSharp;
                            }
                        }
                        catch (RowNotInTableException)
                        {

                        }
                    }
                }// end MEM

                else
                {
                    DataRow row = watchTable.Rows.Find(name);
                    if (row == null)
                    {
                        watchTable.Rows.Add(new object[] { name, value });
                    }
                    else
                    {
                        row[1] = value;
                    }
                }
            }
        }

        private void testRun()
        {
            this.tabControlWatch.SelectedIndex = 0;
        }

        public void Write(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new WriteDelegate(Write), new object[] { message });
            }
            else
            {
                currentLine++;
                rtbOutput.AppendText(message);
                if (!this.rtbOutput.Focused)
                {
                    ScrollRichTextBoxToBottom(rtbOutput.Handle, currentLine - ((Int32)(this.Height / this.Font.Height)));
                }
            }
        }

        public void PipeMessage(string message)
        {
        }

        /*double avgFps;
        const int avgNum = 100;
        int currentLine = 0;*/

        AverageNumber avg = new AverageNumber(100);

        string oldFps;
        private void timer1_Tick(object sender, EventArgs e)
        {
            DataRow row = watchTable.Rows.Find("fps");
            if (row == null)
                return;
            string newFps = row[1].ToString();
            if (oldFps == newFps)
            {
                changeStatus("Main thread halted!", Color.DarkGoldenrod);
                this.lblStatus.Visible = !this.lblStatus.Visible;
            }
            else
            {
                changeStatus("Communication in Progress", Color.DarkGreen);
                this.lblStatus.Visible = true;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
