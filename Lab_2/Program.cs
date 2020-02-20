using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        class C
        {
            private int n=0, m=0;

            public C(string x)
            {
                n = 0;
            }
        }

        Dictionary<string, string> cache = new Dictionary<string, string>();
        public string Cache(string x)
        {
            if (!cache.ContainsKey(x)) cache.Add(x, string.Format("{0}", new C(x)));
            return cache[x];
        }
        public void Uncache(string x) { cache.Remove(x); }
        public string Eval(string x) { return string.Format("{0}", new C(Cache(x))); }


        static void Main()
        {
            var c = new Program();
            for (var s = Console.ReadLine(); s != null; s = Console.ReadLine())
            {
                var a = s.Split(' ');
                var y = "0.0000000000";
                if (a[1] == "Cache") y = c.Cache(a[2]);
                else if (a[1] == "Uncache") c.Uncache(a[2]);
                else if (a[1] == "Eval") y = c.Eval(a[2]);
                if (a[0] == "Verbose") Console.WriteLine(y); 
            }
        }

    }
}
