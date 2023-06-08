using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arong_Core;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Arong_Menu
{
	internal static class Program
	{

		[STAThread]
		static void Main()
		{
			if (File.Exists(Arong_Path.Key) == true)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Arong_Log.Oper_Log("工具箱初始化-完成");
				Application.Run(new Form_main());
				//Application.Run(new Main_Menu_Split());
			}
			else
			{
				MessageBox.Show("找不到Key文件" + "\n联系QQ:2786217208");
				Arong_Log.Oper_Log("初始化失败");
				//强制退出该程序
				Application.Exit();
			}
		}
	}
}
