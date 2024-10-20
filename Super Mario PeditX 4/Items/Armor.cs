using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Items
{
  
    public class Armor: Item
    {
        private int addingHP;
        private int addingStrength;
        private int addingAgility;

        private int HP;
        
        Armor(  int addingHP, int addingStrength, int addingAgility, int HP,
                int price, string name): base(price, name) 
        {
            this.addingHP = addingHP;
            this.addingStrength = addingStrength;
            this.addingAgility = addingAgility; 
            this.HP = HP;
        }
    }
}
