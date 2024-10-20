using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Character
{
    interface Actions
    {
        public void move(int x, int y);
        public void die();
        public void appearOnTheScreen(int x, int y);
    }
}
