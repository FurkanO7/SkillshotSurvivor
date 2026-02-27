using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreTimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private float pointsPerSecond = 50f;

    private float score;

    private void Awake()
    {
        score = 0f;
        UpdateUI();
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        score += pointsPerSecond * dt;

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void Reset()
    {
        score = 0f;
        UpdateUI();
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }
}
