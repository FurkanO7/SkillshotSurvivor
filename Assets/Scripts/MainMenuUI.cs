using UnityEngine;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_Text level1Text;
    [SerializeField] private TMP_Text level2Text;
    [SerializeField] private TMP_Text level3Text;

    // ...existing code...

    private void Awake()
    {
        DisplayHighscores();
        // ...existing code...
    }

    private void DisplayHighscores()
    {
        if (level1Text != null)
            level1Text.text = $"Highscore: {HighscoreManager.GetHighscore(1)}";

        if (level2Text != null)
            level2Text.text = $"Highscore: {HighscoreManager.GetHighscore(2)}";

        if (level3Text != null)
            level3Text.text = $"Highscore: {HighscoreManager.GetHighscore(3)}";
    }

    // ...existing code...
}
