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
       
        private int NinjaIndex;
        
        

        List<Ninja> NinjaList;

        Ninja currentNinja;

        

        public Form1()
        {
           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
         
            Singleton.Instance.Player = new Player(100,  10, 5, "P1");

            NinjaList = new List<Ninja>();

            for (int a = 1; a < 101; a++)
            {
                NinjaList.Add(new Ninja(100, 5 + Singleton.Instance.RoundNumber, "Ninja " + a));
            }

         
       
            NinjaIndex = 0;



            currentNinja = NinjaList[NinjaIndex];


            progressBar2.Value = (int)Singleton.Instance.Player.Health;
            progressBar1.Value = (int)currentNinja.Health;
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


            Singleton.Instance.Player.GiveDamage(currentNinja);
            Update();
            currentNinja.GiveDamage(Singleton.Instance.Player);
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentNinja.GiveDamage(Singleton.Instance.Player);
            Update();
            Singleton.Instance.Player.GiveDamage(currentNinja);
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
                label1.Enabled = false;
           
                HealthPackLabel.Text = "Your out of HealthPacks!!";
            }
            richTextBox4.Text = "\n Lifes:" + Singleton.Instance.Player.Lifes + "\n Attack: " + Singleton.Instance.Player.Attack; 
                        
            richTextBox5.Text = "\n Attack: " + currentNinja.Attack;

            if (Singleton.Instance.RoundNumber == 26)
            {
                button9.Enabled = false;
            }
                if (Singleton.Instance.RoundNumber == 25)
            {
                Singleton.Instance.Player.Knifedurability = 100;
                button9.Enabled = true;
                label3.Text = "<---USE THIS BOOST";
               
                button9.Text = "Attack Boost: (" + currentNinja.Attack + "%)";
                currentNinja.Attack = 23;
               
            }
            if (currentNinja.Health <= 0)
            {
                currentNinja.Health = 100;
                Singleton.Instance.RoundNumber++;
                Singleton.Instance.Player.Lifes++;
                NinjaIndex++;
                NinjaList[NinjaIndex].Attack += Singleton.Instance.RoundNumber;
                currentNinja = NinjaList[NinjaIndex];
            if (Singleton.Instance.RoundNumber >= 12)
                {
                   button7.Enabled = true;
                    button7.Text = "Knife (" + Singleton.Instance.Player.Knifedurability + "%)"; 
                }
            if (Singleton.Instance.RoundNumber >= 16)
                {
                    currentNinja.Attack = 15;
                    button8.Enabled = true;
                    button8.Text = "HealthPack("+ Singleton.Instance.Player.HealthPackdurability + "%)";

                }

                Update();
            }
            if(Singleton.Instance.RoundNumber == 18)
            {
                label3.Enabled = false;
                button9.Enabled = false;
                if (currentNinja.Health <= 0)
                {
                    Singleton.Instance.Player.Lifes = 5;
                }
                
            }
            if (Singleton.Instance.RoundNumber == 17)
            {
                label3.Text = "<---USE THIS BOOST";
               
            }
            
            if (Singleton.Instance.Player.HealthPackdurability <= 0)
            {
                button8.Enabled = false;
                
            }
     
            if(Singleton.Instance.Player.Lifes == 0)
            {
                Application.Restart();

            }

           if(Singleton.Instance.Player.Health >= 100)
            {

                Singleton.Instance.Player.Health = 100;
            }
       //if(currentNinja.Health <= 0)
       //     {
       //         progressBar1.Value = 100;
       //         currentNinja.Health = 100;
       //     }
            progressBar2.Value = (int)Singleton.Instance.Player.Health;
            progressBar1.Value = (int)currentNinja.Health;
            richTextBox3.Text = "Round: " + Singleton.Instance.RoundNumber;

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

            richTextBox4.Text = "\n Lifes:" + Singleton.Instance.Player.Lifes + "\n Attack: " + Singleton.Instance.Player.Attack;
            richTextBox5.Text = "\n Attack: " + currentNinja.Attack;
            richTextBox3.Text = "Round: " + Singleton.Instance.RoundNumber;

        }

        private void button7_Click(object sender, EventArgs e)
        {   
            if(Singleton.Instance.Player.Knifedurability <= 0)
            {
                button7.Enabled = false;
                
            } 
            else
                Singleton.Instance.Player.Knife(currentNinja);

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
               
                button9.Enabled = true;
                button9.Text = "Attack Boost: (" + currentNinja.Attack + "%)";

            }
            //p1.HealthPack(p1);
            progressBar2.Value = (int)Singleton.Instance.Player.Health;
            Update();
            ////p1.Health++;       
            if(Singleton.Instance.Player.HealthPackdurability <= 0)
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
                button9.Text = "Attack Boost: (" + currentNinja.Attack + "%)";
            }
                if (Singleton.Instance.RoundNumber == 17)
            {
                button9.Enabled = true;

                    
              
                Update();
                Singleton.Instance.Player.AttackBoost(currentNinja);
                

                button9.Enabled = true;
                button9.Text = "Attack Boost: (" + currentNinja.Attack + "%)";
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
    }
}
