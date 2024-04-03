using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arong_Menu
{
	public partial class Ico_Quickly_Transparent : Skin_DevExpress
	{
		public Ico_Quickly_Transparent()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 启动操作
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Ico_Quickly_Transparent_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 将这个鼠标内的全部数据传输到listbox内
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listBox1_DragEnter(object sender, DragEventArgs e)
		{
			//接收文件
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				for (int i = 0; i < files.Length; i++)
				{
					//含有小数点的数据视为文件
					if (files[i].ToString().IndexOf(".") != -1)
					{
						listBox1.Items.Add(files[i]);
					}
					//拖入的是文件夹，则拷贝文件夹下所有文件
					if (Directory.Exists(files[i]) == true)
					{
						//用于接收文件夹内全部文件
						string[] filetemp = Directory.GetFiles(files[i], "*", SearchOption.AllDirectories);
						for (int f = 0; f < filetemp.Length; f++)
						{
							listBox1.Items.Add(filetemp[f]);
						}
					}
				}
			}
		}

		/// <summary>
		/// 导出图片为透明色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < listBox1.Items.Count; i++)
			{
				string newfile = Path.GetDirectoryName(listBox1.Items[i].ToString()) + "\\_Bmp\\" + Path.GetFileName(listBox1.Items[i].ToString());
				if (!Directory.Exists(Path.GetDirectoryName(listBox1.Items[i].ToString()) + "\\_Bmp\\"))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(listBox1.Items[i].ToString()) + "\\_Bmp");
				}
				ConvertWhiteToTransparent((Bitmap)Bitmap.FromFile(listBox1.Items[i].ToString()),int.Parse(textBox1.Text)).Save(newfile, ImageFormat.Bmp);
			}
			MessageBox.Show("完成");
		}

		/// <summary>
		/// 传入一个bitmap文件，将所有白色识别为透明色
		/// </summary>
		/// <param name="image"></param>
		/// <returns></returns>
		public static Bitmap ConvertWhiteToTransparent(Bitmap image,int errorvalue)
		{
			Bitmap result = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
			int value = 255 - errorvalue;
			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Height; y++)
				{
					Color pixel = image.GetPixel(x, y);
					if ((pixel.R >= value) && (pixel.G >= value) && (pixel.B >= value))
					{
						result.SetPixel(x, y, Color.Transparent);
					}
					else
					{
						result.SetPixel(x, y, pixel);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Ico_Quickly_Transparent_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		/// <summary>
		/// 清空
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
		}
	}
}
