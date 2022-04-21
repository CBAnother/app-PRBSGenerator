using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRBSGen
{
    class PRBSGenItem
    {
        public int offset1;
        public int offset2;

        public PRBSGenItem(int offset1, int offset2)
        {
            this.offset1 = offset1;
            this.offset2 = offset2;
        }
    }


    class PRBSGen
    {
        private static Dictionary<int, PRBSGenItem> _itemDic;

        static PRBSGen()
        {
            _itemDic = new Dictionary<int, PRBSGenItem>();
            _itemDic[3] = new PRBSGenItem(2, 3);
            _itemDic[5] = new PRBSGenItem(3, 5);
            _itemDic[7] = new PRBSGenItem(6, 7);
            _itemDic[9] = new PRBSGenItem(5, 9);
            _itemDic[11] = new PRBSGenItem(9, 11);
            _itemDic[15] = new PRBSGenItem(14, 15);
            _itemDic[20] = new PRBSGenItem(3, 20);
            _itemDic[23] = new PRBSGenItem(18, 23);
            _itemDic[31] = new PRBSGenItem(28, 31);
        }

        public static string GetPRBS(int order)
        {
            if (!_itemDic.ContainsKey(order))
                return null;

            //  查找对应的项, 便于生成
            PRBSGenItem item = _itemDic[order];

            //  初始化变量
            int state = 0x1;
            int max = (int)(Math.Pow(2, order) - 1 + 0.02);
            string res = "";

            //  循环获取 prbs 码
            while(res.Length < max)
            {
                var lsb = state & 0x01;
                var tmp = ((state >> (order - item.offset1)) & 0x01) ^
                    ((state >> (order - item.offset2)) & 0x01);
                state += tmp << order;
                state >>= 1;

                res += (char)(lsb + '0');
            }
            return res;
        }

        public static List<int> GetOrderLst()
        {
            return _itemDic.Select(x => x.Key).ToList();
        }
    }
}
