using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ConsolApplicaton3
{
    class Program
    {
        static void Main(string[] args)
        {
            Prime prime = new Prime();
            List<long> tmp = prime.getList();

        }
    }
    class Prime
    {
        private List<long> primeList;
        public Prime()
        {
            primeList = new List<long>();
        }
        public List<long> getList { get { return primeList; } }
        private void makeList(long n)
        {
            primeList.Add(2);
            int tmp = 3;
            int tmpRoute;
            bool flag;
            while (tmp <= n)
            {
                flag = true;
                tmpRoute = (int)Math.Sqrt(tmp);
                foreach (int i in primeList)
                {
                    if (i > tmpRoute)
                        break;
                    if (tmp % i == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    primeList.Add(tmp);
                tmp += 2;
            }
        }
        private void clearList()
        {
            primeList.Clear();
        }
    }
}