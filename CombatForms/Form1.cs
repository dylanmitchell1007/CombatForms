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


        FSM GameFsm;
        public Form1()
        {

            InitializeComponent();
            Singleton.Instance.Player = new Player(100, 10, 5, "P1", 0, 1);
            Singleton.Instance.Gameform = this;
            Singleton.Instance.NinjaList = new List<Ninja>();
            Singleton.Instance.NinjaIndex = 0;
            Singleton.Instance.UpdateHud += UpdateHud;
            //Singleton.Instance.CurrentNinja = Singleton.Instance.NinjaList[Singleton.Instance.NinjaIndex];

            GameFsm = new FSM(50);

            for (int a = 1; a <= 100; a++)
            {
                Singleton.Instance.NinjaList.Add(new Ninja(100, 5 + Singleton.Instance.RoundNumber, "Ninja " + a));
            }
            Singleton.Instance.CurrentNinja = Singleton.Instance.NinjaList[Singleton.Instance.NinjaIndex];
            for (int i = 1; i <= 25; i++)
            {

                GameFsm.AddTransition(i, i + 1);
                GameFsm.addOnEnter(i, (Handler)(delegate { Debug.WriteLine("entered round" + i.ToString()); }));
                GameFsm.addOnExit(i, (Handler)(delegate { Debug.WriteLine("exited round" + i.ToString()); }));

            }


            GameFsm.Start(1);
            InitHud();
            RoundLevel();

            UpdateHud();



        }
        void InitHud()
        {
            richTextBox4.Text = "\n Lifes:" + Singleton.Instance.Player.NumLives + "\n Attack: " + Singleton.Instance.Player.Attack;
            richTextBox5.Text = "\n Attack: ";


            Update();

            this.button7.Enabled = false;
            //store button.
            this.button10.Enabled = false;
            this.button10.Visible = false;
            ActivityLabel.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Singleton.Instance.Player.GiveDamage(Singleton.Instance.CurrentNinja);
            Singleton.Instance.CurrentNinja.GiveDamage(Singleton.Instance.Player);
            RoundLevel();
            UpdateHud();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Singleton.Instance.CurrentNinja.GiveDamage(Singleton.Instance.Player);
            Singleton.Instance.Player.GiveDamage(Singleton.Instance.CurrentNinja);
            RoundLevel();
            UpdateHud();


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "Player";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        public void UpdateHud()
        {
            progressBar2.Value = (int)Singleton.Instance.Player.Health;
            if (Singleton.Instance.Player.Health > 100)
            {
                Singleton.Instance.Player.Health = 100;
            }
            progressBar1.Value = (int)Singleton.Instance.CurrentNinja.Health;
            richTextBox3.Text = GameFsm.GetCurrentState().name;

            richTextBox6.Text = "Player Score: " + Singleton.Instance.P1Score;
            //5, 12, 17, 25
            richTextBox4.Text = "\n Lifes:" + Singleton.Instance.Player.NumLives + "\n Attack: " + Singleton.Instance.Player.Attack;
            richTextBox5.Text = "\n Attack: " + Singleton.Instance.CurrentNinja.Attack;
        }
        public void RoundLevel()
        {
            if (Singleton.Instance.Player.NumLives == 0)
            {
                Application.Exit();
            }
            if (Singleton.Instance.Player.Health > 100)
            {
                Singleton.Instance.Player.Health = 100;
            }
            //currentlevel = (GameNumber)GameFsm.GetCurrentState().Id;
            if (Singleton.Instance.RoundNumber >= 5)
            {
                ActivityLabel.Visible = true;
                ActivityLabel.Text = "Unlocked Store!!";
                this.button10.Enabled = true;
                this.button10.Visible = true;
            }
            if (Singleton.Instance.RoundNumber >= 6)
            {
                ActivityLabel.Visible = false;
            }
            if (Singleton.Instance.RoundNumber >= 12)
            {
                ActivityLabel.Visible = true;
                ActivityLabel.Text = "Unlocked Knife!!";
                this.button10.Enabled = true;
                this.button10.Visible = true;

                button7.Enabled = true;
                button7.Text = "Knife (" + Singleton.Instance.Player.Knifedurability + "%)";

            }
            if (Singleton.Instance.RoundNumber >= 13)
            {
                ActivityLabel.Visible = false;
            }
            if (Singleton.Instance.RoundNumber >= 17)
            {
                this.button10.Enabled = true;
                this.button10.Visible = true;
                button9.Enabled = true;

                Update();
                Singleton.Instance.Player.BuffAttack(Singleton.Instance.CurrentNinja);
                button8.Visible = true;
                button8.Enabled = true;
                button8.Text = "Health" + "(%)";
                HealthPackLabel.Text = "Used HealthPack";
                Update();

                Update();
                button9.Enabled = true;
                button9.Text = "Attack Boost: (" + Singleton.Instance.CurrentNinja.Attack + "%)";
                button7.Enabled = true;
                button7.Text = "Knife (" + Singleton.Instance.Player.Knifedurability + "%)";

            }

            if (Singleton.Instance.CurrentNinja.Health < 0)
            {
                Singleton.Instance.RoundNumber++;
                Singleton.Instance.NinjaIndex++;
                Singleton.Instance.Player.NumLives++;
                GameFsm.ChangeState(Singleton.Instance.RoundNumber);
                Singleton.Instance.P1Score += 100;
                Singleton.Instance.CurrentNinja.Health = 100;
                UpdateHud();
                RoundLevel();
            }


        }


        private void button5_Click(object sender, EventArgs e)
        {
            Player p = Singleton.Instance.Player;
            SaveLoad<Player>.Serialize("Player", Singleton.Instance.Player);

            //SaveLoad<GameNumber>.Serialize("Player lvl", currentlevel);
            //SaveLoad<int>.Serialize("Player Score", Singleton.Instance.P1Score);

        }
        private void button6_Click(object sender, EventArgs e)
        {


            Singleton.Instance.Player = SaveLoad<Player>.Deserialize("Player");
            Singleton.Instance.P1Score = SaveLoad<int>.Deserialize("Player Score");
            richTextBox6.Text = "Player Score: " + Singleton.Instance.P1Score;
            richTextBox4.Text = "\n Lifes:" + Singleton.Instance.Player.NumLives + "\n Attack: " + Singleton.Instance.Player.Attack;
            richTextBox5.Text = "\n Attack: " + Singleton.Instance.CurrentNinja.Attack;

            Update();
        }
        private void button7_Click(object sender, EventArgs e)
        {

            if (Singleton.Instance.Player.Knifedurability <= 0)
            {
                button7.Enabled = false;
                Singleton.Instance.Player.GiveDamage(Singleton.Instance.CurrentNinja);
            }
            else
                Singleton.Instance.Player.Knife(Singleton.Instance.CurrentNinja);
            Singleton.Instance.Player.GiveDamage(Singleton.Instance.CurrentNinja);
            button7.Text = "Knife (" + Singleton.Instance.Player.Knifedurability + "%)";

            if (Singleton.Instance.CurrentNinja.Health < 0)
            {
                RoundLevel();
            }
            UpdateHud();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (Singleton.Instance.RoundNumber > 17)
            {

                button8.Visible = true;
                button8.Enabled = true;
                button8.Text = "Health" + "(%)";
                HealthPackLabel.Text = "Used HealthPack";
                Update();


                Update();
                //Singleton.Instance.Player.


            }
            //p1.HealthPack(p1);
            Singleton.Instance.Player.Health = 100;
            ////p1.Health++;       
            if (Singleton.Instance.Player.HealthPackdurability <= 0)
            {
                button8.Enabled = false;
                button8.Text = "0";
            }
        }
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
                Singleton.Instance.Player.BuffAttack(Singleton.Instance.CurrentNinja);

                button9.Enabled = true;
                button9.Text = "Attack Boost: (" + Singleton.Instance.CurrentNinja.Attack + "%)";
            }
            Update();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            // save 

            if (Singleton.Instance.RoundNumber > 5)
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
                Update();
            }
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
