using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject MenuButtons;
    [SerializeField] private GameObject Levelauswahl;

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

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Diese Methode kann im Button-OnClick verwendet werden und nimmt den Szenennamen als Parameter
    public void LoadSceneByName(string sceneName)
    {
        if (!string.IsNullOrWhiteSpace(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
