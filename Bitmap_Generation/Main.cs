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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bitmap_Generation
{
	public partial class Main : Form
	{
		Point Bp = new Point();
		PointF Fontp = new PointF();
		string temp = "";
		Bitmap oupbitmap;

		public Main()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 生成
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			if (listBox1.Items.Count != 0)
			{
				if (!Directory.Exists(textBox6.Text))
				{
					MessageBox.Show("路径不合法或者为空");
				}
				else
				{
					if (radioButton1.Checked == true)
					{
						oupbitmap.Save(textBox6.Text + "\\" + textBox1.Text + ".lc.bmp", ImageFormat.Bmp);
						oupbitmap.Dispose();
					}
					else
					{
						string filename = Path.GetFileNameWithoutExtension(listBox1.Items[listBox1.SelectedIndex].ToString());
						oupbitmap.Save(textBox6.Text + "\\" + filename + ".lc.bmp", ImageFormat.Bmp);
						oupbitmap.Dispose();
					}
				}
			}

			//有内容的话 选中向下移动
			if (listBox1.SelectedIndex != -1)
			{
				//listBox1.Items.Remove(listBox1.SelectedItem);
				if (listBox1.SelectedIndex < listBox1.Items.Count -1)
				{
					listBox1.SelectedIndex++;
				}
			}

			//清空字符串
			textBox1.Text = "";
		}

		Rectangle rectangle;
		Font font;

		/// <summary>
		/// 将文字与位图合成一个并返回一个新的位图
		/// </summary>
		/// <param name="text">文字</param>
		/// <param name="smallicon">小图标</param>
		/// <returns></returns>
		private Bitmap GenerateBitmap(string text,Bitmap smallicon)
		{
			//创建一个字体和矩形

			if (textBox8.Text != "")
			{
				font = new Font("宋体", int.Parse(textBox8.Text));
			}

			
			SolidBrush brush = new SolidBrush(Color.Black);

			if (textBox7.Text != "")
			{
				rectangle = new Rectangle(0, 0, int.Parse(textBox7.Text), int.Parse(textBox7.Text));
			}

			StringFormat stringFormat = new StringFormat {Alignment = StringAlignment.Center,};

			//创建一个新的位图
			Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);

			//使用 Graphics 类将文本渲染到位图上
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.White);
				if (textBox9.Text != "")
				{
					graphics.DrawImage(ResizeBitmap(smallicon, int.Parse(textBox9.Text), int.Parse(textBox9.Text)), Bp);
					graphics.DrawString(text, font, brush, Fontp, stringFormat);
				}
			}

			//保存 BMP 文件
			//bitmap.Save(outputBmpFile,ImageFormat.Bmp);

			//释放资源
			//bitmap.Dispose();
			//font.Dispose();
			//brush.Dispose();

			oupbitmap = new Bitmap(bitmap,bitmap.Width, bitmap.Height);
			oupbitmap = ConvertWhiteToTransparent(oupbitmap, 3);

			return bitmap;
		}

		/// <summary>
		/// 窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			textBox6.Text = Properties.Settings.Default.textBox6;
			radioButton1.Checked = Properties.Settings.Default.radioButton1;
			radioButton2.Checked = Properties.Settings.Default.radioButton2;
		}

		/// <summary>
		/// 用于刷新图像
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, EventArgs e)
		{
			Properties.Settings.Default.Save();
			//位图位置控制
			if ((textBox5.Text.Length != 0) && (textBox4.Text.Length != 0))
			{
				Bp.X = int.Parse(textBox5.Text);
				Bp.Y = int.Parse(textBox4.Text);
			}

			//字体位置控制
			if ((textBox2.Text.Length != 0) && (textBox3.Text.Length != 0))
			{
				Fontp.X = int.Parse(textBox2.Text);
				if (textBox1.Text.Length >= 4)
				{
					Fontp.Y = int.Parse(textBox3.Text);
				}
				else
				{
					//小于四个字时默认把这个字体向下放
					Fontp.Y = int.Parse(textBox3.Text) + 11;
				}
			}

			if (listBox1.Items.Count != 0)
			{
				if (listBox1.SelectedIndex == -1)
				{
					listBox1.SelectedIndex = 0;
				}
				pictureBox1.BackgroundImage = Image.FromFile(listBox1.Items[listBox1.SelectedIndex].ToString());

				switch (textBox1.Text.Length)
				{
					case 2: { temp = textBox1.Text.Insert(1, " "); }; break;
					case 3: { temp = textBox1.Text; }; break;
					case 4: { temp = textBox1.Text.Insert(1, " "); temp = temp.Insert(3, "\n"); temp = temp.Insert(5, " "); }; break;
					case 5: { temp = textBox1.Text.Insert(1, " "); temp = temp.Insert(3, "\n"); }; break;
					case 6: { temp = textBox1.Text.Insert(3, "\n"); }; break;
					case 7: { temp = textBox1.Text.Insert(3, "\n"); }; break;
					case 8: { temp = textBox1.Text.Insert(4, "\n"); }; break;
					default: { temp = ""; };break;
				}

				pictureBox2.BackgroundImage = GenerateBitmap(temp,(Bitmap)Bitmap.FromFile(listBox1.Items[listBox1.SelectedIndex].ToString()));
				pictureBox3.BackgroundImage = new Bitmap(pictureBox2.BackgroundImage,new Size(96,96));
			}
			GC.Collect();
		}

		/// <summary>
		/// 将位图拖入
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listBox1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

				for (int i =0;i < files.Length;i++)
				{
					listBox1.Items.Add(files[i]);
				}
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

		/// <summary>
		/// 传入一个bitmap文件，将所有白色识别为透明色
		/// </summary>
		/// <param name="image"></param>
		/// <returns></returns>
		public static Bitmap ConvertWhiteToTransparent(Bitmap image, int errorvalue)
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
		/// 生成路径
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox6_TextChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.textBox6 = textBox6.Text;
		}

		#region 按字符串与 按原始

		/// <summary>
		/// 按字符串
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.radioButton2 = radioButton2.Checked;
			Properties.Settings.Default.radioButton1 = radioButton1.Checked;
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// 按原始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.radioButton1 = radioButton1.Checked;
			Properties.Settings.Default.radioButton2 = radioButton2.Checked;
			Properties.Settings.Default.Save();
		}

		#endregion

		/// <summary>
		/// 回车生成
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Main_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				// 调用按钮的点击事件
				if (textBox1.Text.Length >= 2)
				{
					button1.PerformClick();
				}
			}
		}

		/// <summary>
		/// 禁止输入非数字键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		/// <summary>
		/// 缩放位图后不模糊
		/// </summary>
		/// <param name="sourceBitmap"></param>
		/// <param name="newWidth"></param>
		/// <param name="newHeight"></param>
		/// <returns></returns>
		private Bitmap ResizeBitmap(Bitmap sourceBitmap, int newWidth, int newHeight)
		{
			Bitmap resizedBitmap = new Bitmap(newWidth, newHeight);

			using (Graphics g = Graphics.FromImage(resizedBitmap))
			{
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

				g.DrawImage(sourceBitmap, new Rectangle(0, 0, newWidth, newHeight));
			}
			return resizedBitmap;
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
