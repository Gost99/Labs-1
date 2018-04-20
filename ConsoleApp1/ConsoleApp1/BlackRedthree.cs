using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BlackRedthree
    {
            public int key { get; set; }
            public BlackRedthree left { get; set; }
        public BlackRedthree right { get; set; }
        public BlackRedthree parent { get; set; }
        public int Color { get; set; }
        public BlackRedthree(int key)
            {
            this.key = key;
            left = null;
            right = null;
            parent = null;
            Color = 1;
        }
        public BlackRedthree()
        {
            key = key;
            left = null;
            right = null;
            parent = null;
            Color = 1;
        }
    }  
    
}
