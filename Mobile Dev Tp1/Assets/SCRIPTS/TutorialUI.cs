using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private Text startText;
    [SerializeField] private Player player1;

    private void Awake()
    {
        if (Application.isMobilePlatform)
            startText.text = "Presionar aca para empezar";
    }

    private void Update()
    {
        if (player1.FinTuto)
            startText.gameObject.SetActive(true);
    }

    public void StartPressed()
    {
        InputManager.Instance.SetAxis("Start", 1);
    }
}