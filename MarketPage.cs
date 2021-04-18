using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsMarket4
{

    //一张图片
    public class MarketPage
    {
        //所有选中的词
        public List<WordsGroupExt> listWords = new List<WordsGroupExt>();

        public static short maxSize = 9;

        //public ushort[] excIds
        //public int id;

        //public short minX,minY,maxX,maxY;

        public MarketPage()
        {

        }
        public MarketPage(WordsGroupExt frist)
        {
            listWords.Add(frist);
        }

        //计算位置
        public void MakePosition(WordsGroupExt w)
        {
            if (listWords.Count == 0)
            {
                w.vertical = false;
                w.startX = 0;
                w.startY = 0;
            }
            else
            {
                WordsGroupExt last = listWords[listWords.Count - 1];
                w.vertical = !last.vertical;
                //计算位置-
                if (last.vertical)//垂直
                {
                    w.startX = (short)(last.startX - w.check1);
                    w.startY = (short)(last.startY - last.check2);
                }
                else//水平
                {
                    w.startX = (short)(last.startX + last.check2);
                    w.startY = (short)(last.startY + w.check1);
                }
            }
        }

        //尝试添加
        public bool tryAdd(short selectidx, WordsGroupExt w)
        {
            if (listWords.Count == 0)
            {
                w.vertical = false;
                w.startX = 0;
                w.startY = 0;
                return true;
            }
            else
            {
                WordsGroupExt last = listWords[listWords.Count - 1];
                w.vertical = !last.vertical;
                //计算位置-
                if (last.vertical)//垂直
                {
                    w.startX = (short)(last.startX - w.check1);
                    w.startY = (short)(last.startY - last.check2);
                }
                else//水平
                {
                    w.startX = (short)(last.startX + last.check2);
                    w.startY = (short)(last.startY + w.check1);
                }
            }

            return CanAdd(w);
        }

        //放入,放入的时候，自动适配位置，方向
        public void Add(WordsGroupExt w)
        {
            listWords.Add(w);
        }



        //弹出最后一个
        public WordsGroupExt PopLast()
        {
            if (listWords.Count > 0)
            {
                WordsGroupExt last = listWords[listWords.Count - 1];
                listWords.RemoveAt(listWords.Count - 1);
                return last;
            }
            return null;
        }

        //随机挖孔
        public void RandomAdd()
        {

        }


        //是否符合生产标准
        public bool CanAdd(WordsGroupExt w)
        {
            int count = listWords.Count;
            //少于3个，直接符合
            if (count < 3)
            {
                return true;
            }
            short maxX = w.maxX();
            short maxY = w.maxY();
            short minX = w.minX();
            short minY = w.minY();

            for (int i = 0; i < count; i++)
            {
                WordsGroupExt word = listWords[i];
                if (word.maxX() > maxX)
                {
                    maxX = word.maxX();
                }
                if (word.maxY() > maxY)
                {
                    maxY = word.maxY();
                }
                if (word.minX() < minX)
                {
                    minX = word.minX();
                }
                if (word.minY() < minY)
                {
                    minY = word.minY();
                }
                //如果和其他的重叠，冲突，也不允许加入
                if (i == count - 1)
                {
                    continue;//最后一个除外
                }
                //和之前的有重叠了
                if (word.Overlap(w))
                {
                    return false;
                }
            }

            //如果符合10*10
            if (Math.Abs(maxX - minX)+1 > maxSize)
            {
                return false;
            }
            if (Math.Abs(maxY - minY)+1 > maxSize)
            {
                return false;
            }
            return true;
        }

        //取ID
        public StringBuilder getId()
        {
            StringBuilder sb = new StringBuilder();
            foreach (WordsGroupExt tp in listWords)
            {
                sb.Append(tp.word.idx + ",");
            }
            return sb;
        }

        //是否是同一个对象
        public bool equals(MarketPage p)
        {
            if (getId().Equals(p.getId()))
            {
                return true;
            }
            return false;
        }

        public bool HasWord(ushort idx)
        {
            foreach (WordsGroupExt w in listWords)
            {
                if (w.word.idx == idx)
                {
                    return true;
                }
            }
            return false;
        }

        //复制一个对象,不用全新的，半新的对象即可。复制后，再弹出最后一个
        public MarketPage copy()
        {
            MarketPage p = new MarketPage();
            foreach (WordsGroupExt w in listWords){
                p.listWords.Add(w.copy());
            }
            return p;
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (WordsGroupExt w in listWords)
            {
                sb.Append(w.word.word+ " ");
            }
            return sb.ToString();
        }

        //位移
        public void ReMove()
        {
            short maxX = 0;
            short maxY = 0;
            short minX = 0;
            short minY = 0;
            int count = listWords.Count;
            for (int i = 0; i < count; i++)
            {
                WordsGroupExt word = listWords[i];
                if (word.maxX() > maxX)
                {
                    maxX = word.maxX();
                }
                if (word.maxY() > maxY)
                {
                    maxY = word.maxY();
                }
                if (word.minX() < minX)
                {
                    minX = word.minX();
                }
                if (word.minY() < minY)
                {
                    minY = word.minY();
                }
            }
            //需要移动的位置
            int center = (maxSize - 1) / 2;
            short moveX = (short)(center - (maxX - (Math.Abs(maxX - minX) + 1) / 2));
            short moveY = (short)(center - (maxY - (Math.Abs(maxY - minY) + 1) / 2));
            foreach (WordsGroupExt word in listWords)
            {
                word.startX += moveX;
                word.startY += moveY;
            }
        }

        //画方阵 9* 9
        public string ToSquare()
        {
            char[,] sq = new char[maxSize, maxSize];
            for (int x = 0; x < maxSize; x++)
            {
                for (int y = 0; y < maxSize; y++)
                {
                    sq[x, y] = '口';
                }
            }
            foreach (WordsGroupExt word in listWords)
            {
                for (short i = 0; i < 4; i++)
                {
                    Point p = word.GetWordPoint(i);
                    sq[p.X, p.Y] = word.word.word[i];
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int y = maxSize-1; y >=0; y--)
            {
                for (int x = 0; x < maxSize; x++)
                {
                    sb.Append(sq[x, y]);
                }
                sb.Append("\n");
            }
            
            return sb.ToString();

        }


    }
}
