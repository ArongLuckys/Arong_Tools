using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace default_tools
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string en = Environment.GetEnvironmentVariable("USERPROFILE");
			string ev = en + "\\AppData\\Local\\Arong_Menu";

			Console.WriteLine("当前软件的配置文件存在于" + ev);
			Console.WriteLine("输入1清除配置信息，软件将会还原至最初状态");
			if (Directory.Exists(ev))
			{
				Console.WriteLine("文件夹存在");
				int a = int.Parse(Console.ReadLine());
				if (a == 1)
				{
					Directory.Delete(ev, true);
					Console.WriteLine("恢复完成");
				}
			}
			else
			{
				Console.WriteLine("文件夹不存在，软件已经是最初状态");
			}
			Console.ReadLine();
		}
	}
}
