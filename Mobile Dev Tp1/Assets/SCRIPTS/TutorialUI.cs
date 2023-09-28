using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private GameObject startText;
    [SerializeField] private Player player1;

    private void Awake()
    {
        if (Application.isMobilePlatform)
            startText.GetComponent<Text>().text = "Presionar en la pantalla para comenzar";
    }

    private void Update()
    {
        
        if (player1.FinTuto)
            startText.SetActive(true);
    }
}