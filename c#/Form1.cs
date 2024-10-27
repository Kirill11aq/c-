using Microsoft.VisualBasic;
namespace c_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Item
        {
            public int lvl;
            public int hp;
        }
        class Hero
        {
            public string name;
            public int damage;
            public int hp;
            public int money;
            public Item armor;
            public Item sword;
            public Hero(string name, int damage, int hp, int money = 100)
            {
                this.name = name;
                this.damage = damage;
                this.hp = hp;
                this.money = money;
                armor = new Item { lvl = 1, hp = 10 };
                sword = new Item { lvl = 1, hp = 10 };
            }
            public void Info()
            {
                MessageBox.Show("____________________________________\n" +
                    "Name: " + name + "| Money: " + money + "\n" +
                    "Damage: " + damage + "| Armor: " + armor.lvl + " Sword: " + sword.lvl + "\n" +
                    "HP: " + hp + "| Armor: " + armor.hp + " Sword: " + sword.hp + "\n" +
                    "____________________________________\n");
            }
        }
        string MonsterName()
        {
            List<string> name = new List<string> { "Zombie", "Orc", "Goblin", "Troll", "Vapire", "Wolfman" };
            Random rnd = new Random();
            return name[rnd.Next(name.Count)];
        }
        int Random(int min, int max)
        {
            Random rnd = new Random();
            return min + rnd.Next(max - min);
        }
        int Random(int max)
        {
            Random rnd = new Random();
            return rnd.Next(max);
        }
        void Battle(Hero hero1, Hero hero2)
        {
            hero1.Info();
            hero2.Info();
            MessageBox.Show("------------------BATLLE-----------------\n");
            while (hero1.hp > 0 && hero2.hp > 0)
            {
                hero1.hp = hero1.hp + hero1.armor.lvl - (hero2.damage + hero2.sword.lvl);
                hero2.hp = hero2.hp + hero2.armor.lvl - (hero1.damage + hero1.sword.lvl);
                hero1.armor.hp--;
                hero2.armor.hp--;
                hero1.sword.hp--;
                hero2.sword.hp--;
                if (hero1.armor.hp <= 0)
                    hero1.armor.lvl = 0;
                if (hero2.armor.hp <= 0)
                    hero2.armor.lvl = 0;
                if (hero1.sword.hp <= 0)
                    hero1.sword.lvl = 0;
                if (hero2.sword.hp <= 0)
                    hero2.sword.lvl = 0;
            }
            if (hero1.hp > 0)
            {
                MessageBox.Show("------------------" + hero1.name + " WIN-----------------\n");
                hero1.damage++;
                hero1.money += 10;
            }
            if (hero2.hp > 0)
            {
                MessageBox.Show("------------------" + hero2.name + " WIN-----------------\n");
                hero2.damage++;
                hero2.money += 10;
            }
            hero1.Info();
            hero2.Info();
        }
        void FirstAID(Hero hero, bool info = false)
        {
            if (hero.money >= 10)
            {
                hero.hp += 10;
                hero.money -= 10;
            }
            else
                MessageBox.Show("Money is over\n");
            if (info == true)
                hero.Info();
        }
        void Work(Hero hero)
        {
            MessageBox.Show("------------------Guess the number------------------\n");
            Random rnd = new Random();
            int x = rnd.Next(100);
            int num = -1;
            while (num != x)
            {
                num = Convert.ToInt32(Interaction.InputBox("Enter your number"));
                if (x < num)
                    MessageBox.Show("less\n");
                if (x > num)
                    MessageBox.Show("more\n");
            }
            MessageBox.Show("------------------ +10 MONEY ------------------\n");
            hero.money += 10;
            hero.Info();
        }
        void Shop(Hero hero)
        {
            MessageBox.Show("1.Stone sword| lvl: 2, hp: 7, money: 10\n" +
                "2.Iron sword| lvl: 4, hp: 15, money: 40\n" +
                "3.Diamond sword| lvl: 7, hp: 25, money: 100\n" +
                "4.Legendary sword| lvl: 99, hp: 999, money: 7\n" +
                "5.Exit\n");
            int choice = Convert.ToInt32(Interaction.InputBox("Enter your choice"));
            switch (choice)
            {
                case 1:
                    if (hero.money >= 10)
                    {
                        hero.sword = new Item { lvl = 2, hp = 7 };
                        hero.money -= 10;
                    }
                    else
                        MessageBox.Show("Not enough money\n");
                    break;
                case 2:
                    if (hero.money >= 40)
                    {
                        hero.sword = new Item { lvl = 4, hp = 15 };
                        hero.money -= 40;
                    }
                    else
                        MessageBox.Show("Not enough money\n");
                    break;
                case 3:
                    if (hero.money >= 100)
                    {
                        hero.sword = new Item { lvl = 7, hp = 25 };
                        hero.money -= 100;
                    }
                    else
                        MessageBox.Show("Not enough money\n");
                    break;
                case 4:
                    if (hero.money >= 999)
                    {
                        hero.sword = new Item { lvl = 99, hp = 999 };
                        hero.money -= 999;
                    }
                    else
                        MessageBox.Show("Not enough money\n");
                    break;
                case 5:
                    break;
                default:
                    MessageBox.Show("Invalid choice\n");
                    break;
            }
            hero.Info();
        }
        void Explore(Hero hero)
        {
            MessageBox.Show("------------------Exploring...------------------\n");
            int monstersCount = Random(3, 6);
            List<Hero> monsters = new List<Hero>();
            for (int i = 0; i < monstersCount; i++)
            {
                var monster = new Hero(MonsterName(), Random(1, 5), Random(20, 50));
                monsters.Add(monster);
                Battle(hero, monster);
            }
            MessageBox.Show("------------------End of exploration------------------\n");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Work(hero);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Shop(hero);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Explore(hero);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var enemy = new Hero("Enemy", Random(1, 5), Random(20, 50));
            Battle(hero, enemy);
        }
        private Hero hero = new Hero("Hero", 5, 100);
        private void button5_Click(object sender, EventArgs e)
        {
            FirstAID(hero);
        }
    }
}