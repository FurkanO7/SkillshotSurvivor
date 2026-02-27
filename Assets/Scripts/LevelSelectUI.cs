using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectUI : MonoBehaviour
{
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;

    [SerializeField] private TextMeshProUGUI level1Text;
    [SerializeField] private TextMeshProUGUI level2Text;
    [SerializeField] private TextMeshProUGUI level3Text;

    private void Awake()
    {
        UpdateLevelStates();
    }

    private void UpdateLevelStates()
    {
        SetLevelAvailable(level1Button, level1Text, true, "Level 1");

        int level1Score = HighscoreManager.GetHighscore(1);
        bool level2Unlocked = level1Score >= 800;
        SetLevelAvailable(level2Button, level2Text, level2Unlocked,
            level2Unlocked ? "Level 2" : "Locked");

        int level2Score = HighscoreManager.GetHighscore(2);
        bool level3Unlocked = level2Score >= 500;
        SetLevelAvailable(level3Button, level3Text, level3Unlocked,
            level3Unlocked ? "Level 3" : "Locked");
    }

    private void SetLevelAvailable(Button button, TextMeshProUGUI text, bool isAvailable, string buttonText)
    {
        if (button != null)
        {
            button.interactable = isAvailable;

            var colors = button.colors;
            if (!isAvailable)
            {
                colors.normalColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            }
            else
            {
                colors.normalColor = Color.white;
            }
            button.colors = colors;
        }

        if (text != null)
        {
            text.text = buttonText;
        }
    }
}
