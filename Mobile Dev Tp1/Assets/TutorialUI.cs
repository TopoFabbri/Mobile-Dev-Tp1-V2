using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private GameObject startText;
    [SerializeField] private Player player1;

    private void Update()
    {
        if (player1.FinTuto)
            startText.SetActive(true);
    }
}