using System;
using System.Collections.Generic;
using System.Text;

namespace DebugConsole
{
    interface DebugOutput
    {
        void GameStart();
        void GameFinish();
        void Set(string name, string value);
        void Write(string message);
        void PipeMessage(string message);
    }
}
