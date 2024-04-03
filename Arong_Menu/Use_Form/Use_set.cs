using Arong_Core;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arong_Menu
{
	public partial class Use_set : UserControl
	{
		public Use_set()
		{
			InitializeComponent();

			//加载默认颜色
			pictureBox1.BackColor = color1;
			pictureBox2.BackColor = color2;
			pictureBox3.BackColor = color3;
			pictureBox4.BackColor = color4;
			pictureBox5.BackColor = color5;

			Arong_Log.Oper_Log("用户设置-模块加载成功");

			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;
		}

		//颜色定义 月牙白
		public Color color1 = Color.FromArgb(255, 255, 255);
		//颜色定义 抹茶绿
		public Color color2 = Color.FromArgb(103, 208, 113);
		//颜色定义 深空灰
		public Color color3 = Color.FromArgb(240, 240, 240);
		//颜色定义 基佬紫
		public Color color4 = Color.FromArgb(171, 145, 255);
		//颜色定义 少女粉
		public Color color5 = Color.FromArgb(255, 148, 211);

		//百度网盘更新
		private void button2_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://pan.baidu.com/s/1PpN_0-qa8ndXakniMSlrkQ");
		}

		//窗体事件
		private void Use_set_Load(object sender, EventArgs e)
		{

		}

		//工具背景色
		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult dr = colorDialog1.ShowDialog();
			if (dr == DialogResult.OK)
			{
				Properties.Settings.Default.Tools_color = colorDialog1.Color;
				Properties.Settings.Default.Save();
				MessageBox.Show("修改完成，重启软件后生效");
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Tools_color = color1;
			Properties.Settings.Default.Save();
			MessageBox.Show("修改完成，重启软件后生效");
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Tools_color = color2;
			Properties.Settings.Default.Save();
			MessageBox.Show("修改完成，重启软件后生效");
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Tools_color = color3;
			Properties.Settings.Default.Save();
			MessageBox.Show("修改完成，重启软件后生效");
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Tools_color = color4;
			Properties.Settings.Default.Save();
			MessageBox.Show("修改完成，重启软件后生效");
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Tools_color = color5;
			Properties.Settings.Default.Save();
			MessageBox.Show("修改完成，重启软件后生效");
		}

		//移除环境变量
		private void button9_Click(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.nx_ver_off != false)
			{
				Task.Run(() =>
				{
					Arong_Re.Det_Nx_Ver_Environment_Variable();
					Properties.Settings.Default.nx_ver_off = false;
					Properties.Settings.Default.Save();
					MessageBox.Show("已删除环境变量");
				});
			}
			else
			{
				MessageBox.Show("已经移除了");
			}
		}

		//指派环境变量
		private void button5_Click(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.nx_ver_off != true)
			{
				//多线程创建
				Task.Run(() =>
				{
					Arong_Re.Nx_Ver_Environment_Variable();
					Properties.Settings.Default.nx_ver_off = true;
					Properties.Settings.Default.Save();
					MessageBox.Show("环境变量创建完成");
				});
			}
			else
			{
				MessageBox.Show("已经创建了");
			}
		}
	}
}