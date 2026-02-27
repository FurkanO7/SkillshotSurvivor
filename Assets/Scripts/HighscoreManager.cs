using UnityEngine;
public class HighscoreManager : MonoBehaviour
{
    private const string HIGHSCORE_KEY_PREFIX = "Highscore_Level_";
    public static int GetHighscore(int level)
    {
        return PlayerPrefs.GetInt(HIGHSCORE_KEY_PREFIX + level, 0);
    }

    public static bool SetHighscore(int level, int newScore)
    {
        int currentHighscore = GetHighscore(level);
        if (newScore > currentHighscore)
        {
            PlayerPrefs.SetInt(HIGHSCORE_KEY_PREFIX + level, newScore);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }


    public static void ResetAllHighscores()
    {
        for (int i = 1; i <= 10; i++)
        {
            PlayerPrefs.DeleteKey(HIGHSCORE_KEY_PREFIX + i);
        }
        PlayerPrefs.Save();
    }
}
