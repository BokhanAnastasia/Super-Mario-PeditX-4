using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Character
{
    public enum FightMethod
    {
        PUNCH,
        HARD_PUNCH,
        DASH,
        WAIT
    }

    public enum FightResult
    {
        WIN,
        LOOSE
    }

    interface Fighting
    {
        bool result { get; }

        public void punch();
        public void hardPunch();
        public void dash();
        public void wait();
        public void chooseMethod(FightMethod method);
        public bool compareAgility(int agility);
        public void startFight();
        public void stopFight();
        public FightResult getResult();

    }
}
