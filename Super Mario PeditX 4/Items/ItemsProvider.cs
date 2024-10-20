using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Items
{
    public class ItemsProvider
    {
        // Поле для хранения списка предметов
        public List<Item> Items;

        public ItemsProvider()
        {
            // Инициализация списка предметов
            Items = new List<Item>();
        }

        // Метод для добавления предмета в инвентарь
        public void AddItem(Item item)
        {
            Items.Add(item);
            Console.WriteLine($"{item} added to inventory.");
        }
        // Удаление предмета (пригодится еще для ДИЛЛЕРА)
        protected void RemoveItem(Item item) { Items.Remove(item); }
        // Очистить список айтемов (может пригодиться для создания НОВОЙ ИГРЫ)
        private void Clear() { Items.Clear(); }
        // Получение ЦЕНЫ предмета
        public int GetItemPrice(Item item) {  return item.price; }
        // Обновление списка предметов, возможно пригодится для UI
        protected List<Item> updateItems() { return Items; }
    }
}
