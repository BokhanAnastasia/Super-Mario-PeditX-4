using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Items
{
    public class Weapon : Item
    {
        public Weapon(int price, string name) : base(price, name) { }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
