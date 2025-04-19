using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public string menuSceneName = "mainMenu";

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

}
