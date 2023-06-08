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
	public partial class Custom_updata : Skin_DevExpress
	{
		public Custom_updata()
		{
			InitializeComponent();
			textBox1.Text = Properties.Settings.Default.User_Updata;

			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;

			Arong_Log.Oper_Log("Custom_updata窗体初始化完成");
			dateTimePicker1.Enabled = false;
		}

		//删除
		private void button1_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			label6.Text = "0";
		}

		//主窗口
		private void Custom_updata_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 生成
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			//更新包文件路径
			string newpath = textBox1.Text;
			string[] oldname = new string[listBox1.Items.Count];

			//先清空更新文件夹
			if (Directory.Exists(newpath))
			{
				Directory.Delete(newpath, true);
			}

			//检查是否是空的
			if (listBox1.Items.Count != 0)
			{
				//失败文件数量
				int errorfile = 0;

				for (int i = 0; i < listBox1.Items.Count; i++)
				{
					//去除根目录
					oldname[i] = listBox1.Items[i].ToString().Substring(listBox1.Items[i].ToString().IndexOf("\\"));
					Directory.CreateDirectory(Arong_File.File_NewPath(newpath + oldname[i]));

					if (Directory.Exists(Arong_File.File_NewPath(newpath + oldname[i])) == true)
					{
						File.Copy(listBox1.Items[i].ToString(), newpath + oldname[i], true);
						//检查文件是否有拷贝过去
						if (File.Exists(newpath + oldname[i]) == false)
						{
							Arong_Log.Oper_Log("复制失败的文件"+ listBox1.Items[i].ToString());
							errorfile++;
						}
					}
				}
				//展示结果
				if (errorfile !=0)
				{
					string infofile = "拷贝过程中出现" + errorfile.ToString() + "个文件拷贝失败,详细详细见Oper_Log文件";
					MessageBox.Show(infofile);
				}
				MessageBox.Show("完成");
				System.Diagnostics.Process.Start("explorer.exe", newpath);
				Arong_Log.Oper_Log("复制文件的文件夹结构完成");
			}
			else
			{
				MessageBox.Show("没有要复制的文件");
			}
		}

		//更新路径输入框
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			//判断是否是根目录
			if (textBox1.Text.Length > 3)
			{
				Properties.Settings.Default.User_Updata = textBox1.Text;
				Properties.Settings.Default.Save();
			}
			else
			{
				MessageBox.Show("不可以指派至根目录");
				textBox1.Text = Properties.Settings.Default.User_Updata;
			}
		}

		//接收数据
		private void listBox1_DragEnter(object sender, DragEventArgs e)
		{
			//接收文件
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				for (int i = 0; i < files.Length; i++)
				{
					//含有小数点的数据视为文件
					if (files[i].ToString().IndexOf(".") != -1)
					{
						listBox1.Items.Add(files[i]);
					}
					//拖入的是文件夹，则拷贝文件夹下所有文件
					if (Directory.Exists(files[i]) == true)
					{
						//用于接收文件夹内全部文件
						string[] filetemp = Directory.GetFiles(files[i],"*",SearchOption.AllDirectories);
						for (int f = 0; f < filetemp.Length; f++)
						{
							listBox1.Items.Add(filetemp[f]);
						}
					}
				}
			}
			label6.Text = listBox1.Items.Count.ToString();
		}

		//自动
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked == true)
			{
				dateTimePicker1.Enabled = true;
			}
		}

		//手动
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked == true)
			{
				dateTimePicker1.Enabled = false;
			}
		}

		//查找
		private void button3_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();

			if ((textBox2.Text.Length > 3) && (radioButton2.Checked == true))
			{
				string[] list = Directory.GetFiles(textBox2.Text, "*", SearchOption.AllDirectories);
				DateTime usertime = Convert.ToDateTime(dateTimePicker1.Value);
				TimeSpan ts = TimeSpan.FromDays(1);
				usertime = usertime - ts;
				for (int i = 0; i < list.Length; i++)
				{
					//对比时间
					DateTime listtime = Convert.ToDateTime(File.GetLastWriteTime(list[i]));
					if (listtime >= usertime)
					{
						listBox1.Items.Add(list[i]);
					}
				}

				//如果没有文件
				if (listBox1.Items.Count == 0)
				{
					MessageBox.Show("当前设置的日期内没有修改的文件");
				}

				label6.Text = listBox1.Items.Count.ToString();
			}
			if(textBox2.Text.Length <= 3)
			{
				MessageBox.Show("路径为空或者为根目录");
			}
			if (radioButton2.Checked == false)
			{
				MessageBox.Show("当前的查询类型不是自动");
			}
		}

		//移除
		private void button4_Click(object sender, EventArgs e)
		{
			if (listBox1.Items.Count != 0)
			{
				//移除选择的项
				for (int i = listBox1.Items.Count - 1; i >= 0; i--)
				{
					listBox1.Items.Remove(listBox1.SelectedItem);
				}
			}
			else
			{
				MessageBox.Show("列表是空的");
			}
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Custom_updata_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
