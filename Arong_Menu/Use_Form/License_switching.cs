using Arong_Core;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CCWin.Win32.Const;

namespace Arong_Menu
{
	public partial class License_switching : UserControl
	{
		public License_switching()
		{
			InitializeComponent();
			Arong_Log.Oper_Log("许可切换-模块加载成功");

			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;

			//显示变更的路径
			label2.Text = Properties.Settings.Default.files_path;
		}

		// 创建FlowLayoutPanel控件
		FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();

		/// <summary>
		/// 主窗口
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void License_switching_Load(object sender, EventArgs e)
		{
			//显示当前使用的许可名称
			label3.Text = Properties.Settings.Default.use;
			string files_path = Properties.Settings.Default.files_path;
			string licpath = Arong_Path.Lic + "\\";
			DirectoryInfo di = new DirectoryInfo(licpath);
			FileInfo[] f = di.GetFiles();
			//循环输出内容
			listBox1.Items.Clear();
			for (int i = 0; i < f.Length; i++)
			{
				listBox1.Items.Add(f[i].ToString().Replace(".viclic", ""));
			}

			//获取当前设置的nx版本
			string path = Arong_New.Arong_str() + "\\Data\\Nx\\Nx_Exe_Path.ini";
			string[] nxexe = File.ReadAllLines(path);

			if (nxexe.Length>0)
			{
				flowLayoutPanel1.Dock = DockStyle.Fill;
				flowLayoutPanel1.Padding = new Padding(18, 3, 0, 3);
				// 将FlwoLayoutPanel控件加入GroupBox中
				groupBox5.Controls.Add(flowLayoutPanel1);

				//获得nx图标
				Image ico = Icon.ExtractAssociatedIcon(Arong_File.Data_Eq_end(nxexe[0])).ToBitmap();
				Bitmap bitmap = (Bitmap)ico;
				Bitmap resizedBitmap = new Bitmap(bitmap, new Size(16, 16));

				//添加
				for (int i = 0; i < nxexe.Length; i++)
				{
					Button bn = new Button() 
					{
						BackgroundImage = resizedBitmap,
						BackgroundImageLayout = ImageLayout.None,
						Size = new Size(120, 25),
						ImageAlign = ContentAlignment.MiddleLeft,
						Name = Arong_File.Data_Eq_front(nxexe[i]),
						Text = Arong_File.Data_Eq_front(nxexe[i]),
						AutoSize = true,
						Tag = Arong_File.Data_Eq_end(nxexe[i]),
						Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))),
						Cursor = System.Windows.Forms.Cursors.Hand,
						UseVisualStyleBackColor = true,
					};
					bn.Click += new EventHandler(Button_C);
					flowLayoutPanel1.Controls.Add(bn);
				}
			}
		}

		/// <summary>
		/// 点击启动nx
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Button_C(object sender,EventArgs e)
		{
			Button bn = (Button)sender;
			System.Diagnostics.Process.Start(bn.Tag.ToString());
		}

		/// <summary>
		/// 结束NX进程
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("ugraf");
			foreach (System.Diagnostics.Process p in process)
			{
				p.Kill();
			}
		}

		/// <summary>
		/// 列表视图
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.files_path == "C:\\")
			{
				MessageBox.Show("未指定要切换的许可路径，无法切换许可");
			}
			else if (listBox1.SelectedItem != null)
			{
				//显示当前选择的许可
				label3.Text = listBox1.Text;
				//将属性赋值
				Properties.Settings.Default.use = listBox1.Text;
				//存入记忆
				Properties.Settings.Default.Save();
				//拷贝
				Arong_Re.Re(Properties.Settings.Default.files_path, Properties.Settings.Default.use);
			}
		}

		//启动NX
		private void button1_Click(object sender, EventArgs e)
		{
			Nx_Path nx_Path = new Nx_Path();
			nx_Path.Show();

			//foreach (System.Windows.Forms.RadioButton rb in flowLayoutPanel1.Controls.OfType<System.Windows.Forms.RadioButton>())
			//{
			//	if (rb.Checked)
			//	{
			//		System.Diagnostics.Process.Start(rb.Tag.ToString());
			//	}
			//}
		}

		//打开许可文件夹
		private void button2_Click_1(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("explorer.exe", Arong_Path.Lic);
		}

		//加载路径
		private void button4_Click(object sender, EventArgs e)
		{
			Nx_Path_2 nx_Path_2 = new Nx_Path_2();
			nx_Path_2.Show();
		}

		//气泡
		private void toolTip1_Popup(object sender, PopupEventArgs e)
		{

		}

		//客户路径
		private void button7_Click(object sender, EventArgs e)
		{
			string path = Properties.Settings.Default.files_path + "\\customer";
			System.Diagnostics.Process.Start("explorer.exe", path);
		}

		//维特文件夹
		private void button6_Click(object sender, EventArgs e)
		{
			string path = Properties.Settings.Default.files_path;
			System.Diagnostics.Process.Start("explorer.exe", path);
		}
	}
}
