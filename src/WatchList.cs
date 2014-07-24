using System;
using System.Collections.Generic;
using System.Text;

namespace DebugConsole
{
    class WatchList
    {
        System.Collections.Hashtable table = new System.Collections.Hashtable();

        public void Update(string name, string value)
        {
            if (!table.Contains(name))
            {
                table.Add(name, value);
            }
            else
            {
                table[name] = value;
            }
        }
    }
}
