using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        [DllImport("user32", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, int lParam);

        string msgTitle { get; set; }

        public Form1()
        {
            InitializeComponent();

            
            msgTitle = "测试";
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(closeWindow);
            timer1.Tick += new EventHandler(showMessagebox);
            timer1.Interval = 1000;
            timer1.Enabled = true;
            
        }
        private void showMessagebox(object sender,EventArgs e)
        {
            Console.WriteLine("已经弹出一个");
            MessageBox.Show("", "测试", MessageBoxButtons.OKCancel);
           
        }
        

        private void closeWindow(object sender, EventArgs e)
        {
            //int inthwnd = int.Parse(msgTitle);
            //IntPtr hwnd = new IntPtr(inthwnd);
            IntPtr hWnd = FindWindow(null, "测试");
            IntPtr childHwnd = FindWindowEx(hWnd, IntPtr.Zero, null, "确定");
            if (childHwnd != IntPtr.Zero)
            {
                //模拟点击 是(&Y)
                SendMessage(childHwnd, 0xF5 , IntPtr.Zero, 0);
                Console.WriteLine("已经关闭一个");
            }

        }
    }
}
