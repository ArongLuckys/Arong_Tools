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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
			listView1.Items.Clear();
			label6.Text = "0";
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
			string[] oldname = new string[listView1.Items.Count];

			//先清空更新文件夹
			if (Directory.Exists(newpath))
			{
				Directory.Delete(newpath, true);
			}

			//检查是否是空的
			if (listView1.Items.Count != 0)
			{
				//失败文件数量
				int errorfile = 0;

				for (int i = 0; i < listView1.Items.Count; i++)
				{
					//去除根目录
					oldname[i] = listView1.Items[i].Text.Substring(listView1.Items[i].Text.IndexOf("\\"));
					Directory.CreateDirectory(Arong_File.File_NewPath(newpath + oldname[i]));

					if (Directory.Exists(Arong_File.File_NewPath(newpath + oldname[i])) == true)
					{
						File.Copy(listView1.Items[i].Text, newpath + oldname[i], true);
						//检查文件是否有拷贝过去
						if (File.Exists(newpath + oldname[i]) == false)
						{
							Arong_Log.Oper_Log("复制失败的文件" + listView1.Items[i].Text);
							errorfile++;
						}
					}
				}
				//展示结果
				if (errorfile != 0)
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


		/// <summary>
		/// 自动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked == true)
			{
				dateTimePicker1.Enabled = true;
			}
		}

		/// <summary>
		/// 手动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked == true)
			{
				dateTimePicker1.Enabled = false;
			}
		}

		/// <summary>
		/// 自动查找
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();

			if ((textBox2.Text.Length > 3) && (radioButton2.Checked == true))
			{
				string[] list = Directory.GetFiles(textBox2.Text, "*", SearchOption.AllDirectories);
				DateTime usertime = Convert.ToDateTime(dateTimePicker1.Value);
				TimeSpan ts = TimeSpan.FromDays(1);
				usertime -= ts;
				for (int i = 0; i < list.Length; i++)
				{
					//对比时间
					DateTime listtime = Convert.ToDateTime(File.GetLastWriteTime(list[i]));
					if (listtime >= usertime)
					{
						listView1.Items.Add(new ListViewItem(new string[] { list[i], Convert.ToDateTime(File.GetLastWriteTime(list[i])).ToString() }));
					}
				}

				//适应列表
				listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

				//如果没有文件
				if (listView1.Items.Count == 0)
				{
					MessageBox.Show("当前设置的日期内没有修改的文件");
				}
				label6.Text = listView1.Items.Count.ToString();
			}
			if (textBox2.Text.Length <= 3)
			{
				MessageBox.Show("路径为空或者为根目录");
			}
			if (radioButton2.Checked == false)
			{
				MessageBox.Show("当前的查询类型不是自动");
			}
		}

		/// <summary>
		/// 移除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button4_Click(object sender, EventArgs e)
		{
			if (listView1.Items.Count != 0)
			{
				//移除选择的项
				foreach (ListViewItem lvi in listView1.SelectedItems)
				{
					listView1.Items.RemoveAt(lvi.Index);
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

		/// <summary>
		/// 窗体加载程序
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Custom_updata_Load(object sender, EventArgs e)
		{
			listView1.Columns.Add("文件路径", 200);
			listView1.Columns.Add("文件日期", 200);
		}

		/// <summary>
		/// 列表视图 拖动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listView1_DragEnter(object sender, DragEventArgs e)
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
						listView1.Items.Add(new ListViewItem(new string[] { files[i], Convert.ToDateTime(File.GetLastWriteTime(files[i])).ToString() }));
					}
					//拖入的是文件夹，则拷贝文件夹下所有文件
					if (Directory.Exists(files[i]) == true)
					{
						//用于接收文件夹内全部文件
						string[] filetemp = Directory.GetFiles(files[i], "*", SearchOption.AllDirectories);
						for (int f = 0; f < filetemp.Length; f++)
						{
							listView1.Items.Add(new ListViewItem(new string[] { filetemp[f], Convert.ToDateTime(File.GetLastWriteTime(filetemp[f])).ToString() }));
						}
					}
				}
				listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			}
			label6.Text = listView1.Items.Count.ToString();
		}
	}
}
