using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSporBLL
{
    public class TestBll
    {
        public int Topla(int s1, int s2) => s1 + s2;
        public int Topla(int[] sayilar) => sayilar.Sum();

    }
}
