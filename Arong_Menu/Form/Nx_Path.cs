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
	public partial class Nx_Path : Skin_DevExpress
	{
		public Nx_Path()
		{
			InitializeComponent();

			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;
			string path = Properties.Settings.Default.nx_path;
			Arong_Log.Oper_Log("Nx_Path窗体初始化完成");
		}

		private void Nx_Path_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 打开后台文件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			string path = Arong_New.Arong_str() + "\\Data\\Nx\\Nx_Exe_Path.ini";
			System.Diagnostics.Process.Start(@path);
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Nx_Path_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
