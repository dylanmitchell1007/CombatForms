using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;


namespace CombatForms
{
    class SaveLoad<T>
    {


        public static void Serialize(string fileName, T data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            string path = Environment.CurrentDirectory + "\\" + fileName + ".xml";
            TextWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, data);
            
            
            
            
            writer.Close();

        }
        public static T Deserialize(string fileName)
        {
            T data;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader reader = new StreamReader(Environment.CurrentDirectory  + "\\" + fileName + ".xml");
            data = (T)serializer.Deserialize(reader);
            reader.Close();
            return data;
        }
    }
    class GameSaves
    {
        private float lifes;
        private float attack;
        private float health;
        private float score;
        private float currentlevel;
       
        
        //private float save;
        //private float load;
        private void SaveData_Click(object sender, EventArgs e)
        {
            
            Player curPlayer = new Player(this.health, this.attack, this.lifes, "Player", this.score, this.currentlevel);
            SaveLoad<Player>.Serialize("Player", curPlayer);
            
            
         
        }
        private void LoadLast_Click(object sender, EventArgs e)
        {
            Player lastPlayer = SaveLoad<Player>.Deserialize("Player");
         
            this.attack = lastPlayer.Attack;
            this.health = lastPlayer.Health;
            this.lifes = lastPlayer.Lifes;
            this.score = lastPlayer.Score;
            this.currentlevel = lastPlayer.Currentlevel;
        }

     
        //List<GameSaves> Save1;
        //List<GameSaves> Load1;
        //public void Save(float a)
        //{
        //    Save1 = new List<GameSaves>();
            
        
        //}
        //public void Load(string b)
        //{
        //    Load1 = new List<GameSaves>();


        //}
    }
}
