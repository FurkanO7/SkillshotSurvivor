using UnityEngine;

public class HighscoreResetter : MonoBehaviour
{
    public void ResetScores()
    {
        HighscoreManager.ResetAllHighscores();
    }
}