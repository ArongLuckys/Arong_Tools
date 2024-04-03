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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Arong_Log.Oper_Log("工具箱初始化-完成");
			Application.Run(new Form_main());
		}
	}
}
