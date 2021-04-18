using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordsMarket4
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }



        MarketFactory factory = null;


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void but_path_Click(object sender, EventArgs e)
        {
            //选择文件
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择成语库";
            dialog.Filter = "txt文件(*.txt)|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                text_path.Text = dialog.FileName;
            }
            if (factory != null)
            {
                factory.clear();
            }else{
                factory = new MarketFactory(new List<WordsGroup>());
            }

            //去重dict
            Dictionary<string, char> hasWords = new Dictionary<string, char>();
            //读取所有的成语
            // using 语句也能关闭 StreamReader
            ushort idx=0;
            using (StreamReader sr = new StreamReader(text_path.Text))
            {
                string line;
                // 从文件读取并显示行，直到文件的末尾 
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == null || line.Length != 4)
                    {
                        continue;
                    }
              
                    if (hasWords.ContainsKey(line))
                    {
                        continue;
                    }
                    //拆成4个字
                    factory.AllWords.Add(new WordsGroup(idx++, line));

                    hasWords.Add(line, 'd');
                }
            }
            Console.WriteLine("已读取{0}个成语.", factory.AllWords.Count);
        }

        private void but_img_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择生成图片路径";
            //dialog.SelectedPath = path;
            //dialog.RootFolder = Environment.SpecialFolder.Programs;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                text_img.Text = dialog.SelectedPath;
            }
        }

        /**
         * 生成图片的方法
         * */
        private void but_market_Click(object sender, EventArgs e)
        {
            if (factory == null || factory.AllWords.Count == 0)
            {
                MessageBox.Show("请选择成语库", "提示");
                return;
            }
            //注入配置值
            int.TryParse(text_wordCount.Text, out factory.wordCount);
            int.TryParse(text_wkCount.Text, out factory.wkCount);
            int.TryParse(text_imgCount.Text, out factory.imgCount);
            short.TryParse(text_width.Text, out MarketPage.maxSize);
            
            Console.WriteLine("imgCount:{0}.", factory.imgCount);

   
            //开始递归生产
            factory.Make();




        }

        private string getNext(Dictionary<char[], char> popWords, char[] startword)
        {
            foreach (char[] word in popWords.Keys)
            {
                
            }
       

            return null;
        }

        private void but_test_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                WordsDictionary.add("" + i);

            }
            char s1 = '打';
            string s2 = "去打";

            Console.WriteLine("WordsDictionary:{0}.", s1==s2[1]);
            Console.WriteLine("WordsDictionary:{0}.", WordsDictionary.get("10"));
            Console.WriteLine("WordsDictionary idx:{0}.", WordsDictionary.getIdx());

        }

        
    }
}
