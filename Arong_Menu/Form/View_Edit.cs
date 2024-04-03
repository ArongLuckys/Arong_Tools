using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Arong_Core;
using CCWin;

namespace Arong_Menu
{
	public partial class View_Edit : Skin_DevExpress
	{
		public View_Edit()
		{
			InitializeComponent();
			Arong_Log.Oper_Log("View_Edit窗体初始化完成");

			this.BackColor = Properties.Settings.Default.Tools_color;
		}

		//主窗口
		private void Form4_Load(object sender, EventArgs e)
		{
			//application路径
			string path1 = Properties.Settings.Default.files_path + "\\application\\nx10\\x64\\";
			//客户文件夹路径
			string path2 = @"D:\VICTOR_CAD_VT\customer\VICTOR\startup\cad_main_menu.men";
			//这个存在问题

			string[] temps = Arong_Core.Arong_File.View_Info(path2,path1);

			//以下是关于基准版本选择与记忆的逻辑
			comboBox1.Items.Clear();
			string[] std = Arong_File.File_Nx_Ver();
			for (int i = 0; i < std.Length; i++)
			{
				comboBox1.Items.Add(std[i]);
			}
			int lis = 0;
			for (int i = 0; i < std.Length; i++)
			{
				if (comboBox1.Items[i].Equals(Properties.Settings.Default.nx_ver_std))
				{
					lis = i;
				}
			}
			comboBox1.SelectedIndex = lis;

			//得到文件夹名称
			int lis2 = 0;
			string[] find1 = Arong_Core.Arong_File.File_Find(Properties.Settings.Default.files_path);
			for (int i = 0; i < find1.Length; i++)
			{
				comboBox2.Items.Add(find1[i]);
			}
			comboBox2.SelectedIndex = lis2;

			View1.Columns.Clear();

			ColumnHeader c1 = new ColumnHeader();
			c1.Width = 250;
			c1.Text = "功能名称";
			ColumnHeader c2 = new ColumnHeader();
			c2.Width = 300;
			c2.Text = "功能使用的DLL名称";
			ColumnHeader c3 = new ColumnHeader();
			c3.Width = 250;
			c3.Text = "功能更新时间";

			View1.Columns.Add(c1);
			View1.Columns.Add(c2);
			View1.Columns.Add(c3);

			int index = 0;
			for (int i =0;i< temps.Length / 3; i ++)
			{
				for (int b = 0; b < 1; b++)
				{
					View1.Items.Add(new ListViewItem(new string[] { temps[index], temps[index +1], temps[index +2] }));
				}
				index  = index +3;
			}
		}

		//客户选择
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		//基准选择
		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		//刷新
		private void button1_Click(object sender, EventArgs e)
		{
			Form4_Load(this, null);
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_Edit_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
