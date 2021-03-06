﻿using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindDrinking
{
    //一个开源任务调度框架  附上git地址
    //https://github.com/fluentscheduler/FluentScheduler
    public class SystemTipsScheduler : Registry
    {
        private SortedSet<Tuple<int, int>> ss = new SortedSet<Tuple<int, int>>();
        public SystemTipsScheduler(readsetting x)
        {
            foreach(var timedata in x.timelist)
            {
                string[] times = timedata.Split(':');
                int tclock,tminute;
                int.TryParse(times[0], out tclock);
                int.TryParse(times[1], out tminute);
                Tuple<int, int> temp = Tuple.Create(tclock,tminute);
                if (ss.Contains(temp)) //这个时间已经激活过了
                {
                    //throw (new ArgumentException("666"));//debug
                    saveLOG.perform("重复的时间");
                }
                else
                {
                    Schedule(() => new ShowTipsMsgJob(1)).ToRunEvery(1).Days().At(tclock, tminute);
                    ss.Add(temp);
                }
            }
            saveLOG.perform("已添加各提醒");
            //Schedule a simple job to run at a specific time
            //Schedule(() => new ShowTipsMsgJob(1)).ToRunEvery(1).Days().At(9, 00);
            //Schedule(() => new ShowTipsMsgJob(2)).ToRunEvery(1).Days().At(10, 00);
            //Schedule(() => new ShowTipsMsgJob(3)).ToRunEvery(1).Days().At(11, 00);
            //Schedule(() => new ShowTipsMsgJob(4)).ToRunEvery(1).Days().At(12, 00);
            //Schedule(() => new ShowTipsMsgJob(5)).ToRunEvery(1).Days().At(14, 00);
            //Schedule(() => new ShowTipsMsgJob(6)).ToRunEvery(1).Days().At(15, 00);
            //Schedule(() => new ShowTipsMsgJob(7)).ToRunEvery(1).Days().At(16, 00);
            //Schedule(() => new ShowTipsMsgJob(8)).ToRunEvery(1).Days().At(18, 57);
        }
        
    }
    
    class ShowTipsMsgJob : IJob
    {
        /// <summary>
        /// 模式：用于区分任务，以显示不同的背景
        /// </summary>
        private int mod;

        public ShowTipsMsgJob(int mod)
        {
            this.mod = mod;
        }

        public void Execute()
        {
            TipsForm tips = new TipsForm(mod);
            tips.ShowDialog();
        }
    }
}
