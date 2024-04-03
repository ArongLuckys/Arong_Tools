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
using System.Threading;
using CCWin;

namespace Bat
{
	public partial class Form1 : Skin_DevExpress
	{
		public Form1()
		{
			InitializeComponent();
			textBox2.Text = "C:\\";
			textBox3.Text = "";

			//显示用户设置的背景色
			this.BackColor = Arong_Menu.Properties.Settings.Default.Tools_color;
			Arong_Log.Oper_Log("Bat窗体初始化完成");
		}

		//生成
		private void button1_Click(object sender, EventArgs e)
		{
			//创建文件夹
			Directory.CreateDirectory(textBox2.Text + "\\_Bat");
			Arong_Log.Oper_Log("文件夹创建成功");

			if (textBox1.Text != "")
			{
				for (int i = 0; i < listBox1.Items.Count; i++)
				{
					Directory.Move(textBox2.Text + "\\" + listBox1.Items[i].ToString(), textBox2.Text + "\\_Bat\\" + listBox2.Items[i].ToString());
					Arong_Log.Oper_Log("拷贝第一个源文件" + listBox1.Items[i].ToString() +"&"+ listBox2.Items[i].ToString());
				}

				//暂缓1秒以免文件不存在
				Thread.Sleep(1000);

				for (int i = 0; i < listBox1.Items.Count; i++)
				{
					Directory.Move(textBox2.Text + "\\_Bat\\" + listBox2.Items[i].ToString() ,textBox2.Text + "\\" + listBox2.Items[i].ToString());
					Arong_Log.Oper_Log("拷贝第二个源文件" + listBox2.Items[i].ToString());
				}
				Directory.Delete(textBox2.Text + "\\_Bat");
			}
			else
			{
				MessageBox.Show("没有输入要替换的字符");
			}
			MessageBox.Show("完成");
			Arong_Log.Oper_Log("替换字符串完成");
		}

		//主循环
		private void Form1_Load(object sender, EventArgs e)
		{

		}

		//文件夹路径
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			string path = textBox2.Text;
			listBox1.Items.Clear();
			DirectoryInfo dir = new DirectoryInfo(path);
			if (dir.Exists == true)
			{
				FileInfo[] f = dir.GetFiles();
				for (int i = 0; i < f.Length; i++)
				{
					listBox1.Items.Add(f[i].ToString());
				}
			}
		}

		//显示替换的字符
		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		//预览
		private void button2_Click(object sender, EventArgs e)
		{
			if (textBox1.Text != "")
			{
				listBox2.Items.Clear();
				for (int i = 0; i < listBox1.Items.Count; i++)
				{
					string temp = listBox1.Items[i].ToString().Replace(textBox1.Text, textBox3.Text);
					listBox2.Items.Add(temp);
				}
			}
			else
			{
				MessageBox.Show("没有输入要替换的字符");
			}
		}

		//窗口发生改变时
		private void Form1_Resize(object sender, EventArgs e)
		{
			Size sizetemp = new Size();
			sizetemp.Width = (groupBox1.Width - 140) / 2;
			sizetemp.Height = (groupBox1.Height - 100);
			Point pointtemp = new Point();
			pointtemp.X = sizetemp.Width + 10;
			pointtemp.Y = 94;
			groupBox2.Size = sizetemp;
			groupBox3.Size = sizetemp;
			groupBox3.Location = pointtemp;
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
