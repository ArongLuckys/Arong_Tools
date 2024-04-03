using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arong_Core;

namespace Arong_Menu.Use_Form
{
	public partial class File_Find : UserControl
	{
		public File_Find()
		{
			InitializeComponent();
			checkBox1.Checked = Properties.Settings.Default.file_find_data;
			checkBox2.Checked = Properties.Settings.Default.file_find_reference;
			checkBox3.Checked = Properties.Settings.Default.file_find_part;
			checkBox4.Checked = Properties.Settings.Default.file_find_set;
			checkBox5.Checked = Properties.Settings.Default.file_find_startup;
			checkBox6.Checked = Properties.Settings.Default.file_xls;

			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;

			Arong_Log.Oper_Log("文件查缺-模块加载成功");
		}

		//窗体事件
		private void File_Find_Load(object sender, EventArgs e)
		{
			//判断是否有指定文件夹路径
			if (Properties.Settings.Default.files_path == "C:\\")
			{
				MessageBox.Show("未指定维特软件目录");
			}
			else
			{
				//清空
				comboBox1.Items.Clear();
				comboBox2.Items.Clear();
				comboBox3.Items.Clear();

				//得到文件夹名称
				string[] find1 = Arong_Core.Arong_File.File_Find(Properties.Settings.Default.files_path);
				for (int i = 0; i < find1.Length; i++)
				{
					comboBox1.Items.Add(find1[i]);
					comboBox2.Items.Add(find1[i]);
					comboBox3.Items.Add(find1[i]);
				}

				//判断当前检查文件的属性是哪个
				int lis1 = 0;
				for (int i = 0; i < find1.Length; i++)
				{
					if (comboBox1.Items[i].Equals(Properties.Settings.Default.find_oid))
					{
						lis1 = i;
					}
				}
				comboBox1.SelectedIndex = lis1;

				//判断当前基准文件的属性是哪个
				int lis2 = 0;
				for (int i = 0; i < find1.Length; i++)
				{
					if (comboBox2.Items[i].Equals(Properties.Settings.Default.find_std))
					{
						lis2 = i;
					}
				}

				//判断要清理的属性是哪个
				int lis3 = 0;
				for (int i = 0; i < find1.Length; i++)
				{
					if (comboBox3.Items[i].Equals(Properties.Settings.Default.find_clear))
					{
						lis3 = i;
					}
				}

				comboBox1.SelectedIndex = lis1;
				comboBox2.SelectedIndex = lis2;
				comboBox3.SelectedIndex = lis3;

				Arong_Log.Oper_Log("客户文件初始化完成");
			}
		}

		//检查文件夹
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.find_oid = comboBox1.Text;
			Properties.Settings.Default.Save();
		}

		//校准文件夹
		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.find_std = comboBox2.Text;
			Properties.Settings.Default.Save();
		}

		//客户文件夹清理
		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.find_clear = comboBox3.Text;
			Properties.Settings.Default.Save();
		}

		//data
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.file_find_data = checkBox1.Checked;
			Properties.Settings.Default.Save();
		}

		//reference(菜单文件)
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.file_find_reference = checkBox2.Checked;
			Properties.Settings.Default.Save();
		}

		//part
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.file_find_part = checkBox3.Checked;
			Properties.Settings.Default.Save();
		}

		//set
		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.file_find_set = checkBox4.Checked;
			Properties.Settings.Default.Save();
		}

		//startup
		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.file_find_startup = checkBox5.Checked;
			Properties.Settings.Default.Save();
		}


		//文件查缺
		private void button1_Click(object sender, EventArgs e)
		{
			//清空日志文件
			string log = Arong_Core.Arong_New.Arong_str() + "\\Temp\\File_Log.txt";
			Arong_Core.Arong_File.File_String_Del(log);

			//要拷贝的目的地位置，默认为维特文件夹下temp\arong_tools;
			string copypath = Properties.Settings.Default.files_path + "\\temp\\_Arong_Tools";
			Directory.CreateDirectory(copypath);


			//data文件夹检查
			if (checkBox1.Checked == true)
			{
				//检查文件路径
				string data_path1 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox1.Text +"\\data";
				//基准文件路径
				string data_path2 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox2.Text + "\\data";
				//执行检查
				Arong_Core.Arong_File.File_ALL(data_path2, data_path1,checkBox10.Checked, copypath);
			}

			//reference文件夹检查
			if (checkBox2.Checked == true)
			{
				//检查文件路径
				string reference_path1 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox1.Text + "\\reference";
				//基准文件路径
				string reference_path2 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox2.Text + "\\reference";
				//执行检查
				Arong_Core.Arong_File.File_ALL(reference_path2, reference_path1, checkBox10.Checked, copypath);
			}

			//part文件夹检查
			if (checkBox3.Checked == true)
			{
				//检查文件路径
				string part_path1 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox1.Text + "\\part";
				//基准文件路径
				string part_path2 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox2.Text + "\\part";
				//执行检查
				Arong_Core.Arong_File.File_ALL(part_path2, part_path1, checkBox10.Checked, copypath);
			}

			//set文件夹检查
			if (checkBox4.Checked == true)
			{
				//检查文件路径
				string set_path1 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox1.Text + "\\set";
				//基准文件路径
				string set_path2 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox2.Text + "\\set";
				//执行检查
				Arong_Core.Arong_File.File_ALL(set_path2, set_path1, checkBox10.Checked, copypath);
			}

			//startup文件夹检查
			if (checkBox5.Checked == true)
			{
				//检查文件路径
				string startup_path1 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox1.Text + "\\startup";
				//基准文件路径
				string startup_path2 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox2.Text + "\\startup";
				//执行检查
				Arong_Core.Arong_File.File_ALL(startup_path2, startup_path1, checkBox10.Checked, copypath);
			}

			MessageBox.Show("对比完成");
			Arong_Log.Oper_Log("文件查缺完成");
		}

		//对比文件差异化
		private void button2_Click(object sender, EventArgs e)
		{
			//清空日志文件
			string log = Arong_Core.Arong_New.Arong_str() + "\\Temp\\File_Log.txt";
			Arong_Core.Arong_File.File_String_Del(log);

			//检查文件路径
			string path1 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox1.Text;
			//基准文件路径
			string path2 = Properties.Settings.Default.files_path + "\\customer\\" + comboBox2.Text;

			Arong_Core.Arong_File.File_All_Dis(path2, path1,checkBox6.Checked,"*.xls");
			Arong_Core.Arong_File.File_All_Dis(path2, path1, checkBox6.Checked, "*.xlsx");

			MessageBox.Show("对比完成");
			Arong_Log.Oper_Log("对比文件差异化完成");
		}

		//日志文件
		private void button3_Click(object sender, EventArgs e)
		{
			string path = Arong_Core.Arong_New.Arong_str() + "\\Temp\\File_Log.txt";
			System.Diagnostics.Process.Start(@path);
		}

		//仅对比数据表格
		private void checkBox6_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox6.Checked == false)
			{
				MessageBox.Show("如果对比全部文件，会占用电脑大量资源，分析时常可能会很久");
			}
			Properties.Settings.Default.file_xls = checkBox6.Checked;
			Properties.Settings.Default.Save();
		}

		//压缩文件
		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{

		}

		//副本文件
		private void checkBox8_CheckedChanged(object sender, EventArgs e)
		{

		}

		//移动到临时文件夹而不是删除
		private void checkBox9_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox9.Checked == false)
			{
				MessageBox.Show("请注意，删除是不会出现在回收站的");
			}
			Arong_Log.Oper_Log("移动到临时文件夹而不是删除-执行");
		}

		//开始清理，主程序
		private void button4_Click(object sender, EventArgs e)
		{
			//获得要清理的文件夹地址
			string path1 = Properties.Settings.Default.files_path + "\\customer\\" + Properties.Settings.Default.find_clear;
			//日志文件地址
			string path2 = Directory.GetCurrentDirectory() + "\\Temp\\File_Clear.txt";
			//维特的临时文件夹地址
			string pathtemp = Properties.Settings.Default.files_path + "\\temp\\_Arong_Tools";
			Directory.CreateDirectory(pathtemp);

			//清空日志
			Arong_Core.Arong_File.File_String_Del(path2);

			string[] fileList1 = Directory.GetFiles(path1, "*", SearchOption.AllDirectories);
			string[] fileList2 = Directory.GetFiles(path1, "*.zip", SearchOption.AllDirectories);
			string[] fileList3 = Directory.GetFiles(path1, "*.7z", SearchOption.AllDirectories);

			//得到全部zip文件
			if (checkBox7.Checked == true)
			{
				for (int i = 0; i < fileList2.Length; i++)
				{
					File.AppendAllText(path2, fileList2[i] + "\n");
				}
				//File.AppendAllText(path2, "zip查询完成 共"+ fileList2.Length +"个" + "\n");
			}

			//得到全部7z文件
			if (checkBox7.Checked == true)
			{
				for (int i = 0; i < fileList3.Length; i++)
				{
					File.AppendAllText(path2, fileList3[i] + "\n");
				}
				//File.AppendAllText(path2, "7z查询完成 共" + fileList3.Length + "个" + "\n");
			}

			//得到含副本的文件
			if (checkBox8.Checked == true)
			{
				string name = "副本";
				for (int i = 0; i < fileList1.Length; i++)
				{
					int sum = fileList1[i].IndexOf(name);
					if (sum != -1)
					{
						File.AppendAllText(path2, fileList1[i] + "\n");
					}
				}
			}

			//读取日志文件中所有的路径
			string[] fileList4 = File.ReadAllLines(path2);

			//决定是删除还是移动
			if (checkBox9.Checked == true)
			{
				string namess = "";
				for (int i = 0; i < fileList4.Length; i++)
				{
					namess = fileList4[i].Replace(path1,pathtemp);
					MessageBox.Show(namess);
				}
			}
			else
			{

			}

			MessageBox.Show("完成");
			Arong_Log.Oper_Log("开始清理垃圾文件完成");
		}

		//临时文件夹
		private void button5_Click(object sender, EventArgs e)
		{
			string path = Properties.Settings.Default.files_path + "\\temp";
			System.Diagnostics.Process.Start("explorer.exe", path);
			Arong_Log.Oper_Log("打开了临时文件夹");
		}

		//清理日志
		private void button6_Click(object sender, EventArgs e)
		{
			string path2 = Directory.GetCurrentDirectory() + "\\Temp\\File_Clear.txt";
			System.Diagnostics.Process.Start(@path2);
			Arong_Log.Oper_Log("查看了清理日志");
		}
	}
}
