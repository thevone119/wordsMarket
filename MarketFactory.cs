using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsMarket4
{

    //工厂，用于生产所有的成语
    public class MarketFactory
    {

        public int wordCount = 5;//单张成语数
        public int wkCount = 5;//挖孔数
        public int imgCount = 100;//生产图片数


        //所有的成语都在这里了
        public List<WordsGroup> AllWords = new List<WordsGroup>();

        //已经生产的图片，页面
        public List<MarketPage> hasPages = new List<MarketPage>();

        //开始生产时间
        public DateTime startTime;

        //随机开始位置
        public int startIdx;

        //随机函数
        Random rd = new Random();


        //
        public MarketFactory(List<WordsGroup> AllWords)
        {
            this.AllWords = AllWords;
        }

        //生产制造
        public void Make()
        {
            startTime = DateTime.Now;
            startIdx = rd.Next(AllWords.Count);
            hasPages.Clear();
            //
            loopMake();
        }

        //穷举
        private void loopMake()
        {
            //循环第一个成语
            foreach (WordsGroup _wg in AllWords)
            {
                WordsGroupExt wgx = new WordsGroupExt(_wg);
                MarketPage page = new MarketPage(wgx);
                for (short i = 0; i < 4; i++)
                {
                    List<WordsGroupExt> nexts = searchByOne(page, _wg.word[i]);
                    wgx.check2 = i;
                    foreach (WordsGroupExt next in nexts)
                    {
                        AddNextWord(page, next);
                    }
                }
            }
            Console.WriteLine("成语计算完成，总共{0}个成语组.", hasPages.Count);
        }

        //递归加入下一个
        private void AddNextWord(MarketPage page, WordsGroupExt wgext)
        {
            //每次都复制一个新的，避免修改旧的内容
            //WordsGroupExt wgext = _wgext.copy();
            WordsGroup word = wgext.word;
            page.MakePosition(wgext);
            if (page.CanAdd(wgext))//可以加，加入后，判断是否达标，达标则
            {
                MarketPage pagenext = page.copy();
                pagenext.Add(wgext);
                if (pagenext.listWords.Count >= wordCount)//达标，回退一个，找新的
                {
                    hasPages.Add(pagenext);
                    pagenext.ReMove();
                    Console.WriteLine("add word {0}.", pagenext.ToString());
                    Console.WriteLine(pagenext.ToSquare());
                    //回退，找新的
                    return;
                }
                else//不达标，继续加--
                {
                    List<WordsGroupExt> nexts = null;
                    switch (wgext.check1)
                    {
                        case 0:
                            nexts = searchByOne(pagenext, word.word[2]);
                            wgext.check2 = 2;
                            foreach (WordsGroupExt next in nexts)
                            {
                                AddNextWord(pagenext, next);
                            }
                            //
                            nexts = searchByOne(pagenext, word.word[3]);
                            wgext.check2 = 3;
                            foreach (WordsGroupExt next in nexts)
                            {
                                AddNextWord(pagenext, next);
                            }
                            break;
                        case 1:
                            nexts = searchByOne(pagenext, word.word[3]);
                            wgext.check2 = 3;
                            foreach (WordsGroupExt next in nexts)
                            {
                                AddNextWord(pagenext, next);
                            }
                            break;
                        case 2:
                            nexts = searchByOne(pagenext, word.word[0]);
                            wgext.check2 = 0;
                            foreach (WordsGroupExt next in nexts)
                            {
                                AddNextWord(pagenext, next);
                            }
                            break;
                        case 3:
                            nexts = searchByOne(pagenext, word.word[0]);
                            wgext.check2 = 0;
                            foreach (WordsGroupExt next in nexts)
                            {
                                AddNextWord(pagenext, next);
                            }
                            //
                            nexts = searchByOne(pagenext, word.word[1]);
                            wgext.check2 = 1;
                            foreach (WordsGroupExt next in nexts)
                            {
                                AddNextWord(pagenext, next);
                            }
                            break;
                    }
                }
            }
            else//不可以加，回退上一个
            {
                //
                //Console.WriteLine("nocan add page {0}->{1}.", page.ToString(), wgext.word.word);
                //page.ReMove();
                //Console.WriteLine(page.ToSquare());
                return;
            }
        }


        //随机生产
        private void randomMake()
        {
            AllWords.Clear();
            hasPages.Clear();
        }



        //根据一个字，找到所有符合的成语
        private List<WordsGroupExt> searchByOne(MarketPage page, char one)
        {
            List<WordsGroupExt> retList = new List<WordsGroupExt>();
            foreach (WordsGroup wg in AllWords)
            {
                if (page.HasWord(wg.idx))
                {
                    continue;
                }
                for (short i = 0; i < 4; i++)
                {
                    if (one == wg.word[i])
                    {
                        WordsGroupExt _wg = new WordsGroupExt(wg);
                        _wg.check1 = i;
                        retList.Add(_wg);
                    }
                }
            }
            return retList;
        }

        public void clear()
        {

        }




    }
}
