using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombatForms
{ 
    delegate void Handler();
    delegate void Callback();
    delegate void CallbackString(State St);
    class CurrentPlayer
    {
        public CurrentPlayer()
        {

        }
    }

    public enum GameStates
    {
        INIT,
        START,
        EXIT,
    }

    class Program
    {

        class Player
        {
            public Player()
            {
                onTalk = null;
                hp = 100;
                onDamaged += TakeDamage;
                onDamaged += DeathSound;

            }
            public void DeathSound(int num)
            {

            }
            public void Attack(Player other)
            {
                other.onDamaged.Invoke(attackPower);
            }

            public void TakeDamage(int amount)
            {
                hp -= amount;
            }

            int attackPower;
            int hp;
            public void Talk(string s)
            {
                onTalk.Invoke(s);
            }
            public Callback<string> onTalk;

            public void AddTalk(Delegate cb)
            {
                onTalk += cb as Callback<string>;
            }

            OnDamaged<int> onDamaged;
        }
        public delegate void OnDamaged<T>(T p);

        static void Main(string[] args)
        {
            Player player = new Player();
            Player dylan = new Player();
            Player matthew = new Player();
            dylan.Attack(matthew);
            player.AddTalk((Callback<string>)SaySomething);
            player.AddTalk((Callback<string>)SayAnotherThing);
            player.Talk("\n -Dylan:");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
            static public void ChangeState(GameStates gs)
        {
            
        }
        delegate void Callback();
        delegate void Callback<T>(T n);
        static public void SaySomething(string s)
        {
            Console.WriteLine("-SaySomething " + s);
        }

        static public void SayAnotherThing(string s)
        {
            Console.WriteLine("-SayAnotherThing " + s);

        }


    