using Super_Mario_PeditX_4.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Items
{
    public class Item
    {
        public int price;
        public string name;

        public Item(int price, string name) 
        {
            this.price = price;
            this.name = name;
        }

    }
}
