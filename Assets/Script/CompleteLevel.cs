using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;

    public string menuSceneName = "mainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public void OnEnable()
    {
        if(levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
    }

    public void Next()
    {
        sceneFader.FadeTo(nextLevel);
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

}
