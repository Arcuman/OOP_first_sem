using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class StaticOperation
    {
        public static string Common(this string d)
        {
            string res = d.Replace(" ", ",");
            return res;
        }
        public static Set<int> DeleteTheSame(this Set<int> d, int temp)
        {
            bool flag = false;
            foreach (var item in d)
            {
                if (item == temp)
                    flag = true;
            }
            if (flag) d.Delete(temp);
            return d;
        }

        public static int GetMaxElement(Set<int> set1)
        {
            int maxstr =  -99999999;
            foreach (var item in set1)
            {
                if (item > maxstr)
                {
                    maxstr = item;
                }
            }
            return maxstr;
        }

        public static int GetMinElement(Set<int> set1)
        {
            int minstr = -99999999;
            foreach (var item in set1)
            {
                if (item > minstr)
                {
                    minstr = item;
                }
            }
            return minstr;
        }
        
        }

    }

