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

namespace Arong_Menu
{
	public partial class Time_Set : Skin_DevExpress
	{
		public Time_Set()
		{
			InitializeComponent();
			this.BackColor = Properties.Settings.Default.Tools_color;
			Arong_Log.Oper_Log("Time_Set窗体初始化完成");
		}

		/// <summary>
		/// 主程序启动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			string path = textBox1.Text;
			string[] name = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
			for (int i = 0; i < name.Length; i++)
			{
				File.SetAttributes(name[i], System.IO.FileAttributes.Normal); //将文件设为无属性，防止报错
				File.SetLastWriteTime(name[i], DateTime.Now);
			}

			MessageBox.Show("完成，共计" + name.Length + "个文件变更完成");
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
	}
}
