using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        UpdateButton();
    }

    public void ChangeDifficulty()
    {
        GameSettings.Difficulty++;

        if ((int)GameSettings.Difficulty > 2)
            GameSettings.Difficulty = 0;
        
        UpdateButton();
    }

    private void UpdateButton()
    {
        switch (GameSettings.Difficulty)
        {
            case GameSettings.Diff.Easy:
                image.color = Color.green;
                text.text = "Easy";
                break;
            
            case GameSettings.Diff.Medium:
                image.color = Color.yellow;
                text.text = "Medium";
                break;
            
            case GameSettings.Diff.Hard:
                image.color = Color.red;
                text.text = "Hard";
                break;
        }
    }
}