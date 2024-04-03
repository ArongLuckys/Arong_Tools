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
using CCWin;

namespace Arong_Menu
{
	public partial class Form_main : Skin_DevExpress
	{
		public License_switching APP_License_switching;
		public Menu_Edit APP_Menu_Edit;
		public Use_Form.File_Find APP_File_Find;
		public Use_set APP_Use_set;
		public Updata_DLL APP_Updata_DLL;
		public Improving_Tool APP_Improving_Tool;
		public Environment_Variable_v2 APP_Environment_Variable_v2;

		//关于当前窗体的显示
		//0许可切换，1菜单编辑器，2可视化菜单，3文件查缺，4更新功能，5帮助助手，6设置，7提效工具,8环境变量
		//启动默认为0
		public int panel_ui = 0;

		public Form_main()
		{
			InitializeComponent();

			//加载用户最后退出窗体时的位置
			this.Location = (Point)Properties.Settings.Default.form;

			//实例化用户控件
			APP_License_switching = new License_switching();
			APP_License_switching.Size = panel1.Size;
			APP_Menu_Edit = new Menu_Edit();
			APP_File_Find = new Use_Form.File_Find();
			APP_Use_set = new Use_set();
			APP_Updata_DLL = new Updata_DLL();
			APP_Improving_Tool = new Improving_Tool();
			APP_Environment_Variable_v2 = new Environment_Variable_v2();

			//以下是定义位图资源加载
			pictureBox2.BackgroundImage = Properties.Resources.License_switching_1;
			pictureBox3.BackgroundImage = Properties.Resources.Menu_Edit_1;
			pictureBox4.BackgroundImage = Properties.Resources.Size_1;
			pictureBox5.BackgroundImage = Properties.Resources.Info_1;
			pictureBox6.BackgroundImage = Properties.Resources.Updata_dll_1;
			pictureBox7.BackgroundImage = Properties.Resources.Helper_1;
			pictureBox1.BackgroundImage = Properties.Resources.File_Find_1;
			pictureBox8.BackgroundImage = Properties.Resources.View_Menu_1;
			pictureBox9.BackgroundImage = Properties.Resources.Improving_Tool_1;
			pictureBox10.BackgroundImage = Properties.Resources.Environment_Variable_1;

			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;
			Arong_Log.Oper_Log("主界面始化-成功");
		}

		//呈现窗口
		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		//主窗口
		private void Form_main_Load(object sender, EventArgs e)
		{
			//默认显示许可切换
			panel1.Visible = false;
			panel1.Controls.Clear();
			panel1.Controls.Add(APP_License_switching);
			panel1.Visible = true;

			//SetStyle(ControlStyles.UserPaint, true);
			//SetStyle(ControlStyles.AllPaintingInWmPaint,true);
			//SetStyle(ControlStyles.OptimizedDoubleBuffer,true);
		}

		//新版许可切换
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			if (panel_ui != 0)
			{
				APP_License_switching = new License_switching();
				panel1.Controls.Clear();
				APP_License_switching.Size = panel1.Size;
				panel1.Controls.Add(APP_License_switching);
				panel_ui = 0;
			}
		}

		//新版许可切换 鼠标进入
		private void pictureBox2_MouseEnter(object sender, EventArgs e)
		{
			pictureBox2.BackgroundImage = Properties.Resources.License_switching_2;
		}

		//新版许可切换 鼠标离开
		private void pictureBox2_MouseLeave(object sender, EventArgs e)
		{
			pictureBox2.BackgroundImage = Properties.Resources.License_switching_1;
		}

		//新版本菜单编辑器
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			if (panel_ui != 1)
			{
				APP_Menu_Edit = new Menu_Edit();
				panel1.Controls.Clear();
				APP_Menu_Edit.Size = panel1.Size;
				panel1.Controls.Add(APP_Menu_Edit);
				panel_ui = 1;
			}
		}

		//新版本菜单编辑器 鼠标进入
		private void pictureBox3_MouseEnter(object sender, EventArgs e)
		{
			pictureBox3.BackgroundImage = Properties.Resources.Menu_Edit_2;
		}

		//新版本菜单编辑器 鼠标离开
		private void pictureBox3_MouseLeave(object sender, EventArgs e)
		{
			pictureBox3.BackgroundImage = Properties.Resources.Menu_Edit_1;
		}

		//新版本设置
		private void pictureBox4_Click(object sender, EventArgs e)
		{
			if (panel_ui != 6)
			{
				panel1.Controls.Clear();
				APP_Use_set.Size = panel1.Size;
				panel1.Controls.Add(APP_Use_set);
				panel_ui = 6;
			}
		}

		//新版本设置 鼠标进入
		private void pictureBox4_MouseEnter(object sender, EventArgs e)
		{
			pictureBox4.BackgroundImage = Properties.Resources.Size_2;
		}

		//新版本设置 鼠标离开
		private void pictureBox4_MouseLeave(object sender, EventArgs e)
		{
			pictureBox4.BackgroundImage = Properties.Resources.Size_1;
		}

		//新版本关于
		private void pictureBox5_Click(object sender, EventArgs e)
		{
			MessageBox.Show("日复一日，必有精进","作者的话");
			string path = Arong_New.Arong_str() + "\\Updata.txt";
			System.Diagnostics.Process.Start(@path);
		}

		//新版本关于 鼠标进入
		private void pictureBox5_MouseEnter(object sender, EventArgs e)
		{
			pictureBox5.BackgroundImage = Properties.Resources.Info_2;
		}

		//新版本关于 鼠标离开
		private void pictureBox5_MouseLeave(object sender, EventArgs e)
		{
			pictureBox5.BackgroundImage = Properties.Resources.Info_1;
		}

		//新版本更新功能
		private void pictureBox6_Click(object sender, EventArgs e)
		{
			if (panel_ui != 4)
			{
				APP_Updata_DLL = new Updata_DLL();
				panel1.Controls.Clear();
				APP_Updata_DLL.Size = panel1.Size;
				panel1.Controls.Add(APP_Updata_DLL);
				panel_ui = 4;
			}
		}

		//新版本更新功能 鼠标进入
		private void pictureBox6_MouseEnter(object sender, EventArgs e)
		{
			pictureBox6.BackgroundImage = Properties.Resources.Updata_dll_2;
		}

		//新版本更新功能 鼠标离开
		private void pictureBox6_MouseLeave(object sender, EventArgs e)
		{
			pictureBox6.BackgroundImage = Properties.Resources.Updata_dll_1;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
		}

		//新版本帮助助手
		private void pictureBox7_Click(object sender, EventArgs e)
		{
			//MessageBox.Show("未开发完成");
		}

		//新版本帮助助手 鼠标进入
		private void pictureBox7_MouseEnter(object sender, EventArgs e)
		{
			pictureBox7.BackgroundImage = Properties.Resources.Helper_2;
		}

		//新版本帮助助手 鼠标离开
		private void pictureBox7_MouseLeave(object sender, EventArgs e)
		{
			pictureBox7.BackgroundImage = Properties.Resources.Helper_1;
		}

		//新版本文件查缺
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (panel_ui != 3)
			{
				APP_File_Find = new Use_Form.File_Find();
				panel1.Controls.Clear();
				APP_File_Find.Size = panel1.Size;
				panel1.Controls.Add(APP_File_Find);
				panel_ui = 3;
			}
		}

		//新版本文件查缺 鼠标进入
		private void pictureBox1_MouseEnter(object sender, EventArgs e)
		{
			pictureBox1.BackgroundImage = Properties.Resources.File_Find_2;
		}

		//新版本文件查缺 鼠标离开
		private void pictureBox1_MouseLeave(object sender, EventArgs e)
		{
			pictureBox1.BackgroundImage = Properties.Resources.File_Find_1;
		}

		//新版本可视化菜单
		private void pictureBox8_Click(object sender, EventArgs e)
		{
			View_Edit view_Edit = new View_Edit();
			view_Edit.ShowDialog();
		}

		//新版本可视化菜单 鼠标进入
		private void pictureBox8_MouseEnter(object sender, EventArgs e)
		{
			pictureBox8.BackgroundImage = Properties.Resources.View_Menu_2;
		}

		//新版本可视化菜单 鼠标离开
		private void pictureBox8_MouseLeave(object sender, EventArgs e)
		{
			pictureBox8.BackgroundImage = Properties.Resources.View_Menu_1;
		}

		//当用户改变窗体大小时
		private void Form_main_SizeChanged(object sender, EventArgs e)
		{
			//pane（779, 477），主窗体（960, 540）
			APP_License_switching.Size = panel1.Size;
			APP_File_Find.Size = panel1.Size;
			APP_Menu_Edit.Size = panel1.Size;
			APP_Updata_DLL.Size = panel1.Size;
			APP_Use_set.Size = panel1.Size;
			APP_Improving_Tool.Size = panel1.Size;
			APP_Environment_Variable_v2.Size = panel1.Size;
		}

		//窗体关闭后，
		private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
		{

		}

		//提效工具进入
		private void pictureBox9_MouseEnter(object sender, EventArgs e)
		{
			pictureBox9.BackgroundImage = Properties.Resources.Improving_Tool_2;
		}

		//提效工具离开
		private void pictureBox9_MouseLeave(object sender, EventArgs e)
		{
			pictureBox9.BackgroundImage = Properties.Resources.Improving_Tool_1;
		}

		//提效工具
		private void pictureBox9_Click(object sender, EventArgs e)
		{
			if (panel_ui != 7)
			{
				APP_Improving_Tool.Show();
				panel1.Controls.Clear();
				APP_Improving_Tool.Size = panel1.Size;
				panel1.Controls.Add(APP_Improving_Tool);
				panel_ui = 7;
			}
		}

		//环境变量
		private void pictureBox10_Click(object sender, EventArgs e)
		{
			if (panel_ui != 8)
			{
				panel1.Controls.Clear();
				APP_Environment_Variable_v2.Size = panel1.Size;
				panel1.Controls.Add(APP_Environment_Variable_v2);
				panel_ui = 8;
			}
		}

		//环境变量-动画
		private void pictureBox10_MouseEnter(object sender, EventArgs e)
		{
			pictureBox10.BackgroundImage = Properties.Resources.Environment_Variable_2;
		}

		//环境变量-动画
		private void pictureBox10_MouseLeave(object sender, EventArgs e)
		{
			pictureBox10.BackgroundImage = Properties.Resources.Environment_Variable_1;
		}

		//通知图标 显示窗体
		private void Show_ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Visible = true;
		}

		//通知图标 退出
		private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		//双击组件
		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			this.Visible = true;
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_main_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		/// <summary>
		/// 主程序退出前
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
		{
			//如果是最大化关闭的，则不记录位置
			if ((this.Location.X > 0) && (this.Location.Y > 0) && (this.Location.X < 1920) && (this.Location.Y < 1080))
			{
				Properties.Settings.Default.form = (Size)this.Location;
				Properties.Settings.Default.Save();
			}
			Arong_Log.Oper_Log("终止服务，退出进程++++++++++++++++++++++++++++++++++++++");
		}
	}
}
