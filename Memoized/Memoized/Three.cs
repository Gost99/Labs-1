using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memoized
{
    class Three
    {
        public int key;
        public Three left;
        public Three right;
        public Three parent;
    //    public Three current;
        public int Color;
        public Three(int key)
        {
            this.key = key;
            left = null;
            right = null;
          //  parent = current;
          //  if (current != null)
        //        current = new Three(key);
            Color = 1; // red
        }
        public Three()
        {
            left = null;
            right = null;
            parent = null;
            Color = 0;
        }
        //public void Node()
        //{
        //    left = null;
        //    right = null;
        //    parent = current;

        //}
    }
}
