using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        UpdateButton();
    }

    public void ChangeMultiplayer()
    {
        GameSettings.MultiPlayer = !GameSettings.MultiPlayer;

        UpdateButton();
    }

    private void UpdateButton()
    {
        image.color = GameSettings.MultiPlayer ? Color.green : Color.red;
        text.text = GameSettings.MultiPlayer ? "Multiplayer" : "Singleplayer";
    }
}