using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace GameSaver
{
    static class SaveManager
    {
        public static int GlobalScore { get; private set; }
        
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
    }
}
