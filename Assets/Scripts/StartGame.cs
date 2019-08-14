using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
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
}
