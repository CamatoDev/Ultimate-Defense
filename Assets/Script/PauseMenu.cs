using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    public SceneFader sceneFader;

    public string menuSceneName = "mainMenu";

        /*activation et desactivation de menu de pause*/

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }
    

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
