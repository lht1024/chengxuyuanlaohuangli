using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace chengxuyuanlaohuangli
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            string[] activityName = new string[] { "写单元测试", "洗澡", "锻炼一下身体", "抽烟", "白天上线",
                "重构", "使用", "跳槽", "招人", "面试", "提交辞职申请", "申请加薪", "晚上加班", "在妹子面前吹牛",
                "撸管", "浏览成人网站", "命名变量", "写超过行的方法", "提交代码", "代码复审", "开会", "打DOTA",
                "晚上上线", "修复BUG", "设计评审", "需求评审", "上微博", "上AB站", "玩FlappyBird","" };

            string[] activityGood = new string[] { "写单元测试将减少出错", "你几天没洗澡了？","", "抽烟有利于提神，增加思维敏捷",
                "今天白天上线是安全的","代码质量得到提高", "你看起来更有品位","该放手时就放手","你面前这位有成为牛人的潜质",
                "面试官今天心情很好","公司找到了一个比你更能干更便宜的家伙，巴不得你赶快滚蛋","老板今天心情很好","晚上是程序员精神最好的时候",
                "改善你矮穷挫的形象","避免缓冲区溢出","重拾对生活的信心","","你的代码组织的很好，长一点没关系","遇到冲突的几率是最低的",
                "发现重要问题的几率大大增加","写代码之余放松一下打个盹，有益健康","你将有如神助","晚上是程序员精神最好的时候","你今天对BUG的嗅觉大大提高",
                "设计评审会议将变成头脑风暴","","今天发生的事不能错过","还需要理由吗？","今天破纪录的几率很高",""};

            string[] activityBad = new string[] { "写单元测试会降低你的开发效率", "会把设计方面的灵感洗掉","能量没消耗多少，吃得却更多",
                "除非你活够了，死得早点没关系", "可能导致灾难性后果", "你很有可能会陷入泥潭","别人会觉得你在装逼",
                "鉴于当前的经济形势，你的下一份工作未必比现在强" ,"这人会写程序吗？","面试官不爽，会拿你出气",
                "鉴于当前的经济形势，你的下一份工作未必比现在强","公司正在考虑裁员","","会被识破","强撸灰飞烟灭","你会心神不宁","",
                "你的代码将混乱不堪，你自己都看不懂","你遇到的一大堆冲突会让你觉得自己是不是时间穿越了","你什么问题都发现不了，白白浪费时间",
                "小心被扣屎盆子背黑锅","你会被虐的很惨","你白天已经筋疲力尽了","新产生的BUG将比修复的更多","人人筋疲力尽，评审就这么过了","",
                "今天的微博充满负能量","满屏兄贵亮瞎你的眼","除非你想玩到把手机砸了",""};

            string[] IsWeekend = new string[] { "0", "1", "1", "1", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "1", "1", "0",
                    "0", "0", "0", "0", "1", "0", "0", "0", "0", "1", "1", "1"};

            string[] tool = new string[] { "Eclipse写程序", "MSOffice写文档", "记事本写程序", "Windows8",
                                            "Linux", "MacOS", "IE", "Android设备", "iOS设备" };

            int num = 0;
            var today = new DateTime();
            var _day = today.Year * 10000 + (today.Month + 1) * 100 + today.Day;
            int[] GoodItem = new int[3] { 29, 29, 29 };
            int[] BadItem = new int[3] { 29, 29, 29 };
            Random action = new Random(_day);
            TimeGet();
            int randNum = RandomDay(_day, 181);
            activityName[6] = "使用" + tool[randNum % 9];
            activityName[17] = "写超过" + action.Next(500,1500).ToString() + "行的方法";

            GetDeskTo(randNum);
            GetWhatToDrink(randNum);
            int i = GetGoodActivityNum(randNum);
            //int i = 3;
            int j = GetBadActivityNum(randNum);
            //int j = 3;
            for (num = 0; num < i; num++)
            {
                GoodItem[num] = action.Next(100, 2000) % 29;
            }
            for (num = 0; num < j; num++)
            {
                BadItem[num] = action.Next(300, 2200) % 29;
            }
            Judge(i, j);
            AddActivity(activityName,activityGood,activityBad,GoodItem,BadItem);
            SpecialDate(today);
    }

        private void TimeGet()
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            MyCalendar.Text = "今天是" + DateTime.Now.Year.ToString() + "年"
                + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日"
                + "   " + Day[Convert.ToInt16(DateTime.Now.DayOfWeek)].ToString();
        }

        private int RandomDay(int iSeed,int indexseed)
        {
            var n = iSeed % 11117;
            for (var i = 0; i < 100 + indexseed; i++)
            {
                n = n * n;
                n = n % 11117;
            }
            return n;
        }

        private void GetDeskTo(int Number)
        {
            string[] direction = new string[] { "北方", "东北方", "东方", "东南方", "南方", "西南方", "西方", "西北方" };
            DeskTo.Text = "面向" + direction[Number % 8] + "写程序，BUG 最少。";
        }

        private void GetWhatToDrink(int Number)
        {
            string[] drinks = new string[] { "水", "茶", "红茶", "绿茶", "咖啡", "奶茶", "可乐", "鲜奶", "豆奶", "果汁", "果味汽水", "苏打水", "运动饮料", "酸奶", "酒" };
            WhatToDrink.Text = drinks[Number % 15];
        }


        private int GetGoodActivityNum(int Number)
        {
            int GoodNum = (Number % 11) % 2 + 1;
            return GoodNum;
        }

        private int GetBadActivityNum(int Number)
        {
            int BadNum = (Number % 37) % 2 + 1;
            return BadNum;
        }

        private void Judge(int i, int j)
        {
            Thickness type1 = new Thickness(15, 50, 0, 0);
            Thickness type2 = new Thickness(15, 30, 0, 0);
            Thickness type3 = new Thickness(15, 10, 0, 0);


            if (i == 1)
            {
                MyBox1.Height = 120;
                MyBox2.Height = 120;
                stack1.Margin = type1;
            }
            else if (i == 2)
            {
                MyBox1.Height = 145;
                MyBox2.Height = 145;
                stack1.Margin = type2;
            }
            else
            {
                MyBox1.Height = 175;
                MyBox2.Height = 175;
                stack1.Margin = type3;
            }
            if (j == 1)
            {
                MyBox3.Height = 120;
                MyBox4.Height = 120;
                stack2.Margin = type1;
            }
            else if (j == 2)
            {
                MyBox3.Height = 145;
                MyBox4.Height = 145;
                stack2.Margin = type2;
            }
            else
            {
                MyBox3.Height = 175;
                MyBox4.Height = 175;
                stack2.Margin = type3;
            }
        }

        private void AddActivity(string[]name,string[]good,string[]bad,int[]gooditem,int[]baditem)
        {
            Good1.Text = name[gooditem[0]];
            good1.Text = good[gooditem[0]];
            Good2.Text = name[gooditem[1]];
            good2.Text = good[gooditem[1]];
            Good3.Text = name[gooditem[2]];
            good3.Text = good[gooditem[2]];
            Bad1.Text = name[baditem[0]];
            bad1.Text = bad[baditem[0]];
            Bad2.Text = name[baditem[1]];
            bad2.Text = bad[baditem[1]];
            Bad3.Text = name[baditem[2]];
            bad3.Text = bad[baditem[2]];
        }

        private void SpecialDate(DateTime today)
        {
            if (today.Month == 2 && today.Day == 14)
            {
                Good1.Text = "烧烤节";
                good1.Text = "'脱团火葬场，入团保平安";
                Bad1.Text = "异端审判";
                bad1.Text = "'待在男（女）友身边";

            }
        }
    }
}
