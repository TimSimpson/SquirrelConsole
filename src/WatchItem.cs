using System;
using System.Collections.Generic;
using System.Text;

namespace DebugConsole
{
    public class WatchItem
    {
        private string name;
        private string value;

        public WatchItem(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name
        {
            get { return name; }
        }
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
