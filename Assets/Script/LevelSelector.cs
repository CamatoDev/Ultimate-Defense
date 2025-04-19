using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;

    public SceneFader scenefader;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
            
        }
    }

    public void Select(string levelName)
    {
        scenefader.FadeTo(levelName);
    }
}
