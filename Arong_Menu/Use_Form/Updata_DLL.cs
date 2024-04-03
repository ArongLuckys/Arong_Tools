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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Arong_Core;

namespace Arong_Menu
{
	public partial class Updata_DLL : UserControl
	{
		//复制到的文件夹路径
		public string path2 = Properties.Settings.Default.nx_dll_path;
		//基准文件夹路径
		public string path1 = Properties.Settings.Default.nx_dll_path_sta;

		public Updata_DLL()
		{
			InitializeComponent();
			checkBox1.Checked = Properties.Settings.Default.updata_time;
			Arong_Log.Oper_Log("更新功能-模块加载成功");

			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;

			label2.Text = Properties.Settings.Default.files_path;
		}

		//添加
		private void button1_Click(object sender, EventArgs e)
		{
			//清空列表2
			listBox2.Items.Clear();
			for (int i = 0; i < listBox1.SelectedItems.Count; i++)
			{
				listBox2.Items.Add(listBox1.SelectedItems[i].ToString());
			}
		}

		//排序
		private void button2_Click(object sender, EventArgs e)
		{
			
		}

		//全选
		private void button3_Click(object sender, EventArgs e)
		{
			listBox2.Items.Clear();
			if (path1 != "C:\\")
			{
				DirectoryInfo dir = new DirectoryInfo(path1);
				if (dir.Exists == true)
				{
					for (int i = 0; i < listBox1.Items.Count; i++)
					{
						listBox2.Items.Add(listBox1.Items[i]);
					}
				}
				else
				{
					MessageBox.Show("未指定基准目录或者目录不存在");
				}
			}
		}

		//清空
		private void button4_Click(object sender, EventArgs e)
		{
			if (listBox2.Items.Count > 0)
			{
				listBox2.Items.Clear();
			}
		}

		//设置
		private void button5_Click(object sender, EventArgs e)
		{
			Form_updata_dll form_Updata_Dll = new Form_updata_dll();
			form_Updata_Dll.ShowDialog();
		}

		//生成 核心功能
		private void button6_Click(object sender, EventArgs e)
		{

			//基准文件夹路径
			string sta_path = Properties.Settings.Default.files_path + "\\application";
			//更新目的文件夹路径
			string up_path = Properties.Settings.Default.nx_dll_path + "\\application";

			//清空日志文件
			string log = Arong_Core.Arong_New.Arong_str() + "\\Data\\Temp\\DLL_Log.txt";
			Arong_Core.Arong_File.File_String_Del(log);

			//判断是否拷贝dll
			if ((Properties.Settings.Default.nx_dll == true) && (listBox2.Items.Count > 0))
			{
				//32位文件夹路径创建
				if ((Properties.Settings.Default.nx75 == true) && (Properties.Settings.Default.nx_x32 == true))
				{
					string mane = "NX75";
					string var = "x32";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx8 == true) && (Properties.Settings.Default.nx_x32 == true))
				{
					string mane = "NX8";
					string var = "x32";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx85) == true && (Properties.Settings.Default.nx_x32 == true))
				{
					string mane = "NX85";
					string var = "x32";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}

				//64位文件夹创建
				if ((Properties.Settings.Default.nx75) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX75";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx8) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX8";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx85) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX85";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx9) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX9";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx10) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX10";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx11) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX11";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx12) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX12";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx1847) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX1847";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx1872) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX1872";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx1899) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX1899";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx1926) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX1926";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx1953) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX1953";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx1980) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX1980";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
				if ((Properties.Settings.Default.nx2007) == true && (Properties.Settings.Default.nx_x64 == true))
				{
					string mane = "NX2007";
					string var = "x64";
					Directory.CreateDirectory(path2 + Arong_Core.Arong_File.NX_DLL_VER(mane, var));
					for (int i = 0; i < listBox2.Items.Count; i++)
					{
						//当前对象的字符串
						string name = "\\" + listBox2.Items[i].ToString();
						string path1 = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						string path2 = Properties.Settings.Default.nx_dll_path + Arong_Core.Arong_File.NX_DLL_VER(mane, var);
						Arong_Core.Arong_File.Nx_Dll(path1, path2, name);
					}
				}
			}
			else
			{
				MessageBox.Show("没有选择列表");
			}

			//判断是否拷贝界面文件
			if ((Properties.Settings.Default.nx_dlx == true) && (listBox2.Items.Count > 0))
			{
				//拷贝dlx文件
				Arong_Core.Arong_File.Nx_Dlx(sta_path, up_path);
				//拷贝dlg文件
				Arong_Core.Arong_File.Nx_Dlg(sta_path, up_path);
			}

			//判断是否拷贝位图文件
			if ((Properties.Settings.Default.nx_bmp == true) && (listBox2.Items.Count > 0))
			{
				Arong_Core.Arong_File.Nx_Bmp(sta_path, up_path);
			}

			//打开生成完成的文件夹
			if (listBox2.Items.Count > 0)
			{
				MessageBox.Show("完成");
				System.Diagnostics.Process.Start("explorer.exe", up_path);
			}

			//清空列表2
			listBox2.Items.Clear();
		}

		//窗体加载事件
		private void Updata_DLL_Load(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			//翻译文件所在
			string langpath = Arong_New.Arong_str() + "\\Data\\Lang.ini";


			if (path1 != "C:\\")
			{
				DirectoryInfo dir = new DirectoryInfo(path1);
				if (dir.Exists == true)
				{
					FileInfo[] f = dir.GetFiles();
					for (int i = 0; i < f.Length; i++)
					{
						if (checkBox1.Checked == true)
						{
							//根据时间过滤列表
							DateTime updata = Convert.ToDateTime(File.GetLastWriteTime(path1 + "\\" + f[i].ToString()).ToString());
							DateTime usertime = Convert.ToDateTime(dateTimePicker1.Value);
							//判断时间
							if (updata >= usertime)
							{
								listBox1.Items.Add(f[i]);
							}
						}
						else
						{
							listBox1.Items.Add(f[i]);
							//名称翻译，好像失败了，没开发了
							//listBox1.Items.Add(Arong_Lang.Lang(langpath, f[i].ToString()));
						}
					}
				}
				else
				{
					MessageBox.Show("未指定基准目录或者目录不存在");
				}
			}

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
		}

		//功能搜索条
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			//输入内容后
			if (textBox1.Text != "")
			{
				//清空list1的内容，仅显示搜索出来的
				//listBox1.Items.Clear();
				string[] temps = new string[listBox1.Items.Count];
				for (int i=0;i < listBox1.Items.Count;i++)
				{
					temps[i] = listBox1.Items[i].ToString();
				}
				string[] list1 = Arong_Lang.Find(temps, textBox1.Text,textBox1.TextLength);
				listBox1.Items.Clear();
				for (int i =0;i<list1.Length;i++)
				{
					listBox1.Items.Add(list1[i]);
				}
				if (listBox1.Items.Count == 0)
				{
					listBox1.Items.Add("没有找到内容");
				}
			}
			//如果没有输入内容，则恢复列表显示
			else if (textBox1.Text == "")
			{
				listBox1.Items.Clear();
				if (path1 != "C:\\")
				{
					DirectoryInfo dir = new DirectoryInfo(path1);
					if (dir.Exists == true)
					{
						FileInfo[] f = dir.GetFiles();
						for (int i = 0; i < f.Length; i++)
						{
							listBox1.Items.Add(f[i]);
						}
					}
					else
					{
						MessageBox.Show("未指定基准目录或者目录不存在");
					}
				}
			}
		}

		//打开文件夹
		private void button7_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("explorer.exe", path2);
		}

		//删除文件
		private void button8_Click(object sender, EventArgs e)
		{
			//更新目的文件夹路径
			string up_path = Properties.Settings.Default.nx_dll_path + "\\application";
			if (Directory.Exists(up_path) == true)
			{
				Directory.Delete(up_path, true);
				MessageBox.Show("已删除更新包文件");
			}
			else
			{
				MessageBox.Show("删除失败，没有找到更新包"+ up_path);
			}
		}

		//更新日志
		private void button9_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Arong_Path.Updata_path);
		}

		//窗口变更大小时变换事件
		private void Updata_DLL_Resize(object sender, EventArgs e)
		{
			Size sizetemp = new Size((this.Width - 350) / 2, (this.Height - 80));
			Point pointtemp = new Point();
			Point pointtemp2 = new Point();
			pointtemp.X = sizetemp.Width + 10;
			pointtemp2.X = pointtemp.X + 200 + 3;
			pointtemp.Y = 26;
			pointtemp2.Y = 26;
			groupBox2.Location = pointtemp;
			listBox1.Size = sizetemp;
			listBox2.Size = sizetemp;
			listBox2.Location = pointtemp2;
		}

		//按时间更新
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.updata_time = checkBox1.Checked;
			Properties.Settings.Default.Save();
			Updata_DLL_Load(this,null);
		}

		//时间选择
		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			Updata_DLL_Load(this,null);
		}

		//手动指定
		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePicker1.Enabled = true;
			//当前时间
			DateTime time = DateTime.Now;
			dateTimePicker1.Value = time;
		}

		//一个月前
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePicker1.Enabled = false;
			//当前时间
			DateTime time = DateTime.Now;
			//时间差值
			TimeSpan ts = TimeSpan.FromDays(30);
			dateTimePicker1.Value = time - ts;
		}

		//一个星期前
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePicker1.Enabled = false;
			//当前时间
			DateTime time = DateTime.Now;
			//时间差值
			TimeSpan ts = TimeSpan.FromDays(7);
			dateTimePicker1.Value = time - ts;
		}

		//两个月前
		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePicker1.Enabled = false;
			//当前时间
			DateTime time = DateTime.Now;
			//时间差值
			TimeSpan ts = TimeSpan.FromDays(60);
			dateTimePicker1.Value = time - ts;
		}

		//基准版本
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx_ver_std = comboBox1.Text;
			Properties.Settings.Default.Save();
		}
	}
}
