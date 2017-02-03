using CombatForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatForms
{


    public enum PlayerState
    {
        INIT,
        IDLE,
        Attack,
        Exit,
    }






    /// <summary>
    /// This is the inteface Attemp 1.
    /// Ninja vs Zombie.
    /// </summary>
    public interface IDamageable
    {
        void TakeDamage(int damage);



    }
    public interface IDamage
    {
        void GiveDamage(IDamageable something);

    }



    public class Player : IDamageable, IDamage
    {
        //make these private
        private int lifes;
        private int attack;
        private int health;
        public float Lifes
        {
            get { return lifes; }
        }

        public float Attack
        {
            get { return attack; }
        }
        public float Health
        {
            get { return health; }
        }

        public Player(int Health, int Attack, int Lifes, string name)
        {
            name = null;
            health = Health;
            attack = Attack;
            lifes = Lifes;

        }


        public void TakeDamage(int damage)
        {
            health -= damage;
            if(health<= 0)
            {
                lifes--;
                health = 100;

             }
            if(lifes<= 0)
            {
                Console.WriteLine("YOU LOSE");
            }
        }

        public void GiveDamage(IDamageable something)
        {
            something.TakeDamage(attack);
        }
    }

        public delegate void OnDamaged<T>(T p);
    }




