﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindDrinking
{
    public partial class TipsForm : Form
    {
        private int showMod;
        private int index;
        public TipsForm(int mod)
        {
            InitializeComponent();
            showMod = mod;
        }

        private void TipsForm_Load(object sender, EventArgs e)
        {
            //定时任务启动
            TmrBackHome.Start();
            Random rd = new Random();
            int LabXPoint = rd.Next(100, 900);
            int LabYPoint = rd.Next(100, 900);
            this.LabMsg.Location = new System.Drawing.Point(LabXPoint, LabYPoint);
            switch (showMod)
            {
                case 1:
                    this.BackgroundImage = global::RemindDrinking.Properties.Resources._1;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    LabMsg.Text = "9:00  用最美的心情来迎接朝阳和第一杯水！";
                    break;
                case 2:
                    this.BackgroundImage = global::RemindDrinking.Properties.Resources._2;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    LabMsg.Text = "10:00  休息一会，补充一点水分吧！";
                    break;
                case 3:
                    this.BackgroundImage = global::RemindDrinking.Properties.Resources._3;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    LabMsg.Text = "11:00  科学研究表明，此时喝水有助于瘦身！";
                    break;
                case 4:
                    this.BackgroundImage = global::RemindDrinking.Properties.Resources._4;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    LabMsg.Text = "12:00  吃完饭，喝杯水，休息一会！";
                    break;
                case 5:
                    this.BackgroundImage = global::RemindDrinking.Properties.Resources._5;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    LabMsg.Text = "15:00  起来走走，别忘记喝水！";
                    break;
                case 6:
                    this.BackgroundImage = global::RemindDrinking.Properties.Resources._6;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    LabMsg.Text = "16:00  该起来活动活动喝杯水了！";
                    break;
                case 7:
                    this.BackgroundImage = global::RemindDrinking.Properties.Resources._7;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    LabMsg.Text = "17:00  还有一会就下班了，今天的八杯水任务完成了吗？";
                    break;
                case 8:
                    this.BackgroundImage = global::RemindDrinking.Properties.Resources._8;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    LabMsg.Text = "18:00  用最美的心情来迎接朝阳和第一杯水！";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 关闭窗体任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrBackHome_Tick(object sender, EventArgs e)
        {
            index++;
            if (index > 30)
            {
                this.Close();
            }
        }
    }
}