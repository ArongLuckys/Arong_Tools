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
using Arong_Core;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Arong_Menu
{
	public partial class Icon_Assistant : Skin_DevExpress
	{
		public Icon_Assistant()
		{
			InitializeComponent();
			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;
		}

		/// <summary>
		/// 窗口加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Icon_Assistant_Load(object sender, EventArgs e)
		{
			//获取环境是否正常
			label1.Text = "测试环境正常";

			//获取当前设置的nx版本
			string path = Arong_New.Arong_str() + "\\Data\\Nx\\Nx_Exe_Path.ini";
			string[] nxexe = File.ReadAllLines(path);

			if (nxexe.Length > 0)
			{
				flowLayoutPanel1.Padding = new Padding(18, 3, 0, 3);

				//获得nx图标
				Image ico = Icon.ExtractAssociatedIcon(Arong_File.Data_Eq_end(nxexe[0])).ToBitmap();
				Bitmap bitmap = (Bitmap)ico;
				Bitmap resizedBitmap = new Bitmap(bitmap, new Size(16, 16));

				//添加
				for (int i = 0; i < nxexe.Length; i++)
				{
					Button bn = new Button()
					{
						BackgroundImage = resizedBitmap,
						BackgroundImageLayout = ImageLayout.None,
						Size = new Size(120, 25),
						ImageAlign = ContentAlignment.MiddleLeft,
						Name = Arong_File.Data_Eq_front(nxexe[i]),
						Text = Arong_File.Data_Eq_front(nxexe[i]),
						AutoSize = true,
						Tag = Arong_File.Data_Eq_end(nxexe[i]),
						Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))),
						Cursor = System.Windows.Forms.Cursors.Hand,
						UseVisualStyleBackColor = true,
					};
					bn.Click += new EventHandler(Button_C);
					flowLayoutPanel1.Controls.Add(bn);
				}
			}
		}

		/// <summary>
		/// 点击启动nx
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_C(object sender, EventArgs e)
		{
			Button bn = (Button)sender;
			System.Diagnostics.Process.Start(bn.Tag.ToString());
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Icon_Assistant_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		/// <summary>
		/// 打开位图文件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			string path = Arong_New.Arong_str() + "\\ICO\\Application";
			System.Diagnostics.Process.Start("explorer.exe", path);
		}

		/// <summary>
		/// 更新环境
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			if (Arong_MenuS.BmpFileName().Length != 0)
			{
				MenuFile();
				MessageBox.Show("配置完成，请启动NX");
			}
			else
			{
				MessageBox.Show("测试的文件夹内没有图标，请添加后重试");
				button1_Click(sender,e);
			}
		}

		/// <summary>
		/// 结束NX
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("ugraf");
			foreach (System.Diagnostics.Process p in process)
			{
				p.Kill();
			}
		}

		/// <summary>
		/// 测试主菜单
		/// </summary>
		public void MenuFile()
		{
			//主菜单
			List<string> menu = new List<string>();
			string[] bmp = Arong_MenuS.BmpFileName();
			menu.AddRange(Arong_MenuS.MenuHeaderFile(1));
			for (int i = 0; i < bmp.Length; i++)
			{
				menu.AddRange(Arong_MenuS.FunctionalGrouping(i, bmp[i]));
			}
			menu.Add(Arong_MenuS.MenuHeaderFileEnd());
			string filename_menu = Arong_New.Arong_str() + "\\ICO\\startup\\IconAssistant.men";
			if (File.Exists(filename_menu))
			{
				File.Delete(filename_menu);
			}
			for (int i = 0; i < menu.Count; i++)
			{
				File.AppendAllText(filename_menu, menu[i] + "\n", Encoding.GetEncoding("GB2312"));
			}

			//工具条
			List<string> tools = new List<string>();
			tools.AddRange(Arong_MenuS.ToolsBarStart());
			tools.AddRange(Arong_MenuS.ToolsBar(menu));
			string filename_tools = Arong_New.Arong_str() + "\\ICO\\startup\\IconAssistant.tbr";
			if (File.Exists(filename_tools))
			{
				File.Delete(filename_tools);
			}
			for (int i = 0; i < tools.Count; i++)
			{
				File.AppendAllText(filename_tools, tools[i] + "\n", Encoding.GetEncoding("GB2312"));
			}

			//功能区
			List<string> region = new List<string>();
			region.AddRange(Arong_MenuS.RegionStart());
			region.AddRange(Arong_MenuS.Region(menu));
			string filename_region = Arong_New.Arong_str() + "\\ICO\\startup\\IconAssistant.rtb";
			if (File.Exists(filename_region))
			{
				File.Delete(filename_region);
			}
			for (int i = 0; i < region.Count; i++)
			{
				File.AppendAllText(filename_region, region[i] + "\n", Encoding.GetEncoding("GB2312"));
			}

			//命令集
			List<string> functionalassembly = new List<string>();
			functionalassembly.AddRange(Arong_MenuS.FunctionalAssemblyStart(1));
			for (int i = 0; i < bmp.Length; i++)
			{
				functionalassembly.AddRange(Arong_MenuS.FunctionalAssembly(i, bmp[i],1, i.ToString()));
			}
			string filename_utd = Arong_New.Arong_str() + "\\ICO\\startup\\IconAssistant.utd";
			if (File.Exists(filename_utd))
			{
				File.Delete(filename_utd);
			}
			for (int i = 0; i < functionalassembly.Count; i++)
			{
				File.AppendAllText(filename_utd, functionalassembly[i] + "\n", Encoding.GetEncoding("GB2312"));
			}
		}
	}
}
