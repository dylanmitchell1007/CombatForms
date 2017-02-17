using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombatForms
{

    public partial class Form1 : Form
    {

        public enum GameNumber
        {
            round1 = 1,
            round2 = 2,
            round3 = 3,
            round4 = 4,
            round5 = 5,
            round6 = 6,
            round7 = 7,
            round8 = 8,
            round9 = 9,
            round10 = 10,
            round11 = 11,
            round12 = 12,
            round13 = 13,
            round14 = 14,
            round15 = 15,
            round16 = 16,
            round17 = 17,
            round18 = 18,
            round19 = 19,
            round20 = 20,
            round21 = 21,
            round22 = 22,
            round23 = 23,
            round24 = 24,
            round25 = 25,
            round26 = 26,
            round27 = 27,
            round28 = 28,
            round29 = 29,
            round30 = 30,
            round31 = 31,







        }

        GameNumber currentlevel;

        FSM<GameNumber> GameFsm;
        RoundFunctions rf;

       




        public Form1()
        {
            InitializeComponent();
            Singleton.Instance.Player = new Player(100, 10, 5, "P1", 0, 1 );
            Singleton.Instance.Gameform = this;
            currentlevel = GameNumber.round1;
            GameFsm = new FSM<GameNumber>();
            rf = new RoundFunctions();

            GameFsm.AddTransition(GameNumber.round1, GameNumber.round2);
            GameFsm.AddTransition(GameNumber.round2, GameNumber.round3);
            GameFsm.AddTransition(GameNumber.round3, GameNumber.round4);
            GameFsm.AddTransition(GameNumber.round4, GameNumber.round5);
            GameFsm.AddTransition(GameNumber.round5, GameNumber.round6);
            GameFsm.AddTransition(GameNumber.round6, GameNumber.round7);
            GameFsm.AddTransition(GameNumber.round7, GameNumber.round8);
            GameFsm.AddTransition(GameNumber.round8, GameNumber.round9);
            GameFsm.AddTransition(GameNumber.round9, GameNumber.round10);
            GameFsm.AddTransition(GameNumber.round10, GameNumber.round11);
            GameFsm.AddTransition(GameNumber.round11, GameNumber.round12);
            GameFsm.AddTransition(GameNumber.round12, GameNumber.round13);
            GameFsm.AddTransition(GameNumber.round13, GameNumber.round14);
            GameFsm.AddTransition(GameNumber.round14, GameNumber.round15);
            GameFsm.AddTransition(GameNumber.round15, GameNumber.round16);
            GameFsm.AddTransition(GameNumber.round16, GameNumber.round17);


            GameFsm.addOnEnter(GameNumber.round1, (Handler)rf.Round1Enter);
            GameFsm.addOnExit(GameNumber.round1, (Handler)rf.Round1Exit);
            GameFsm.addOnEnter(GameNumber.round2, (Handler)rf.Round2Enter);
            GameFsm.addOnExit(GameNumber.round2, (Handler)rf.Round2Exit);
            GameFsm.addOnEnter(GameNumber.round3, (Handler)rf.Round3Enter);
            GameFsm.addOnExit(GameNumber.round3, (Handler)rf.Round3Exit);
            GameFsm.addOnEnter(GameNumber.round4, (Handler)rf.Round4Enter);
            GameFsm.addOnExit(GameNumber.round4, (Handler)rf.Round4Exit);
            GameFsm.addOnEnter(GameNumber.round5, (Handler)rf.Round5Enter);
            GameFsm.addOnExit(GameNumber.round5, (Handler)rf.Round5Exit);
            GameFsm.addOnEnter(GameNumber.round6, (Handler)rf.Round6Enter);
            GameFsm.addOnExit(GameNumber.round6, (Handler)rf.Round6Exit);
            GameFsm.addOnEnter(GameNumber.round7, (Handler)rf.Round7Enter);
            GameFsm.addOnExit(GameNumber.round7, (Handler)rf.Round7Exit);
            GameFsm.addOnEnter(GameNumber.round8, (Handler)rf.Round8Enter);
            GameFsm.addOnExit(GameNumber.round8, (Handler)rf.Round8Exit);
            GameFsm.addOnEnter(GameNumber.round9, (Handler)rf.Round9Enter);
            GameFsm.addOnExit(GameNumber.round9, (Handler)rf.Round9Exit);
            GameFsm.addOnEnter(GameNumber.round10, (Handler)rf.Round10Enter);
            GameFsm.addOnExit(GameNumber.round10, (Handler)rf.Round10Exit);
            GameFsm.addOnEnter(GameNumber.round11, (Handler)rf.Round11Enter);
            GameFsm.addOnExit(GameNumber.round11, (Handler)rf.Round11Exit);
            GameFsm.addOnEnter(GameNumber.round12, (Handler)rf.Round12Enter);
            GameFsm.addOnExit(GameNumber.round12, (Handler)rf.Round12Exit);
            GameFsm.addOnEnter(GameNumber.round13, (Handler)rf.Round13Enter);
            GameFsm.addOnExit(GameNumber.round13, (Handler)rf.Round13Exit);
            GameFsm.addOnEnter(GameNumber.round14, (Handler)rf.Round14Enter);
            GameFsm.addOnExit(GameNumber.round14, (Handler)rf.Round14Exit);





            GameFsm.Start(GameNumber.round1);
           
            



            Singleton.Instance.NinjaList = new List<Ninja>();

            for (int a = 1; a <= 100; a++)
            {
                Singleton.Instance.NinjaList.Add(new Ninja(100, 5 + Singleton.Instance.RoundNumber, "Ninja " + a));
            }
            richTextBox4.Text = "\n Lifes:" + Singleton.Instance.Player.Lifes + "\n Attack: " + Singleton.Instance.Player.Attack;

            richTextBox5.Text = "\n Attack: ";
            Singleton.Instance.NinjaIndex = 0;

            Singleton.Instance.CurrentNinja = Singleton.Instance.NinjaList[Singleton.Instance.NinjaIndex];



            progressBar2.Value = (int)Singleton.Instance.Player.Health;
            progressBar1.Value = (int)Singleton.Instance.CurrentNinja.Health;
            richTextBox3.Text = "Round" + currentlevel++;

            this.button7.Enabled = false;
            //store button.
            this.button10.Enabled = false;
            this.button10.Visible = false;
            ActivityLabel.Visible = false;

            Update();
            RoundLevel();
        }


        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Singleton.Instance.Player.GiveDamage(Singleton.Instance.CurrentNinja);
            RoundLevel();
            Update();            
            Singleton.Instance.CurrentNinja.GiveDamage(Singleton.Instance.Player);
            RoundLevel();
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Singleton.Instance.CurrentNinja.GiveDamage(Singleton.Instance.Player);
            RoundLevel();
            Update();
            Singleton.Instance.Player.GiveDamage(Singleton.Instance.CurrentNinja);
            RoundLevel();
            Update();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "Player";
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public new void Update()
        {

            //RoundLevel();
            richTextBox4.Text = "\n Lifes:" + Singleton.Instance.Player.Lifes + "\n Attack: " + Singleton.Instance.Player.Attack;

            richTextBox5.Text = "\n Attack: " + Singleton.Instance.CurrentNinja.Attack;
            //CurrentNinja Health Conditions.
            if (Singleton.Instance.CurrentNinja.Health <= 0)
            {

                //currentlevel++;
                Singleton.Instance.P1Score += 100;
                Singleton.Instance.CurrentNinja.Health = 100;
                Singleton.Instance.Player.Lifes++;
                Singleton.Instance.NinjaIndex++;
                Singleton.Instance.NinjaList[Singleton.Instance.NinjaIndex].Attack += Singleton.Instance.RoundNumber;
                Singleton.Instance.CurrentNinja = Singleton.Instance.NinjaList[Singleton.Instance.NinjaIndex];
                Singleton.Instance.RoundNumber++;
            

                //When advance past round (12)
                if (Singleton.Instance.RoundNumber >= 12)
                {
                    button7.Enabled = true;
                    button7.Text = "Knife (" + Singleton.Instance.Player.Knifedurability + "%)";
                }
                //When advance past round (16) 
                if (Singleton.Instance.RoundNumber >= 16)
                {
                    Singleton.Instance.CurrentNinja.Attack = 15;
                    button8.Enabled = true;
                    button8.Text = "HealthPack(" + Singleton.Instance.Player.HealthPackdurability + "%)";

                }

                //When advance to round (17) 
                if (Singleton.Instance.RoundNumber == 17)
                {
                    label3.Text = "<---USE THIS BOOST";
                }

                //When advance to round (18)
                if (Singleton.Instance.RoundNumber == 18)
                {
                    button9.Text = "Wait for more";
                    label3.Hide();
                    button9.Enabled = true;
                    button9.Text = "Attack Boost: (" + Singleton.Instance.CurrentNinja.Attack + "%)";

                    //When advance to round (25) 
                    if (Singleton.Instance.RoundNumber == 25)
                    {
                        Singleton.Instance.Player.Knifedurability = 100;
                        button9.Enabled = true;
                        label3.Text = "<---USE THIS BOOST";

                        //button9.Text = "Attack Boost: (" + Singleton.Instance.CurrentNinja.Attack + "%)";
                        Singleton.Instance.CurrentNinja.Attack = 23;
                    }

                    //When advance to round (26)
                    if (Singleton.Instance.RoundNumber == 26)
                    {
                        button9.Enabled = false;
                    }

                    if (Singleton.Instance.Player.HealthPackdurability == 0)
                    {
                        HealthPackLabel.Text = "Your out of HealthPacks!!";
                    }

                    // Update();
                }

                if (Singleton.Instance.CurrentNinja.Health <= 0)
                {
                    Singleton.Instance.Player.Lifes = 5;
                }

            }

            if (Singleton.Instance.Player.HealthPackdurability == 0)
            {
                HealthPackLabel.Text = "Your Out Of HealthPacks";
                button8.Enabled = false;

            }

            if (Singleton.Instance.Player.Lifes == 0)
            {
                Application.Restart();
            }

            if (Singleton.Instance.Player.Health >= 100)
            {
                Singleton.Instance.Player.Health = 100;
            }



            Singleton.Instance.CurrentNinja = Singleton.Instance.NinjaList[Singleton.Instance.NinjaIndex];

            if (Singleton.Instance.CurrentNinja.Health <= 0)
            {
                //currentlevel++;
                Singleton.Instance.NinjaIndex++;
            
            }

           currentlevel = (GameNumber)GameFsm.GetCurrentState().stateName;







            progressBar2.Value = (int)Singleton.Instance.Player.Health;
            progressBar1.Value = (int)Singleton.Instance.CurrentNinja.Health;
            richTextBox3.Text = currentlevel.ToString();

            richTextBox6.Text = "Player Score: " + Singleton.Instance.P1Score;


        }

        public void RoundLevel()
        {
            switch (currentlevel)
            {

                case GameNumber.round1:
                    {

                        //richTextBox3.Text = currentlevel.ToString();



                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round2);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }


                case GameNumber.round2:
                    {

                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {
                            GameFsm.ChangeState(GameNumber.round3);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }


                case GameNumber.round3:
                    {
                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {
                            GameFsm.ChangeState(GameNumber.round4);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }


                case GameNumber.round4:
                    {
                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {
                            GameFsm.ChangeState(GameNumber.round5);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }

                case GameNumber.round5:
                    {

                        ActivityLabel.Visible = true;
                        ActivityLabel.Text = "Unlocked Store!!";

                        this.button10.Enabled = true;
                        this.button10.Visible = true;

                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round6);
                            Singleton.Instance.P1Score += 100;
                            Singleton.Instance.CurrentNinja.Health = 100;
                            RoundLevel();
                            Update();

                        }
                        break;
                    }


                case GameNumber.round6:
                    {

                        ActivityLabel.Visible = false;
                        this.button10.Enabled = true;
                        this.button10.Visible = true;

                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round7);
                            Singleton.Instance.P1Score += 100;
                            Singleton.Instance.CurrentNinja.Health = 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }


                case GameNumber.round7:
                    {

                        //richTextBox3.Text = currentlevel.ToString();


                        this.button10.Enabled = true;
                        this.button10.Visible = true;

                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round8);
                            Singleton.Instance.P1Score += 100;
                            Singleton.Instance.CurrentNinja.Health = 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }


                case GameNumber.round8:
                    {

                        //richTextBox3.Text = currentlevel.ToString();

                        this.button10.Enabled = true;
                        this.button10.Visible = true;


                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round9);
                            Singleton.Instance.P1Score += 100;
                            Singleton.Instance.CurrentNinja.Health = 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }

                case GameNumber.round9:
                    {

                        //richTextBox3.Text = currentlevel.ToString();

                        this.button10.Enabled = true;
                        this.button10.Visible = true;


                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round10);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }


                case GameNumber.round10:
                    {

                        //richTextBox3.Text = currentlevel.ToString();

                        this.button10.Enabled = true;
                        this.button10.Visible = true;


                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round11);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }

                case GameNumber.round11:
                    {

                        //richTextBox3.Text = currentlevel.ToString();

                        this.button10.Enabled = true;
                        this.button10.Visible = true;


                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round12);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }


                case GameNumber.round12:
                    {
                        this.button10.Enabled = true;
                        this.button10.Visible = true;

                        //richTextBox3.Text = currentlevel.ToString();
                        if (currentlevel == GameNumber.round12)
                        {
                            button7.Enabled = true;
                            button7.Text = "Knife (" + Singleton.Instance.Player.Knifedurability + "%)";
                        }


                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round13);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }

                case GameNumber.round13:
                    {

                        //richTextBox3.Text = currentlevel.ToString();

                        this.button10.Enabled = true;
                        this.button10.Visible = true;


                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round14);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }

                case GameNumber.round14:
                    {

                        //richTextBox3.Text = currentlevel.ToString();

                        this.button10.Enabled = true;
                        this.button10.Visible = true;


                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round15);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }

                case GameNumber.round15:
                    {

                        //richTextBox3.Text = currentlevel.ToString();
                        this.button10.Enabled = true;
                        this.button10.Visible = true;



                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round16);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }

                case GameNumber.round16:
                    {

                        //richTextBox3.Text = currentlevel.ToString();
                        this.button10.Enabled = true;
                        this.button10.Visible = true;



                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round17);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }



                case GameNumber.round17:
                    {
                        this.button10.Enabled = true;
                        this.button10.Visible = true;

                        //richTextBox3.Text = currentlevel.ToString();



                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round18);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }


                case GameNumber.round18:
                    {
                        this.button10.Enabled = true;
                        this.button10.Visible = true;

                        //richTextBox3.Text = currentlevel.ToString();



                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round19);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }


                case GameNumber.round19:
                    {
                        this.button10.Enabled = true;
                        this.button10.Visible = true;

                        //richTextBox3.Text = currentlevel.ToString();



                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round20);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }


                case GameNumber.round20:
                    {
                        this.button10.Enabled = true;
                        this.button10.Visible = true;


                        //richTextBox3.Text = currentlevel.ToString();



                        if (Singleton.Instance.CurrentNinja.Health <= 0)
                        {

                            GameFsm.ChangeState(GameNumber.round21);
                            Singleton.Instance.CurrentNinja.Health = 100;
                            Singleton.Instance.P1Score += 100;
                            RoundLevel();
                            Update();
                        }
                        break;
                    }
            }
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Player p = Singleton.Instance.Player;

            SaveLoad<Player>.Serialize("Player", Singleton.Instance.Player);

            //SaveLoad<GameNumber>.Serialize("Player lvl", currentlevel);
            //SaveLoad<int>.Serialize("Player Score", Singleton.Instance.P1Score);

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
           
            Singleton.Instance.Player = SaveLoad<Player>.Deserialize("Player");
            Singleton.Instance.P1Score = SaveLoad<int>.Deserialize("Player Score");
            richTextBox6.Text = "Player Score: " + Singleton.Instance.P1Score;
            richTextBox4.Text = "\n Lifes:" + Singleton.Instance.Player.Lifes + "\n Attack: " + Singleton.Instance.Player.Attack;
            richTextBox5.Text = "\n Attack: " + Singleton.Instance.CurrentNinja.Attack;
            richTextBox3.Text = currentlevel.ToString();
            Update();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Singleton.Instance.Player.Knifedurability <= 0)
            {
                button7.Enabled = false;

            }
            else
                Singleton.Instance.Player.Knife(Singleton.Instance.CurrentNinja);

            button7.Text = "Knife (" + Singleton.Instance.Player.Knifedurability + "%)";
            Update();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Singleton.Instance.RoundNumber >= 17)
            {
                HealthPackLabel.Text = "Used HealthPack";
                Update();
                Singleton.Instance.Player.HealthPack(Singleton.Instance.Player);
                Update();


            }
            //p1.HealthPack(p1);
            progressBar2.Value = (int)Singleton.Instance.Player.Health;
            Update();
            ////p1.Health++;       
            if (Singleton.Instance.Player.HealthPackdurability <= 0)
            {
                button8.Enabled = false;
                button8.Text = "0";
            }
        }
        int i = 0;
        private void button9_Click(object sender, EventArgs e)
        {
            if (Singleton.Instance.RoundNumber == 25)
            {
                button9.Enabled = true;
                button9.Text = "Attack Boost: (" + Singleton.Instance.CurrentNinja.Attack + "%)";
            }
            if (Singleton.Instance.RoundNumber == 17)
            {
                button9.Enabled = true;

                Update();
                Singleton.Instance.Player.AttackBoost(Singleton.Instance.CurrentNinja);

                button9.Enabled = true;
                button9.Text = "Attack Boost: (" + Singleton.Instance.CurrentNinja.Attack + "%)";
            }
            Update();
        }

        private void label2_Click(object sender, EventArgs e)
        {
          
        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {
            if (Singleton.Instance.RoundNumber >= 1)
            {
                Update();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // save 

            if (currentlevel >= GameNumber.round5)
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
                Update();
            }
        }





    }

    class RoundFunctions
    {
        public RoundFunctions()
        {

        }

        public void Round1Enter()
        {
            Console.WriteLine("Enter Round: 1");

        }
        public void Round1Exit()
        {
            Console.WriteLine("Exit Round: 1");
   
        }
        public void Round2Enter()
        {
            Console.WriteLine("Enter Round: 2");
        }
        public void Round2Exit()
        {
            Console.WriteLine("Exit Round: 2");
           
        }
        public void Round3Enter()
        {
            Console.WriteLine("Enter Round: 3");
        }
        public void Round3Exit()
        {
            Console.WriteLine("Exit Round: 3");
           
        }
        public void Round4Enter()
        {
            Console.WriteLine("Enter Round: 4");
        }
        public void Round4Exit()
        {
            Console.WriteLine("Exit Round: 4");
           
        }
        public void Round5Enter()
        {
            Console.WriteLine("Enter Round: 5");
        }
        public void Round5Exit()
        {
            Console.WriteLine("Exit Round: 5");
            Singleton.Instance.CurrentNinja.Health = 100;
        }
        public void Round6Enter()
        {
            Console.WriteLine("E Round: 6");
        }
        public void Round6Exit()
        {
            Console.WriteLine("Exit Round: 6");
            Singleton.Instance.CurrentNinja.Health = 100;
        }
        public void Round7Enter()
        {
            Console.WriteLine("Exit Round: 7");
        }
        public void Round7Exit()
        {
            Console.WriteLine("Exit Round: 7");
        }
        public void Round8Enter()
        {
            Console.WriteLine("Exit Round: 8");
        }
        public void Round8Exit()
        {
            Console.WriteLine("Exit Round: 8");
        }
        public void Round9Enter()
        {

        }
        public void Round9Exit()
        {

        }
        public void Round10Enter()
        {

        }
        public void Round10Exit()
        {

        }
        public void Round11Enter()
        {

        }
        public void Round11Exit()
        {

        }
        public void Round12Enter()
        {

        }
        public void Round12Exit()
        {

        }
        public void Round13Enter()
        {

        }
        public void Round13Exit()
        {

        }
        public void Round14Enter()
        {

        }
        public void Round14Exit()
        {

        }
        public void Round15Enter()
        {

        }
        public void Round15Exit()
        {

        }
        public void Round16Enter()
        {

        }
        public void Round16Exit()
        {

        }
        public void Round17Enter()
        {

        }
        public void Round17Exit()
        {

        }
        public void Round18Enter()
        {

        }
        public void Round18Exit()
        {

        }
        public void Round19Enter()
        {

        }
        public void Round19Exit()
        {

        }
        public void Round20Enter()
        {

        }
        public void Round20Exit()
        {

        }
        public void Round21Enter()
        {

        }
        public void Round21Exit()
        {

        }
        public void Round22Enter()
        {

        }
        public void Round22Exit()
        {

        }
        public void Round23Enter()
        {

        }
        public void Round23Exit()
        {

        }
        public void Round24Enter()
        {

        }
        public void Round24Exit()
        {

        }
        public void Round25Enter()
        {

        }
        public void Round25Exit()
        {

        }
        public void Round26Enter()
        {

        }
        public void Round26Exit()
        {

        }
        public void Round27Enter()
        {

        }
        public void Round27Exit()
        {

        }
        public void Round28Enter()
        {

        }
        public void Round28Exit()
        {

        }

    }
}