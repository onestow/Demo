using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Test
{
    public class AmountMatch
    {
        struct Sms
        {
            public int parentInd;
            public int amount;
            public override string ToString()
            {
                return $"{parentInd} - {amount}";
            }
        }
        public void Run()
        {
            var ts = new Sms[]
            {
                new Sms(){ parentInd = -1, amount = 3 },
                new Sms(){ parentInd = -1, amount = 5 },
                new Sms(){ parentInd = -1, amount = 7 },
                new Sms(){ parentInd = -1, amount = 11 },
                new Sms(){ parentInd = -1, amount = 13 },
                new Sms(){ parentInd = -1, amount = 17 },
            };

            Console.WriteLine(dfs(10, ts, 1).ToString());
            Console.WriteLine(dfs(29, ts, 2).ToString());
            Console.WriteLine(dfs(17, ts, 3).ToString());
            Console.ReadKey();
        }

        int times = 0;
        bool dfs(int amount, Sms[] ts, int parentInd, int startInd = 0)
        {
            times += 1;
            for (int i = startInd; i < ts.Length; i++)
            {
                if (ts[i].parentInd != -1)
                    continue;

                if (amount < ts[i].amount)
                    continue;
                if (amount == ts[i].amount)
                {
                    ts[i].parentInd = parentInd;
                    return true;
                }

                ts[i].parentInd = parentInd;
                if (dfs(amount - ts[i].amount, ts, parentInd, i + 1))
                    return true;
                ts[i].parentInd = -1;
            }
            return false;
        }
    }
}
