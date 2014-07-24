using System;
using System.Collections.Generic;
using System.Text;

namespace DebugConsole
{
public class Paths
{
    public static string DecodaPath
    {
        get
        {
            return @"C:\Program Files\Decoda\Decoda.exe";
        }
    }

    public static string GameExePath
    {
        get
        {
            return @"D:\Lp3Svn\Projects\Lp3\Debug\Lp3.exe";
        }
    }

    public static string GameExeWorkingDir
    {
        get
        {
            return @"D:\Lp3Svn\Projects\Lp3";
        }
    }

    public static string ScriptConfigPath
    {
        get
        {
            return @"D:\Lp3Svn\Projects\Lp3\currentScript.txt";
        }
    }

    public static string TestRootPath
    {
        get
        {
            return @"D:\Lp3Svn\Projects\Lp3\Source\Tests\";
        }
    }
}
}
