using Arong_Core;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arong_Menu
{
	public partial class Environment_Variable_v2 : UserControl
	{
		public Environment_Variable_v2()
		{
			InitializeComponent();
			Arong_Log.Oper_Log("环境变量-模块加载成功");
			//显示用户设置的背景色
			this.BackColor = Properties.Settings.Default.Tools_color;
		}

		//更新环境变量
		private void button1_Click(object sender, EventArgs e)
		{
			//写入启动项
			string path = Arong_Core.Arong_New.Arong_str() + "\\EV\\";
			string path3 = Arong_Core.Arong_New.Arong_str() + "\\EV\\EV_sum.ini";
			Arong_File.File_String_Del(path3);

			int s = 0;
			//将选定项写入文件 记忆sum
			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				if (checkedListBox1.GetItemChecked(i))
				{
					File.AppendAllText(path3, i.ToString() + "\n");
					s++;
				}
			}

			//环境变更操作
			string[] evname = new string[s];
			s = 0;

			//得到当前选中的所有名称
			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				if (checkedListBox1.GetItemChecked(i))
				{
					evname[s] = checkedListBox1.Items[i].ToString();
					s++;
				}
			}

			//向注册表写入环境变量
			//多线程执行
			Task.Run(() =>
			{
				string eu = "";
				string name = "";
				string index = "";
				for (int i = 0; i < s; i++)
				{
					evname[i] = path + evname[i].Replace(".EV", ".EU");
					eu = File.ReadAllText(evname[i]);
					name = Arong_File.Data_Eq_front(eu);
					index = Arong_File.Data_Eq_end(eu);
					Arong_Re.Environment_Variable_v2(name, index, 1);
				}
				MessageBox.Show("环境变量更新完成");
				Arong_Log.Oper_Log("环境变量更新完成");
			});
		}

		//环境变量 生成
		private void button2_Click(object sender, EventArgs e)
		{
			string path = Arong_New.Arong_str() + "\\EV\\" + textBox1.Text + ".EV";
			if ((textBox1.Text != "") && (textBox2.Text != "") && (richTextBox1.Text != ""))
			{
				if (File.Exists(path))
				{
					DialogResult dr = MessageBox.Show("当前环境变量已经存在，再生成则会覆盖，如果不需要覆盖，请更换其他名称", "信息", MessageBoxButtons.YesNo);
					if (dr == DialogResult.Yes)
					{
						File.WriteAllText(path, textBox2.Text + "\n");
						File.AppendAllText(path, richTextBox1.Text);
						textBox1.Text = "";
						textBox2.Text = "";
						richTextBox1.Text = "";
						Environment_Variable_v2_Load(this, null);
					}
				}
				else
				{
					File.WriteAllText(path, textBox2.Text + "\n");
					File.AppendAllText(path, richTextBox1.Text);
					textBox1.Text = "";
					textBox2.Text = "";
					richTextBox1.Text = "";
					Environment_Variable_v2_Load(this, null);
				}
			}
			else
			{
				MessageBox.Show("创建列表中有一项是空的");
			}

			Arong_Log.Oper_Log("环境变量生成完成");
		}

		//选择环境变量的值
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (checkedListBox1.Items.Count != 0)
			{
				//先写入缓存
				string path2 = Arong_Core.Arong_New.Arong_str() + "\\EV\\" + checkedListBox1.SelectedItem.ToString().Replace(".EV", ".EINI");
				string evinfo = Arong_Core.Arong_New.Arong_str() + "\\EV\\" + checkedListBox1.SelectedItem.ToString().Replace(".EV", ".EU");
				string evname = Arong_Core.Arong_New.Arong_str() + "\\EV\\" + checkedListBox1.SelectedItem.ToString();
				if (checkedListBox1.SelectedItem != null)
				{
					//判断文件是否存在，存在则删除
					if ((File.Exists(path2)) && (File.Exists(evinfo)))
					{
						File.Delete(path2);
						File.Delete(evinfo);
					}
					//将当前选择的文件写入
					File.AppendAllText(path2, comboBox1.Text);

					//获得选中列表中的真实环境变量名称
					string[] ev = File.ReadAllLines(evname);
					File.AppendAllText(evinfo, ev[0].ToString() + "=" + comboBox1.Text);
				}
			}
			Arong_Log.Oper_Log("选择环境变量的值完成");
		}

		//环境名称 列表视图
		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string path1 = Arong_Core.Arong_New.Arong_str() + "\\EV\\";
			string[] name = Directory.GetFiles(path1, "*.EV", SearchOption.TopDirectoryOnly);
			string[] names = new string[name.Length];
			string[] value;
			string path2;

			//当用户选择列表时
			if (checkedListBox1.SelectedItem != null)
			{
				//清空下拉框
				comboBox1.Items.Clear();
				//
				for (int i = 0; i < name.Length; i++)
				{
					//将路径去除
					names[i] = name[i].Replace(path1, "");
					if (checkedListBox1.SelectedItem.ToString() == names[i].ToString())
					{
						value = File.ReadAllLines(name[i]);
						//添加下拉框的值
						for (int j = 1; j < value.Length; j++)
						{
							//判断是否有多余空格，有的话移除
							if (value[j] != "")
							{
								comboBox1.Items.Add(value[j]);
							}
						}

						string ini;
						//如果之前选择过，那么把缓存的文件读出来，是指下拉列表
						path2 = Arong_Core.Arong_New.Arong_str() + "\\EV\\" + checkedListBox1.SelectedItem.ToString().Replace(".EV", ".EINI");
						if (File.Exists(path2))
						{
							for (int a = 0; a < comboBox1.Items.Count; a++)
							{
								ini = File.ReadAllText(path2);
								if (ini == comboBox1.Items[a].ToString())
								{
									comboBox1.SelectedIndex = a;
								}
							}
						}
					}
				}
			}
		}

		//主窗口循环
		private void Environment_Variable_v2_Load(object sender, EventArgs e)
		{
			string path1 = Arong_Core.Arong_New.Arong_str() + "\\EV\\";
			string path2 = Arong_Core.Arong_New.Arong_str() + "\\EV\\EV.ini";
			string path3 = Arong_Core.Arong_New.Arong_str() + "\\EV\\EV_sum.ini";

			if (Directory.Exists(path1) == false)
			{
				Directory.CreateDirectory(path1);
			}

			//清空所有列表
			checkedListBox1.Items.Clear();
			string[] name = Directory.GetFiles(path1, "*.EV*", SearchOption.TopDirectoryOnly);

			//添加文件名到窗口
			for (int i = 0; i < name.Length; i++)
			{
				//移除路径并添加到窗口
				name[i] = name[i].Replace(path1, "");
				checkedListBox1.Items.Add(name[i]);
			}

			//如果是经历了移除变量后进入这个的
			if (File.Exists(path3) == false)
			{
				File.WriteAllText(path3, "");
			}
			string[] index = File.ReadAllLines(path3);
			//将用户上一次选择的值恢复
			for (int i = 0; i < index.Length; i++)
			{
				checkedListBox1.SetItemChecked(int.Parse(index[i]), true);
			}
		}

		//移除变量
		private void button3_Click(object sender, EventArgs e)
		{
			if (checkedListBox1.SelectedItem != null)
			{
				DialogResult dr = MessageBox.Show("当前要移除的变量是" + checkedListBox1.SelectedItem + "，您确认要移除吗？", "信息", MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{
					//当前使用的EV文件
					string delname = Arong_New.Arong_str() + "\\EV\\" + checkedListBox1.SelectedItem.ToString();
					//当前使用的EINI文件
					string delnames = Arong_New.Arong_str() + "\\EV\\" + checkedListBox1.SelectedItem.ToString().Replace(".EV", ".EINI");
					string evinfo = Arong_Core.Arong_New.Arong_str() + "\\EV\\" + checkedListBox1.SelectedItem.ToString().Replace(".EV", ".EU");
					//写入启动项
					string path3 = Arong_Core.Arong_New.Arong_str() + "\\EV\\EV_sum.ini";

					File.Delete(delname);
					File.Delete(delnames);
					File.Delete(evinfo);
					//移除选定的项的信息
					File.Delete(path3);

					//删除创建的文件
					checkedListBox1.SelectedItems.Remove(checkedListBox1.SelectedItem);
					Environment_Variable_v2_Load(this, null);
					MessageBox.Show("完成");
				}
			}
			else
			{
				MessageBox.Show("当前没有选中列表框内的项，无法移除");
			}
			Arong_Log.Oper_Log("移除变量完成");
		}

		//显示名称-创建
		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		//环境变量名称-创建
		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		//文本编辑框
		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
