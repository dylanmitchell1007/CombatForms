using CombatForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatForms
{
   
   
class Singleton
    {
        private int roundnumber;
        

        public int RoundNumber
        {
           get { return roundnumber;}
            set { roundnumber = value;}
        }
            


      
        private static readonly Singleton instance = new Singleton();
        private Singleton()
        {
            roundnumber = 1;   
        }
        public static Singleton Instance
        {
            get{ return instance; }
            
        }
    }
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
        void TakeDamage(float damage);



    }
    public interface IDamage
    {
        void GiveDamage(IDamageable something);
        //void Knife(IDamageable damage);
        

    }



    public class Player : IDamageable, IDamage
    {
        //make these private
        private float lifes;
        private float attack;
        private float health;
        private float knife;
     

      
        
        public float Lifes
        {
            get { return lifes; }
            set { lifes = value; }
        }

        

        public float Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public float Health
        {
            get { return health; }
            set { health = value; }
        }
      
        public Player()
        {

        }
        public Player(float Health, float Attack, float Lifes, string name)
        {
       
            health = Health;
            attack = Attack;
            lifes = Lifes;
            
           

        }

      

        public void TakeDamage(float damage)
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
        public void Knife(IDamageable damage)
        {
            
            damage.TakeDamage(attack);
        }
     
        public void GiveDamage(IDamageable something)
        {
            
            something.TakeDamage(attack);
        }
      
    }

        public delegate void OnDamaged<T>(T p);
    }




