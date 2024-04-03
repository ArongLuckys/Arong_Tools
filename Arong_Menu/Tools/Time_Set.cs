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
using CCWin;
using System.Xml.Linq;

namespace Arong_Menu
{
	public partial class Time_Set : Skin_DevExpress
	{
		public Time_Set()
		{
			InitializeComponent();
			this.BackColor = Properties.Settings.Default.Tools_color;
			Arong_Log.Oper_Log("Time_Set窗体初始化完成");

			if (radioButton1.Checked == true)
			{
				dateTimePicker1.Enabled = false;
			}
		}

		/// <summary>
		/// 主程序启动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Length != 0)
			{
				string[] name = Directory.GetFiles(textBox1.Text, "*", SearchOption.AllDirectories);
				for (int i = 0; i < name.Length; i++)
				{
					File.SetAttributes(name[i], FileAttributes.Normal); //将文件设为无属性，防止报错
					if (radioButton1.Checked == true)
					{
						File.SetLastWriteTime(name[i], DateTime.Now);
					}
					else
					{
						File.SetLastWriteTime(name[i], dateTimePicker1.Value);
					}
				}

				MessageBox.Show("完成，共计" + name.Length + "个文件变更完成");
			}
			else
			{
				MessageBox.Show("没有指定路径");
			}
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Time_Set_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		/// <summary>
		/// 当前时间
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
		/// 自定义时间
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
	}
}
