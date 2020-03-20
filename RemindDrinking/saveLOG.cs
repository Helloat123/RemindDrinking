using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindDrinking
{
	static class saveLOG
	{
		public static string logPath= Application.StartupPath+@"\log.txt";
		public static void perform(string s)
		{
			s=DateTime.Now.ToLocalTime().ToString()+" "+s;
			if (!System.IO.File.Exists(logPath))
			{
				FileStream file = new FileStream(logPath, FileMode.Create, FileAccess.Write);//创建写入文件
				StreamWriter sw = new StreamWriter(file);
				sw.WriteLine(s);
				sw.Close();
				file.Close();
			}
			else using (System.IO.StreamWriter file = new System.IO.StreamWriter(logPath, true))
			{
				file.WriteLine(s);
				file.Close();
			}
		}
		public static void processlog()
		{
			JobManager.JobException += info => perform("An error just happened with a scheduled job: " + info.Exception);
		}
	}
}
