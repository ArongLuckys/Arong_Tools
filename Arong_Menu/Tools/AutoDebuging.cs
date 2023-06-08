using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Arong_Core;

namespace Arong_Menu
{
	public partial class AutoDebuging : Skin_DevExpress
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern IntPtr GetForegroundWindow(); //获得当前激活状态下的窗口句柄

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left;                             //最左坐标
			public int Top;                             //最上坐标
			public int Right;                           //最右坐标
			public int Bottom;                        //最下坐标
		}

		[DllImport("user32.dll", EntryPoint = "FindWindow")]
		private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", EntryPoint = "FindWindow")]
		private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		[DllImport("user32.dll")]
		static extern IntPtr GetDC(IntPtr hwnd);

		[DllImport("user32.dll")]
		static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

		[DllImport("gdi32.dll")]
		static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

		/// <summary>
		/// 鼠标
		/// </summary>
		/// <param name="X"></param>
		/// <param name="Y"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		static extern bool SetCursorPos(int X, int Y);

		/// <summary>
		/// 返回颜色值
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		static public Color GetPixelColor(int x, int y)
		{
			IntPtr hdc = GetDC(IntPtr.Zero);
			uint pixel = GetPixel(hdc, x, y);
			ReleaseDC(IntPtr.Zero, hdc);
			Color color = Color.FromArgb((int)(pixel & 0x000000FF),
						 (int)(pixel & 0x0000FF00) >> 8,
						 (int)(pixel & 0x00FF0000) >> 16);
			return color;
		}












		public AutoDebuging()
		{
			InitializeComponent();
			//显示用户设置的背景色
			this.BackColor = Arong_Menu.Properties.Settings.Default.Tools_color;
		}

		private void AutoDebuging_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 窗口检测
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, EventArgs e)
		{
			//按照名称抓取进程，如果进程没有，返回0
			IntPtr hWnd = FindWindow(null, textBox1.Text);
			if (int.Parse(hWnd.ToString()) != 0)
			{
				//listBox1.Items.Add(hWnd);
			}

			//label1.Text = GetForegroundWindow().ToString(); //当前程序的句柄
			label1.Text = hWnd.ToString();

			RECT rect = new RECT();
			//GetWindowRect(GetForegroundWindow(), ref rect);
			GetWindowRect(hWnd, ref rect);
			int width = rect.Right - rect.Left;                        //窗口的宽度
			int height = rect.Bottom - rect.Top;                   //窗口的高度
			int x = rect.Left;
			int y = rect.Top;
			label2.Text = x.ToString() + "*" + y.ToString();
			label3.Text = width.ToString() + "*" + height.ToString();

			//label7.Text = GetWindowRect(GetForegroundWindow(), ref rect).ToString();

			listBox1.TopIndex = listBox1.Items.Count - 1;
		}

		/// <summary>
		/// 将按钮信息读取并且转换为命令集
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 生成主菜单与命令集
		/// </summary>
		public static void DeBugMenu()
		{
			//主菜单
			List<string> menu = new List<string>();
			menu.AddRange(Arong_MenuS.MenuHeaderFile(2));
			menu.Add(Arong_MenuS.MenuHeaderFileEnd());
			string filename_menu = Arong_New.Arong_str() + "\\DebugTools\\startup\\AutoDebuging.men";
			if (File.Exists(filename_menu))
			{
				File.Delete(filename_menu);
			}
			for (int i = 0; i < menu.Count; i++)
			{
				File.AppendAllText(filename_menu, menu[i] + "\n", Encoding.GetEncoding("GB2312"));
			}

			//命令集
			List<string> functionalassembly = new List<string>();
			functionalassembly.AddRange(Arong_MenuS.FunctionalAssemblyStart(2));
			string path = Arong_New.Arong_str() + "\\Data\\Button";
			string[] info = Directory.GetFiles(path, "*");
			List<string> list = new List<string>();
			for (int i = 0; i < info.Length; i++)
			{
				string[] temps = File.ReadAllLines(info[i]);
				for (int j = 0; j < temps.Length; j++)
				{
					if (temps[j].StartsWith("\tBUTTON"))
					{
						list.Add(temps[j].Replace("BUTTON",""));
					}
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				functionalassembly.AddRange(Arong_MenuS.FunctionalAssembly(i, "DeBugLog.bmp", 2, list[i]));
			}
			string filename_utd = Arong_New.Arong_str() + "\\DebugTools\\startup\\AutoDebuging.utd";
			if (File.Exists(filename_utd))
			{
				File.Delete(filename_utd);
			}
			for (int i = 0; i < functionalassembly.Count; i++)
			{
				File.AppendAllText(filename_utd, functionalassembly[i] + "\n", Encoding.GetEncoding("GB2312"));
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DeBugMenu();
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AutoDebuging_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
