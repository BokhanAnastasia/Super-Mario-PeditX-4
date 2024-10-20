using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Level
{
    public class CharacterLevel : Level
    {
        public CharacterLevel(int minLevel, int maxLevel, int currentLevel)
            : base(minLevel, maxLevel, currentLevel) { }

        // Метод для получения текущего уровня персонажа
        public int GetLevel()
        {
            return currentLevel;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Character Level: {currentLevel} (Min: {minLevel}, Max: {maxLevel})");
        }
    }
}
