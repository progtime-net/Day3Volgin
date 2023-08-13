using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJun.Interfaces;

namespace GameJun.Classes
{
    public class TolyaCharacter :AbstractCharacter
    {
        public TolyaCharacter()
        {
            health = 15;
            defense = 3;
            damage = 7;
            name = "Tolya";
        }
        public override void Attack(AbstractCharacter other)
        {
            Random random = new Random();
            other.Damage(random.Next(damage - 2, damage + 3));
        }

        public override void Damage(int amount)
        {
            if (amount > defense)
            {
                health -= amount - defense;
            }
            if(health <= 0)
            {
                health = 0;
            }
        }

        public override bool IsAlive()
        {
            if (health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
