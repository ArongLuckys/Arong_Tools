using CCWin;
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

namespace Arong_Menu
{
	public partial class Main_Menu_Split : Skin_DevExpress
	{
		public Main_Menu_Split()
		{
			InitializeComponent();
			this.BackColor = Properties.Settings.Default.Tools_color;
		}

		/// <summary>
		/// 拆分
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			string path = textBox1.Text;
			string main = "\\cad_main_menu.men";
			if (path != "")
			{
				string filename = textBox1.Text + "\\extrace_split";
				if (Directory.Exists(filename))
				{
					Directory.Delete(filename, true);
				}
				Directory.CreateDirectory(filename);
				List<string> value = new List<string>();
				value.AddRange(File.ReadAllLines(path + main,Encoding.GetEncoding("gb2312")));

				List<string> ReValue = new List<string>();
				//移除多余空行
				foreach (string line in value)
				{
					if (line != "")
					{
						ReValue.Add(line.TrimStart());
					}
				}
				value.Clear();
				foreach (string line in ReValue)
				{
					if ((line.StartsWith("BUTTON")) || (line.StartsWith("BITMAP")) || (line.StartsWith("ACTIONS")) || (line.StartsWith("LABEL")))
					{
						value.Add(line);
					}
				}
				//创建文件
			}
		}
	}
}
