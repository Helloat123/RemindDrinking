using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindDrinking
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            saveLOG.perform("start main");
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "RemindDrinking", out bool isRuned);
            if (isRuned)
            {
                saveLOG.perform("Running");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //读取设置文件
                saveLOG.perform("Reading settings");
                readsetting p= new readsetting();
                p.ReadSettings();
                //注册定时任务
                JobManager.Initialize(new SystemTipsScheduler(p));
                saveLOG.perform("Jobmanager Initialized");
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("Running", "DrinkingReminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
