using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RemindDrinking
{
	public class readsetting
	{
        public List<string> timelist = new List<string> ();
        //settings的路径
        private String settingPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)+ @"\settings.txt";
        private int set_flag=0;//是哪种操作 (目前只有time一个)
        private int dealtemp(string s)
        {
            if (s == "time") set_flag = 1;
            else if (Regex.IsMatch(s, @"\d:\d"))
            {
                if (set_flag == 1) timelist.Add(s.Substring(4));
            }
            else if (s.Substring(0, 2) == "//") return 1;//注释
            else
            {
                System.Console.WriteLine("INVALID COMMAND");
                return -1;//错误行
            }
            return 0;//正常处理
        }
        public void ReadSettings()
        {
            if (!File.Exists(settingPath))
            {
                //不存在
                //throw (new ArgumentException("设置文件不存在"));

                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("设置文件不存在,要自动建立吗？", "ERROR", messButton);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    String Path1 = Application.StartupPath+@"\settings.txt";
                    File.Copy(Path1,settingPath, true);
                }
                else//如果点击“取消”按钮
                {
                    System.Environment.Exit(0); 
                }
            }
            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(settingPath);
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                counter++;
                string temp = "";
                int len = line.Length;
                for (int i = 0; i < len; i++)
                {
                    if (line[i] == ' ' || line[i] == '\t' || line[i] == '\n')//recognized a word
                    {
                        if (temp != "")
                            if (dealtemp(temp) == 1) break;
                            else { }//do nothing
                        else { }//do nothing
                    }
                    else temp += line[i];//continue
                }
                if (temp != "") dealtemp(temp);
                else { }//do nothing
            }
            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            saveLOG.perform("There were "+counter+ " lines in settings.");
        }
    }
}
