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

namespace Arong_Menu
{
	public partial class Menu_Edit : UserControl
	{
		public Menu_Edit()
		{
			InitializeComponent();
			Arong_Log.Oper_Log("菜单编辑-模块加载成功");

			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;
		}

		//主窗口
		private void Menu_Edit_Load(object sender, EventArgs e)
		{
			//清除数据
			menu_edit_box1.Clear();
			menu_edit_box2.Clear();
			menu_edit_box3.Clear();
			menu_edit_box4.Clear();
			menu_edit_box5.Clear();
			menu_edit_box6.Clear();
			comboBox1.Items.Clear();

			string path = Arong_New.Arong_str() + "\\Data\\Button";
			//得到文件夹下所有文件名称
			DirectoryInfo dir = new DirectoryInfo(path);
			if (dir.Exists ==true)
			{
				FileInfo[] f = dir.GetFiles();
				for (int i = 0; i < f.Length; i++)
				{
					comboBox1.Items.Add(f[i].ToString().Replace(".txt",""));
				}
				label9.Text = "共有"+ f.Length + "个功能";
			}
		}

		//生成功能
		private void button1_Click(object sender, EventArgs e)
		{
			if ((menu_edit_box1.Text != "") && (menu_edit_box2.Text != "") && (menu_edit_box3.Text != "") && (menu_edit_box5.Text != "") && (menu_edit_box6.Text != ""))
			{
				Arong_New.New_path(menu_edit_box1.Text, menu_edit_box2.Text, menu_edit_box3.Text, menu_edit_box4.Text, menu_edit_box5.Text, menu_edit_box6.Text);

				MessageBox.Show("创建完成");
				Arong_Log.Oper_Log("功能创建完成");
			}
			else
			{
				MessageBox.Show("只有消息与位图名称才可为空，其他为空则无法创建");
				Arong_Log.Oper_Log("功能创建失败");
			}
			Menu_Edit_Load(this,null);
		}

		//生成菜单
		private void button2_Click(object sender, EventArgs e)
		{

		}

		//打开文件夹
		private void button3_Click(object sender, EventArgs e)
		{
			string path = Arong_New.Arong_str() + "\\Data\\Button";
			System.Diagnostics.Process.Start("explorer.exe", path);
		}

		//选中要改的文件
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			//清除数据
			menu_edit_box1.Clear();
			menu_edit_box2.Clear();
			menu_edit_box3.Clear();
			menu_edit_box4.Clear();
			menu_edit_box5.Clear();
			menu_edit_box6.Clear();

			//获得当前选中的文件的地址
			string path = Arong_New.Arong_str() + "\\Data\\Button\\" + comboBox1.Text + ".txt";
			//读取模板文件的数组
			string sta = Arong_New.Arong_str() + "\\Data\\Data\\Temp_Menu.txt";
			string[] data = File.ReadAllLines(path);
			string[] datasta = File.ReadAllLines(sta);

			if (data.Length>6)
			{
				DialogResult dr = MessageBox.Show("非法的数据文件,是否要修改数据源？","消息",MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{
					System.Diagnostics.Process.Start(path);
				}
				Arong_Log.Oper_Log(comboBox1.SelectedItem.ToString()+ "\t非法的数据文件");
			}
			else
			{
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].Length>4)
					{
						//添加菜单id
						if (data[i].Substring(0, 3) == "\tBU")
						{
							menu_edit_box2.Text = data[i] = data[i].Replace(datasta[1], "");
						}
						//添加位图
						if (data[i].Substring(0, 3) == "\tBI")
						{
							menu_edit_box4.Text = data[i] = data[i].Replace(datasta[4], "");
						}
					}
					//添加功能注释
					if (data[i].Substring(0, 1) == "!")
					{
						menu_edit_box1.Text = data[i] = data[i].Replace(datasta[0], "");
					}
					//添加显示名称
					if (data[i].Substring(0, 2) == "\tL")
					{
						menu_edit_box3.Text = data[i] = data[i].Replace(datasta[2], "");
					}
					//添加消息
					if (data[i].Substring(0, 2) == "\tM")
					{
						menu_edit_box6.Text = data[i] = data[i].Replace(datasta[3], "");
					}
					//添加DLL
					if (data[i].Substring(0, 2) == "\tA")
					{
						menu_edit_box5.Text = data[i] = data[i].Replace(datasta[5], "");
						menu_edit_box5.Text = menu_edit_box5.Text.ToString().Replace(datasta[6], "");
					}
				}
			}
		}
	}
}
