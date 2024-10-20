using Super_Mario_PeditX_4.Items;
using Super_Mario_PeditX_4.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Character
{
    public class Player : Character
    {
        private int HP;
        private int strength;
        private int agility;
        public int money;

        public Armor? armor = null;
        public Weapon? weapon = null;
        private readonly ItemsProvider inventory;


        private static readonly int LEVEL_PROGRESSION = 5;
        private static readonly int BASE_HP = 5;
        private static readonly int BASE_MONEY = 0;
        private static readonly int BASE_AGILITY = 10;
        private static readonly int BASE_STRENGTH = 10;

        public Player( string name, CharacterLevel level)
            : base(name, level)
        {

            // инициализация базовых статов
            baseInit();
            SetHPByLevel(level); // Устанавливаем HP в зависимости от уровня при создании конструктора
            this.inventory = new ItemsProvider();
            
        }

        private void baseInit()
        {
            strength = BASE_STRENGTH;
            agility = BASE_AGILITY;
            money = BASE_MONEY;
        }

        // Установка HP в зависимости от уровня
        public void SetHPByLevel(CharacterLevel level) { HP = level.currentLevel * LEVEL_PROGRESSION + BASE_HP;}

        // Методы для снятия и надевания брони оружия
        public void setArmor(Armor armor) { this.armor = armor; }
        public void takeOffArmor() { armor = null; }
        public void setWeapon(Weapon weapon) { this.weapon = weapon; }
        public void takeOffWeapon() { weapon = null; }


        // Метод для сбора предметов
        public void CollectItem(Item item)
        {
            inventory.AddItem(item);
        }


        public override void ShowInfo()
        {
            Console.WriteLine(
                $"Player: {name}, " +
                $"Level: {level.GetLevel()}, " +
                $"HP: {HP}, " +
                $"Strength: {strength}, " +
                $"Armor: {armor}, " +
                $"Weapon: {weapon}, " +
                $"Agility: {agility}, " +
                $"Money: {money}");
        }
    }
}
