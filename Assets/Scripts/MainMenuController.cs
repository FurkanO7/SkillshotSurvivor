using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string mainGameSceneName = "MainGame";

    public void Play()
    {
        if (!string.IsNullOrWhiteSpace(mainGameSceneName))
        {
            SceneManager.LoadScene(mainGameSceneName);
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
