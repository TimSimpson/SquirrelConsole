using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DebugConsole
{
    public partial class WatchGrid : UserControl
    {
        public WatchGrid()
        {
            InitializeComponent();
            this.dataGridView1.Columns.Add("ClName", "Name");
            this.dataGridView1.Columns.Add("ClValue", "Value");
        }

        public void Update(string name, string value)
        {
            /*if (!this.dataGridView1.Columns.Contains(name))
            {
                this.dataGridView1.Columns.Add(name, name);
            }
            this.dataGridView1.Rows*/
        }
    }
}
