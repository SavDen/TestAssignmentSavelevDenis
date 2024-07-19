using UnityEngine;

public class WinAndLoseGame : MonoBehaviour
{
    [SerializeField] private GameObject winPanel, losePanel;
    private void OnEnable()
    {
        EventSystem.DeadPlayer += Lose;
        EventSystem.WinPlayer += Win;
    }

    private void OnDisable()
    {
        EventSystem.DeadPlayer -= Lose;
        EventSystem.WinPlayer -= Win;
    }

    private void Win()
    {
        winPanel.SetActive(true);
    }

    private void Lose()
    {
        losePanel.SetActive(true);
    }
}
