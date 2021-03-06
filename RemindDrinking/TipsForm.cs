﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindDrinking
{
    public partial class TipsForm : Form
    {
        //图片的所在目录
        private String imgPath = Application.StartupPath + @"\image\";
        //显示文字模式
        private int showMod;
        private int index; //关闭提示窗体计数器
        public TipsForm(int mod)
        {
            InitializeComponent();
            showMod = mod;
        }

        private void TipsForm_Load(object sender, EventArgs e)
        {
            saveLOG.perform("TipsForm loaded");
            //定时关闭提示窗体任务 启动
            TmrBackHome.Start();

            Random rd = new Random();

            //文字提示的随机坐标
            int LabXPoint = rd.Next(10, 80);
            int LabYPoint = rd.Next(10, 400);
            this.LabMsg.Location = new System.Drawing.Point(LabXPoint, LabYPoint);

            //获取 image文件夹下的文件名列表
            List<string> imgFile = GetImage();
            
            //随机拿到一个图片
            string imgName = imgFile[rd.Next(imgFile.Count)];
            saveLOG.perform("图片选中了" + imgName);
            this.BackgroundImage = Image.FromFile(imgPath + imgName);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button1.Left = this.Width - button1.Width;
            button1.Top = this.Height - button1.Height;

            LabMsg.Text = "喝水";
            //switch (showMod)
            //{  
                //case 1:
                //    LabMsg.Text = "9:00  用最美的心情来迎接朝阳和第一杯水！";
                //    break;
                //case 2:
                //    LabMsg.Text = "10:00  小公主~ 要记得喝水哦！";
                //    break;
                //case 3:
                //    LabMsg.Text = "11:00  科学研究表明，此时喝水有助于瘦身！";
                //    break;
                //case 4:
                //    LabMsg.Text = "12:00  吃完饭，喝杯水，休息一会！";
                //    break;
                //case 5:
                //    LabMsg.Text = "14:00  喝最大杯的水，做最靓的仔！";
                //    break;
                //case 6:
                //    LabMsg.Text = "15:00  娘娘，喝水的时间到了！";
                //    break;
                //case 7:
                //    LabMsg.Text = "16:00  菇凉，喝口水吧！";
                //    break;
                //case 8:
                //    LabMsg.Text = "17:00  注意，再喝一杯水，马上要下班了！";
                //    break;
                //default:
                //    break;
            //}
        }

        /// <summary>
        /// 获取image目录下文件名集合
        /// </summary>
        /// <returns></returns>
        private List<string> GetImage()
        {
            int count=0;
            //相对路径，image文件夹内
            DirectoryInfo dir = new DirectoryInfo(imgPath);

            FileInfo[] fileInfo = dir.GetFiles();
            List<string> fileNames = new List<string>();
            foreach (FileInfo item in fileInfo)
            {
                fileNames.Add(item.Name);
                count++;
            }
            saveLOG.perform("图片有"+count+"张");
            return fileNames;
        }

        /// <summary>
        /// 关闭窗体任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrBackHome_Tick(object sender, EventArgs e)
        {
            index++;
            if (index > 20)
            {
                saveLOG.perform("时间到关闭");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveLOG.perform("按钮关闭");
            this.Close();
        }
    }
}
