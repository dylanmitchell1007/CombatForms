using System;
using System.Text;
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
            TextWriter writer = new StreamWriter("C: \\Users\\dylan.mitchell\\Documents\\Visual Studio 2015\\Projects\\CombatForms\\CombatForms\\SaveGames\\" + fileName);
            serializer.Serialize(writer, data);




            writer.Close();

        }
        public static T Deserialize(string fileName)
        {
            T data;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader reader = new StreamReader("C: \\Users\\dylan.mitchell\\Documents\\Visual Studio 2015\\Projects\\CombatForms\\CombatForms\\SaveGames\\" + fileName);
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
            SaveLoad<Player>.Serialize("Player", Singleton.Instance.Player);

        }
        private void LoadLast_Click(object sender, EventArgs e)
        {
            Player lastPlayer = SaveLoad<Player>.Deserialize("Player");
            Singleton.Instance.Player = lastPlayer;
            Singleton.Instance.GSM.Start(Singleton.Instance.Player.Currentlevel);
            Singleton.Instance.UpdateHud();
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
