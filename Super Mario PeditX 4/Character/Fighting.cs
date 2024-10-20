using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Character
{
    public enum FightMethod
    {
        PUNCH = 0,
        DASH,
        WAIT,
        MOVE
    }

    public enum FightState
    {
        WIN,
        LOOSE,
        IN_PROGRESS
    }
    public enum Direction
    {
        LEFT, RIGHT, UP
    }

    interface Fighting
    {
        public int punchDamage();
        public int moveDamage();
        public int dashDamage();
        public int waitDamage();
        public bool compareAgility(int agility);
        public void setDamage(int damage);

    }
}
