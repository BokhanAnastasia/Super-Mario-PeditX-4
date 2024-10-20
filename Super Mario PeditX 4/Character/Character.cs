using Super_Mario_PeditX_4.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Character
{
    public abstract class Character
    {
        public string name { get; set; }
        public CharacterLevel level { get; set; }

        public Character(string name, CharacterLevel level)
        {
            this.name = name;
            this.level = level;
        }

        // Абстрактный метод, который будут реализовывать наследники
        public abstract void ShowInfo();
    }
}
