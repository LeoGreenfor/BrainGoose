using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace GameSaver
{
    static class SaveManager
    {
        public static int GlobalScore { get; private set; }
        public static bool isHaveAccount = false;

        public static void LogIn()
        {
            if (isHaveAccount)
            {
                Debug.Log("you have acc!");
                LoadPlayerScore();
            }
            else
            {
                Debug.Log("you haven`t acc!");
                isHaveAccount = true;
                GlobalScore = 0;
            }
        }
        
        public static void AddScore(int score)
        {
            GlobalScore += score;
        }
        public static int GetScore()
        {
            return GlobalScore;
        }
        public static void CheckScore()
        {
            if (GlobalScore >= 4500)
            {
                SceneManager.LoadScene(5);
            }
        }

        public static void SaveData()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/playerData.info";

            FileStream fileStream = new FileStream(path, FileMode.Create);

            formatter.Serialize(fileStream, GlobalScore);
            fileStream.Close();
        }

        public static void LoadPlayerScore()
        {
            string path = Application.persistentDataPath + "/playerData.info";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.Open);

                int loadedScore = int.Parse((string)formatter.Deserialize(fileStream));
                fileStream.Close();

                GlobalScore = loadedScore;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                GlobalScore = 0;
            }
        }
    }
}
