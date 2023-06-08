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

namespace Arong_Menu
{
	public partial class Improving_Tool : UserControl
	{
		public Improving_Tool()
		{
			InitializeComponent();
			Arong_Log.Oper_Log("提效小工具-模块加载成功");
			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;
		}

		//批量名称替换
		private void button1_Click(object sender, EventArgs e)
		{
			Bat.Form1 form1 = new Bat.Form1();
			form1.Show();
		}

		//复制文件并保留文件夹结构
		private void button2_Click(object sender, EventArgs e)
		{
			Custom_updata custom_Updata = new Custom_updata();
			custom_Updata.Show();
		}

		private void Improving_Tool_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 设定文件最新时间
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			Time_Set time_Set = new Time_Set();
			time_Set.Show();
		}

		/// <summary>
		/// 位图测试工具
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button4_Click(object sender, EventArgs e)
		{
			Icon_Assistant icon_Assistant = new Icon_Assistant();
			icon_Assistant.Show();
		}

		/// <summary>
		/// 功能测试工具
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button5_Click(object sender, EventArgs e)
		{
			AutoDebuging autoDebuging = new AutoDebuging();
			autoDebuging.Show();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Main_Menu_Split main_Menu_Split = new Main_Menu_Split();
			main_Menu_Split.Show();
		}
	}
}
