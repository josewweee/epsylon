using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void GotoCharacterSelection()
    {
        SceneManager.LoadScene("character_selection");
    }

   
    public void GotoStoryScene()
    {
        SceneManager.LoadScene("story_time");
    }

    public void GotoLevel_1()
    {
        SceneManager.LoadScene("level1");
    }

    public void GotoLevel_2()
    {
        SceneManager.LoadScene("level2");
    }

    public void GotoLevel_3()
    {
        SceneManager.LoadScene("level3");
    }

    public void GotoLevel_4()
    {
        SceneManager.LoadScene("level4");
    }
}
