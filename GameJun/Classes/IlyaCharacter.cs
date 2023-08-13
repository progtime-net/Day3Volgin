using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJun.Interfaces;

namespace GameJun.Classes
{
    public class IlyaCharacter : AbstractCharacter
    {
        public IlyaCharacter()
        {
            health = 10;
            defense = 3;
            damage = 10;
            name = "Ilya";
        }
        public override void Attack(AbstractCharacter other)
        {
            other.Damage(damage);
        }

        public override void Damage(int amount)
        {
            if (amount > defense)
            {
                health -= amount - defense;
            }
            if (health <= 0)
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
