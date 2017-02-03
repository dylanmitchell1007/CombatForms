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
    class CurrentPlayer : Form
    {
        public Player p;



        public void StartRound(int a)
        {
            Ninja n1 = new Ninja(100, 15, "N1");
            a = 1;
            if (n1.Health == 0)
            {
                a++;
            }
        



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

            static void Main(string[] args)
            {
           
                //    Player player = new Player();
                //    Player dylan = new Player();
                //    Player matthew = new Player();
                //    dylan.Attack(matthew);
                //    //player.AddTalk((Callback<string>)SaySomething);
                //    //player.AddTalk((Callback<string>)SayAnotherThing);
                //    player.Talk("\n -Dylan:");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                Application.Exit();
            }
            //    static public void ChangeState(GameStates gs)
            //{

            //}
            //delegate void Callback();
            //delegate void Callback<T>(T n);
            //static public void SaySomething(string s)
            //{
            //    Console.WriteLine("-SaySomething " + s);
            //}

            //static public void SayAnotherThing(string s)
            //{
            //    Console.WriteLine("-SayAnotherThing " + s);

            //}

        }
    }


    