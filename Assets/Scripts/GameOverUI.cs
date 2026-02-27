using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text headerText;
    [SerializeField] private int levelNumber = 1; 

    private void Awake()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    public void Show(int finalScore)
    {
        if (headerText != null)
            headerText.text = "You died";

        bool isNewRecord = HighscoreManager.SetHighscore(levelNumber, finalScore);

        string scoreMessage = "Your Score: " + finalScore.ToString();
        if (isNewRecord)
        {
            scoreMessage += "\n NEW RECORD! ";
        }

        if (scoreText != null)
            scoreText.text = scoreMessage;
        if (panel != null)
            panel.SetActive(true);
    }

    public void Hide()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenue");
    }
}
