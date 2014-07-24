using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DebugConsole
{
/// <summary>
/// A single scrip test.
/// </summary>
public class Test
{
    private string scriptPath;

    public Test(string filePath)
    {
        scriptPath = filePath;
    }

    /// <summary>
    /// Retrieves a list of script file paths from the file path.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static Test[] GetTestList(string filePath)
    {
        List<Test> list = new List<Test>();
        getTestList(filePath, list);
        return list.ToArray();
    }

    private static void getTestList(string filePath, List<Test> list)
    {
        Console.WriteLine("filePath:" + filePath);
        string[] files = Directory.GetFiles(filePath);
        foreach (string file in files)
        {
            if (file.ToLower().EndsWith(".lua"))
            {
                list.Add(new Test(file));
                Console.WriteLine(file);
            }
        }
        
        string[] dirs = Directory.GetDirectories(filePath);
        foreach (string dir in dirs)
        {
            getTestList(dir, list);
        }
    }

    /// <summary>
    /// Runs a script.
    /// </summary>
    public void RunTest()
    {
        /*Process proc = new Process();
        proc.StartInfo.FileName = Paths.GameExePath;
        proc.StartInfo.Arguments = RelativePath;
        proc.StartInfo.UseShellExecute = true;
        proc.StartInfo.WorkingDirectory = Paths.GameExeWorkingDir;
        proc.Start();
        proc.WaitForExit();*/

        StreamWriter writer = new StreamWriter(Paths.ScriptConfigPath);
        writer.Write(this.RelativePath);
        writer.Close();
    }

    /// <summary>
    /// The path relative to the test directory.
    /// </summary>
    public string RelativePath
    {
        get
        {
            if (scriptPath.ToLower().StartsWith(Paths.TestRootPath.ToLower()))
            {
                return scriptPath.Substring(Paths.TestRootPath.Length);
            }
            return scriptPath;
        }
    }
}
}
