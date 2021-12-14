using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class NextLevelNumber : MonoBehaviour
    {
        public Text Text;
        public Game Game;

        private void Start()
        {
            Text.text = (Game.LevelIndex + 2).ToString();
        }
    }
}