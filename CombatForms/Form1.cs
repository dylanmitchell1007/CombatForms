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
        public Form1()
        {            
            InitializeComponent();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Singleton.Instance.Player = new Player(100, 10, 5, "P1");

            Singleton.Instance.NinjaList = new List<Ninja>();

            for (int a = 1; a < 101; a++)
            {
                Singleton.Instance.NinjaList.Add(new Ninja(100, 5 + Singleton.Instance.RoundNumber, "Ninja " + a));
            }

            Singleton.Instance.NinjaIndex = 0;

            Singleton.Instance.CurrentNinja = Singleton.Instance.NinjaList[Singleton.Instance.NinjaIndex];

            Update();

            progressBar2.Value = (int)Singleton.Instance.Player.Health;
            progressBar1.Value = (int)Singleton.Instance.CurrentNinja.Health;
            richTextBox3.Text = "Round: " + Singleton.Instance.RoundNumber;

            this.button7.Enabled = false;

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
            Update();
            Singleton.Instance.CurrentNinja.GiveDamage(Singleton.Instance.Player);
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Singleton.Instance.CurrentNinja.GiveDamage(Singleton.Instance.Player);
            Update();
            Singleton.Instance.Player.GiveDamage(Singleton.Instance.CurrentNinja);
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
            if (Singleton.Instance.Player.HealthPackdurability == 0)
            {
                HealthPackLabel.Text = "Your out of HealthPacks!!";
            }
            richTextBox4.Text = "\n Lifes:" + Singleton.Instance.Player.Lifes + "\n Attack: " + Singleton.Instance.Player.Attack;

            richTextBox5.Text = "\n Attack: " + Singleton.Instance.CurrentNinja.Attack;

            if (Singleton.Instance.RoundNumber == 26)
            {
                button9.Enabled = false;
            }
            if (Singleton.Instance.RoundNumber == 25)
            {
                Singleton.Instance.Player.Knifedurability = 100;
                button9.Enabled = true;
                label3.Text = "<---USE THIS BOOST";

                button9.Text = "Attack Boost: (" + Singleton.Instance.CurrentNinja.Attack + "%)";
                Singleton.Instance.CurrentNinja.Attack = 23;

            }
            if (Singleton.Instance.CurrentNinja.Health <= 0)
            {
                Singleton.Instance.P1Score += 100;
                Singleton.Instance.CurrentNinja.Health = 100;
                Singleton.Instance.RoundNumber++;
                Singleton.Instance.Player.Lifes++;
                Singleton.Instance.NinjaIndex++;
                Singleton.Instance.NinjaList[Singleton.Instance.NinjaIndex].Attack += Singleton.Instance.RoundNumber;
                Singleton.Instance.CurrentNinja = Singleton.Instance.NinjaList[Singleton.Instance.NinjaIndex];
                if (Singleton.Instance.RoundNumber >= 12)
                {
                    button7.Enabled = true;
                    button7.Text = "Knife (" + Singleton.Instance.Player.Knifedurability + "%)";
                }
                if (Singleton.Instance.RoundNumber >= 16)
                {
                    Singleton.Instance.CurrentNinja.Attack = 15;
                    button8.Enabled = true;
                    button8.Text = "HealthPack(" + Singleton.Instance.Player.HealthPackdurability + "%)";

                }

                Update();
            }
            if (Singleton.Instance.RoundNumber == 18)
            {
                button9.Enabled = true;
                button9.Text = "Attack Boost: (" + Singleton.Instance.CurrentNinja.Attack + "%)";



                if (Singleton.Instance.CurrentNinja.Health <= 0)
                {
                    Singleton.Instance.Player.Lifes = 5;
                }

            }
            if (Singleton.Instance.RoundNumber == 17)
            {
                label3.Text = "<---USE THIS BOOST";

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




            //if(currentNinja.Health <= 0)
            //     {
            //         progressBar1.Value = 100;
            //         currentNinja.Health = 100;
            //     }
            progressBar2.Value = (int)Singleton.Instance.Player.Health;
            progressBar1.Value = (int)Singleton.Instance.CurrentNinja.Health;
            richTextBox3.Text = "Round: " + Singleton.Instance.RoundNumber;
            richTextBox6.Text = "Player Score: " + Singleton.Instance.RoundNumber + 100;
        }


        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


            SaveLoad<Player>.Serialize("Player", Singleton.Instance.Player);
            SaveLoad<int>.Serialize("RoundNumber", Singleton.Instance.RoundNumber);

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Singleton.Instance.RoundNumber = SaveLoad<int>.Deserialize("DebugRoundNumber");
            Singleton.Instance.Player = SaveLoad<Player>.Deserialize("DebugPlayer");
            richTextBox6.Text = "Player Score: " + Singleton.Instance.P1Score;
            richTextBox4.Text = "\n Lifes:" + Singleton.Instance.Player.Lifes + "\n Attack: " + Singleton.Instance.Player.Attack;
            richTextBox5.Text = "\n Attack: " + Singleton.Instance.CurrentNinja.Attack;
            richTextBox3.Text = "Round: " + Singleton.Instance.RoundNumber;

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
            if (i >= 5000)
            {
                System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();

                s.Stop();
            }
        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {
            richTextBox6.Text = "Player Score: " + Singleton.Instance.P1Score;
            if (Singleton.Instance.RoundNumber >= 1)
            {
                richTextBox6.Text = "Player Score: " + Singleton.Instance.P1Score;
                Update();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(Singleton.Instance.RoundNumber >= 5)
            {
                Form2 form2 = new Form2();
                this.Hide();                
                form2.Show();                
            }            
        }     
    }
}