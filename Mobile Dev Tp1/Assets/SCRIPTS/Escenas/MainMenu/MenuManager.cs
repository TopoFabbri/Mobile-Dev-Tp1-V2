using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Escenas.MainMenu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> menus = new();
        [SerializeField] private Image multiplayerImage;
        [SerializeField] private Image difficultyImage;
        [SerializeField] private TextMeshProUGUI multiplayerText;
        [SerializeField] private TextMeshProUGUI difficultyText;

        private void Awake()
        {
            menus[0].SetActive(true);

            for (var i = 1; i < menus.Count; i++)
            {
                menus[i].SetActive(false);
            }
        }

        public void Play()
        {
            SceneManager.LoadScene("conduccion9");
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void ChangeText(TextMeshProUGUI text, string newText)
        {
            text.text = newText;
        }

        private void ChangeColor(Image image, Color color)
        {
            image.color = color;
        }

        public void ChangeMultiplayer()
        {
            GameSettings.MultiPlayer = !GameSettings.MultiPlayer;
            
            ChangeColor(multiplayerImage, GameSettings.MultiPlayer ? Color.green : Color.red);
            ChangeText(multiplayerText, GameSettings.MultiPlayer ? "Multiplayer" : "Singleplayer");
        }

        public void ChangeDifficulty()
        {
            GameSettings.Difficulty++;
            
            if ((int)GameSettings.Difficulty > 2)
                GameSettings.Difficulty = 0;

            switch (GameSettings.Difficulty)
            {
                case GameSettings.Diff.Easy:
                    ChangeColor(difficultyImage, Color.green);
                    ChangeText(difficultyText, "Easy");
                    break;

                case GameSettings.Diff.Medium:
                    ChangeColor(difficultyImage, Color.yellow);
                    ChangeText(difficultyText, "Medium");
                    break;

                case GameSettings.Diff.Hard:
                    ChangeColor(difficultyImage, Color.red);
                    ChangeText(difficultyText, "Hard");
                    break;
            }
        }
    }
}