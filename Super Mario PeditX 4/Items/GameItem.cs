using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Items
{
    public enum GameItemType
    {
        Key,
        Note
    }

    public class GameItem: Item
    {
        public GameItemType type;
        public string usage;
        public GameItem(string name, GameItemType type, string usage) : base(0, name) 
        { 
            this.type = type;
            this.usage = usage;
        }

        // возвращает тип и описание предмета 
        public string GetGameItemDiscription(GameItemType type)
        {
            if (type == GameItemType.Key) return "it's a key with usage: " + usage;
            else if (type == GameItemType.Note) return "it's a note with usage: " + usage;
            else return "unknown type";
        }
    }
}
