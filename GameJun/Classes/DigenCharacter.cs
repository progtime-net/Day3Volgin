using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJun.Interfaces;

namespace GameJun.Classes
{
    public class DigenCharacter : AbstractCharacter
    {
        public DigenCharacter()
        {
            health = 20;
            defense = 5;
            damage = 5;
            name = "Digen";
    }

        public override void Attack(AbstractCharacter other)
        {
            other.Damage(damage);
        }

        public override void Damage(int amount)
        {
            if(amount > defense)
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
            if(health <= 0)
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
