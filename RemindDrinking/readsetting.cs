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
        public List<string> timelist= new List<string> ();
        //exe的路径
        private String exePath = Application.StartupPath;
        private int set_flag;
        private int dealtemp(string s)
        {
            if (s == "time") set_flag = 1;
            else if (Regex.IsMatch(s, @"\d:\d"))
            {
                if (set_flag == 1) timelist.Add(s.Substring(4));
            }
            else if (s.Substring(0, 2) == "//") return 1;
            else System.Console.WriteLine("INVALID COMMAND");
            return 0;
        }
        public void ReadSettings()
        {
            if (!File.Exists(exePath + @"\settings.txt"))
            {
                //不存在
                throw (new ArgumentException("设置文件不存在"));
            }
            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"settings.txt");//DEBUG
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
        }
    }
}
