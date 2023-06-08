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
	public partial class Nx_Path_2 : Skin_DevExpress
	{
		public Nx_Path_2()
		{
			InitializeComponent();
			this.BackColor = Properties.Settings.Default.Tools_color;
			Arong_Log.Oper_Log("Nx_Path_2窗体初始化完成");
			label3.Text = Properties.Settings.Default.files_path;
		}

		//主窗口
		private void Nx_Path_2_Load(object sender, EventArgs e)
		{
			//读取配置文件，获得所有路径名称
			string[] temp = Arong_Core.Arong_File.Nx_Load();
			//读取配置文件，获得选中项
			string[] index = Arong_Core.Arong_File.Nx_Load_Using();
			//将用户写入的数据添加到列表视图内
			for (int i = 0; i < temp.Length; i++)
			{
				Box1.Items.Add(temp[i]);
			}

			//将用户上一次选择的值恢复
			for (int i = 0; i < index.Length; i++)
			{
				//如果当前的选中项比现在的少，则忽略
				if (int.Parse(index[i]) < temp.Length)
				{
					Box1.SetItemChecked(int.Parse(index[i]), true);
				}
			}
		}

		//关闭窗体前发生
		private void Nx_Path_2_FormClosing(object sender, FormClosingEventArgs e)
		{
			//清空内容 且把文件记录
			Arong_Core.Arong_File.File_String_Del(Arong_Path.Nx_Path_2_path);
			Arong_Core.Arong_File.File_String_Del(Arong_Path.Nx_Path_2_index);
			for (int i = 0; i < Box1.Items.Count; i++)
			{
				if (Box1.GetItemChecked(i))
				{
					File.AppendAllText(Arong_Path.Nx_Path_2_path, Box1.Items[i].ToString() + "\n");
					File.AppendAllText(Arong_Path.Nx_Path_2_index, i.ToString() + "\n");
				}
			}
		}

		//路径配置
		private void button1_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Arong_Path.Nx_Path_2_editpath);
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Nx_Path_2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				//清空内容 且把文件记录
				Arong_Core.Arong_File.File_String_Del(Arong_Path.Nx_Path_2_path);
				Arong_Core.Arong_File.File_String_Del(Arong_Path.Nx_Path_2_index);
				for (int i = 0; i < Box1.Items.Count; i++)
				{
					if (Box1.GetItemChecked(i))
					{
						File.AppendAllText(Arong_Path.Nx_Path_2_path, Box1.Items[i].ToString() + "\n");
						File.AppendAllText(Arong_Path.Nx_Path_2_index, i.ToString() + "\n");
					}
				}
				//关闭窗体
				Close();
			}
		}

		/// <summary>
		/// 设置默认加载路径
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void xToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Box1.SelectedItem!=null)
			{
				label3.Text = Box1.SelectedItem.ToString();

				//保存主路径
				Properties.Settings.Default.files_path = label3.Text;
				Properties.Settings.Default.Save();
			}
		}
	}
}
