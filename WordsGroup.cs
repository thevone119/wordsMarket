using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsMarket4
{

    public class WordsGroup
    {
        public ushort idx;//成语的idx
        public string word;//成语
        public WordsGroup(ushort idx, string word)
        {
            this.idx = idx;
            this.word = word;
        }

    }


    //一个成语
    public class WordsGroupExt
    {
        public WordsGroup word;
        //选中->查找
        public short check1 = -1;//选中的位置
        public short check2 = -1;//查找的位置

        public short startX, startY;//开始位置。
        public bool vertical;//是否垂直，不是垂直就是水平呢。
        //public short usedTime;//已使用成语的次数。

        public WordsGroupExt(WordsGroup w)
        {
            word = w;
        }



        //复制
        public WordsGroupExt copy()
        {
            WordsGroupExt w = new WordsGroupExt(word);
            w.check1 = check1;
            w.check2 = check2;
            w.startX = startX;
            w.startY = startY;
            w.vertical = vertical;
            return w;
        }

        public WordsGroupExt ReCopy()
        {
            WordsGroupExt w = new WordsGroupExt(word);
            w.check1 = -1;
            w.check2 = -1;
            w.startX = 0;
            w.startY = 0;
            w.vertical = false;
            return w;
        }


        //重置
        public void Reset()
        {
            startX = 0;
            startY = 0;
            check1 = -1;
            check2 = -1;
            vertical = false;
        }

        //判断是否和当前对象重叠
        public bool Overlap(WordsGroupExt w)
        {
            short _minX = minX();
            if (w.minX() < _minX)
            {
                _minX = w.minX();
            }
            short _maxX = maxX();
            if (w.maxX() > _maxX)
            {
                _maxX = w.maxX();
            }

            short _minY = minY();
            if (w.minY() < _minY)
            {
                _minY = w.minY();
            }
            short _maxY = maxY();
            if (w.maxY() > _maxY)
            {
                _maxY = w.maxY();
            }
            //2个词语一共占用的面积
            int height = (Math.Abs(_minX - _maxX) + 1);
            int width = (Math.Abs(_minY - _maxY) + 1);
            int area = height * width;

            
            if (vertical == w.vertical)
            {
                if (vertical)//垂直
                {
                    if (height < 9 && width < 2)
                    {
                        return true;
                    }
                }
                else//水平
                {
                    if (width < 9 && height < 2)
                    {
                        return true;
                    }
                }
            }
            else//异向，面积小于=20
            {
                if (area <= 20)
                {
                    return true;
                }
            }
            return false;
        }



        public short minX()
        {
            return startX;
        }

        public short maxX()
        {
            if (vertical)
            {
                return startX;
            }
            else
            {
                return (short)(startX + 3);
            }
        }

        public short minY()
        {
            if (vertical)
            {
                return (short)(startY - 3); 
            }
            else
            {
                return startY;
            }
        }

        public short maxY()
        {
            return startY;
        }

        public Point GetWordPoint(short idx)
        {
            switch (idx)
            {
                case 0:
                    return vertical ? new Point(startX, startY) : new Point(startX, startY);
                case 1:
                    return vertical ? new Point(startX, (short)(startY - 1)) : new Point((short)(startX + 1), startY);
                case 2:
                    return vertical ? new Point(startX, (short)(startY - 2)) : new Point((short)(startX + 2), startY);
                case 3:
                    return vertical ? new Point(startX, (short)(startY - 3)) : new Point((short)(startX + 3), startY);
            }
            return null;
        }
    }

}
