using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DebugConsole
{
public partial class TestList : UserControl
{
    public delegate void VoidMethod();

    public VoidMethod GoToErrorOut;
    private MenuItem menuItemRun;
    private ContextMenu popUp;

    public TestList()
    {
        InitializeComponent();

        this.listView1.Columns.Add(
            "Test Script", 400, HorizontalAlignment.Left);
        listView1.Dock = DockStyle.Fill;

        menuItemRun = new MenuItem("Run", new EventHandler(onMenuRunClick));
        popUp = new ContextMenu();

        this.listView1.ContextMenu = popUp;
    }



    public ListViewItem CreateListItem(Test test)
    {
        ListViewItem item = new ListViewItem(
            new string[] { test.RelativePath }, 0);
        return item;
    }

    public void FillList(string path)
    {
        Test[] tests = Test.GetTestList(path);
        foreach (Test test in tests)
        {
            listView1.Items.Add(CreateListItem(test));
        }
    }

    public void onMenuRunClick(object obj, EventArgs ea)
    {
        runTest();
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            popUp.MenuItems.Clear();
            popUp.MenuItems.Add(menuItemRun);
        }
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        this.listView1.Items.Clear();
        FillList(Paths.TestRootPath);
    }

    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        runTest();
    }

    private void runTest()
    {
        if (listView1.SelectedItems.Count > 0)
        {
            ListViewItem item = listView1.SelectedItems[0];
            Test test = new Test(Paths.TestRootPath + item.SubItems[0].Text);
            test.RunTest();
            GoToErrorOut();
        }
    }
}
}
