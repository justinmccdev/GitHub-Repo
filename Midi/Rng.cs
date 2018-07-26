using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace $safeprojectname$
//{
    public static class Rng
    {
        public static Random rng = new Random();
        public static bool Percent(int p)
        {
            return rng.Next(100) < p;
        }



        public static T GetRandomElement<T>(this List<T>  list)
        {
            return list[Rng.rng.Next(list.Count)];
        }
    }
//}
