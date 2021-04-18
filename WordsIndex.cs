using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 单个词语的位置
 * 
 * **/
namespace WordsMarket4
{

    public class Point
    {
        public short X, Y;
        public Point(short x, short y)
        {
            X = x;
            Y = y;
        }
    }






    /**
     *字典，把所有的字转换成ushort
     * */
    public class WordsDictionary
    {
        private static Dictionary<string, ushort> word_idx = new Dictionary<string, ushort>();//
        private static Dictionary<ushort, string> idx_word = new Dictionary<ushort, string>();//

        private static ushort idx=0;//最新的位置

        public static string get(ushort idx)
        {
            return idx_word[idx];
        }

        public static ushort get(string word)
        {
            return word_idx[word];
        }

        public static void add(string word)
        {
            if (word_idx.ContainsKey(word))
            {
                return;
            }
            else
            {
                word_idx[word] = idx;
                idx_word[idx] = word;
                idx++;
            }
        }

        public static void clear()
        {
            word_idx.Clear();
            idx_word.Clear();
            
            idx = 0;
        }

        public static ushort getIdx()
        {
            return idx;
        }


    }

   

}
