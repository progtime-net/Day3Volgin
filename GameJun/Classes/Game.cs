using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJun.Interfaces;
using GameJun.Classes;

namespace GameJun.Classes
{
    public class Game : AbstractGame
    {
        AbstractCharacter choosen = null;
        AbstractCharacter enemy = null;
        public override void SelectPlayers()
        {
            Console.WriteLine("Выбери бойца:");
            Console.WriteLine(" - Digen");
            Console.WriteLine(" - Ilya");
            Console.WriteLine(" - Tolya");
            string a = Console.ReadLine();
            AbstractCharacter[] characters = new AbstractCharacter[] { new TolyaCharacter(), new DigenCharacter(), new IlyaCharacter() };
            foreach (AbstractCharacter character in characters)
            {
                if(character.Name == a)
                {
                    choosen = character;
                }
            }
            Random rand = new Random();
            while (!(choosen != enemy && enemy != null))
            {
                enemy = characters[rand.Next(0, 3)];
            }
            Console.WriteLine($"Вы выбрали {choosen.Name}, ваш противник {enemy.Name}!");
            Console.WriteLine();
        } 

        public override void Start()
        {
            Console.WriteLine("ДА НАЧНЕТСЯ БИТВА!!!");
            Console.WriteLine();
            while(choosen.IsAlive() && enemy.IsAlive())
            {
                GameStep();
            }
            if (choosen.IsAlive() && !enemy.IsAlive())
            {
                Console.WriteLine($"Ура! В этой битве победил {choosen.Name}, вы одержали победу!!!");
            }
            else if(!choosen.IsAlive() && enemy.IsAlive())
            {
                Console.WriteLine($"О нет! В этой битве победил {enemy.Name}, кажется, вы проиграли...");
            }
            else if (!choosen.IsAlive() && !enemy.IsAlive())
            {
                Console.WriteLine($"Оу! Видимо ничья.....");
            }

        }

        protected override void GameStep()
        {
            Console.WriteLine($"Атакует {choosen.Name}!");
            choosen.Attack(enemy);
            Console.WriteLine($"У {enemy.Name} осталось {enemy.Health} здоровья! Как напряженно!");
            Console.WriteLine();
            Console.WriteLine($"Теперь атакует {enemy.Name}!");
            enemy.Attack(choosen);
            Console.WriteLine($"У {choosen.Name} осталось {choosen.Health} здоровья! Как напряженно!");
            Console.ReadLine();
        }
    }
}
