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
	public partial class Form_updata_dll : Skin_DevExpress
	{
		public Form_updata_dll()
		{
			InitializeComponent();

			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;

			textBox1.Text = Properties.Settings.Default.nx_dll_path;
			//下面是关于按钮控件的记忆
			checkBox1.Checked = Properties.Settings.Default.nx75;
			checkBox2.Checked = Properties.Settings.Default.nx8;
			checkBox3.Checked = Properties.Settings.Default.nx85;
			checkBox4.Checked = Properties.Settings.Default.nx9;
			checkBox5.Checked = Properties.Settings.Default.nx10;
			checkBox6.Checked = Properties.Settings.Default.nx11;
			checkBox7.Checked = Properties.Settings.Default.nx12;
			checkBox8.Checked = Properties.Settings.Default.nx1847;
			checkBox9.Checked = Properties.Settings.Default.nx1872;
			checkBox10.Checked = Properties.Settings.Default.nx1899;
			checkBox11.Checked = Properties.Settings.Default.nx1926;
			checkBox12.Checked = Properties.Settings.Default.nx1953;
			checkBox13.Checked = Properties.Settings.Default.nx1980;
			checkBox14.Checked = Properties.Settings.Default.nx2007;
			checkBox15.Checked = Properties.Settings.Default.nx_x32;
			checkBox16.Checked = Properties.Settings.Default.nx_x64;
			checkBox17.Checked = Properties.Settings.Default.nx_dll;
			checkBox18.Checked = Properties.Settings.Default.nx_dlx;
			checkBox19.Checked = Properties.Settings.Default.nx_bmp;
			checkBox21.Checked = Properties.Settings.Default.nx_lng;
			checkBox22.Checked = Properties.Settings.Default.nx_men;

			Arong_Log.Oper_Log("Form_updata_dll窗体初始化完成");
		}

		//主窗口
		private void Form_updata_dll_Load(object sender, EventArgs e)
		{
			//以下是关于基准版本选择与记忆的逻辑
			comboBox1.Items.Clear();
			string[] std = Arong_File.File_Nx_Ver();
			for (int i = 0;i < std.Length;i++)
			{
				comboBox1.Items.Add(std[i]);
			}
			int lis = 0;
			for (int i = 0; i < std.Length; i++)
			{
				if (comboBox1.Items[i].Equals(Properties.Settings.Default.nx_ver_std))
				{
					lis = i;
				}
			}
			comboBox1.SelectedIndex = lis;

            //路径对应
            Properties.Settings.Default.nx_dll_path_sta = Properties.Settings.Default.files_path + Arong_Core.Arong_File.NX_DLL_VER("NX10", "x64");

        }

        //路径输入框
        private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx_dll_path = textBox1.Text;
			Properties.Settings.Default.Save();
		}

		//x64
		private void checkBox16_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx_x64 = checkBox16.Checked;
			Properties.Settings.Default.Save();
		}

		//x32
		private void checkBox15_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx_x32 = checkBox15.Checked;
			Properties.Settings.Default.Save();
		}

		//nx75
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx75 = checkBox1.Checked;
			Properties.Settings.Default.Save();
		}

		//nx8
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx8 = checkBox2.Checked;
			Properties.Settings.Default.Save();
		}

		//nx85
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx85 = checkBox3.Checked;
			Properties.Settings.Default.Save();
		}

		//nx9
		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx9 = checkBox4.Checked;
			Properties.Settings.Default.Save();
		}

		//nx10
		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx10 = checkBox5.Checked;
			Properties.Settings.Default.Save();
		}

		//nx11
		private void checkBox6_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx11 = checkBox6.Checked;
			Properties.Settings.Default.Save();
		}

		//nx12
		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx12 = checkBox7.Checked;
			Properties.Settings.Default.Save();
		}

		//nx1847
		private void checkBox8_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx1847 = checkBox8.Checked;
			Properties.Settings.Default.Save();
		}

		//nx1872
		private void checkBox9_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx1872 = checkBox9.Checked;
			Properties.Settings.Default.Save();
		}

		//nx1899
		private void checkBox10_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx1899 = checkBox10.Checked;
			Properties.Settings.Default.Save();
		}

		//nx1926
		private void checkBox11_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx1926 = checkBox11.Checked;
			Properties.Settings.Default.Save();
		}

		//nx1953
		private void checkBox12_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx1953 = checkBox12.Checked;
			Properties.Settings.Default.Save();
		}

		//nx1980
		private void checkBox13_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx1980 = checkBox13.Checked;
			Properties.Settings.Default.Save();
		}

		//nx2007
		private void checkBox14_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx2007 = checkBox14.Checked;
			Properties.Settings.Default.Save();
		}

		//dll主程序
		private void checkBox17_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx_dll = checkBox17.Checked;
			Properties.Settings.Default.Save();
		}

		//dlx
		private void checkBox18_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx_dlx = checkBox18.Checked;
			Properties.Settings.Default.Save();
		}

		//bmp
		private void checkBox19_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx_bmp = checkBox19.Checked;
			Properties.Settings.Default.Save();
		}

		//基准版本
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx_ver_std = comboBox1.Text;
			Properties.Settings.Default.Save();
		}

		//翻译文件
		private void checkBox21_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx_lng = checkBox21.Checked;
			Properties.Settings.Default.Save();
		}

		//菜单文件
		private void checkBox22_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.nx_men = checkBox22.Checked;
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// 按esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_updata_dll_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
