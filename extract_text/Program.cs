using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace extract_text
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("该功能会将men文件内的数据格式拆分，请保证men文件在同级目录内");
			Console.WriteLine("键入1将直接执行,键入0将删除生成的文件");

			string path = Environment.CurrentDirectory + "\\cad_main_menu.men";
			string extract = Environment.CurrentDirectory + "\\extract";

			string off = Console.ReadLine();
			if (off == "1")
			{
				Directory.CreateDirectory(extract);
				string[] file = File.ReadAllLines(path, Encoding.GetEncoding("gb2312"));
				int a = 0;
				for (int i = 0; i < file.Length; i++)
				{
					if (file[i] != "")
					{
						if (file[i].Substring(0, 2) != "!+")
						{
							if (file[i].Substring(0, 1) == "!")
							{
								if (file[i + 1].Substring(0, 2) == "\tB")
								{
									a++;
									Console.WriteLine(file[i]);
									Console.WriteLine(file[i + 1]);
									Console.WriteLine(file[i + 2]);
									Console.WriteLine(file[i + 3]);
									Console.WriteLine(file[i + 4]);

									string filename = file[i].Substring(1);
									File.AppendAllText(extract + "\\" + filename + ".txt", file[i] + "\n");
									File.AppendAllText(extract + "\\" + filename + ".txt", file[i + 1] + "\n");
									File.AppendAllText(extract + "\\" + filename + ".txt", file[i + 2] + "\n");
									File.AppendAllText(extract + "\\" + filename + ".txt", file[i + 3] + "\n");
									if (file[i + 4] != "")
									{
										File.AppendAllText(extract + "\\" + filename + ".txt", file[i + 4] + "\n");
									}
								}
							}
						}
					}
				}
				Console.WriteLine("创建完成，共{0}个文件", a);
			}
			if (off=="0")
			{
				Directory.Delete(extract,true);
				Console.WriteLine("删除完成");
			}
			Console.ReadLine();
		}
	}
}
