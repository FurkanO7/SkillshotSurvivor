using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject MenuButtons;
    [SerializeField] private GameObject Levelauswahl;

    [Header("Options Panel")]
    [SerializeField] private GameObject optionsPanel;

    public void Play()
    {
        if (MenuButtons != null)
        {
            MenuButtons.SetActive(false);
        }
        if (Levelauswahl != null)
        {
            Levelauswahl.SetActive(true);
        }
    }

    public void OpenOptionsPanel()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(true);
    }

    public void CloseOptionsPanel()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(false);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadSceneByName(string sceneName)
    {
        if (!string.IsNullOrWhiteSpace(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
