﻿using System.Collections;
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

   
    public static void GotoStoryScene()
    {
        SceneManager.LoadScene("story_time");
    }

    public void GotoLevel_1()
    {
        SceneManager.LoadScene("level1");
    }

    public void GotoLevel_2()
    {
        int respuestas = InputText.respuestas;
        if ( respuestas != 8 ) {
            Puntaje.puntajeJugador -= 40f;
        }
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

    public void GotoQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void GotoHighScore()
    {
        SceneManager.LoadScene("high_score");
    }

    public void GotoScore()
    {
        SceneManager.LoadScene("score");
    }
    public void GototeachScore()
    {
        SceneManager.LoadScene("teacher_find");
    }
    public void checkuser()
    {
        if (log_in.is_teacherr==true)
        {
            GototeachScore();
        }
    }

    public void GotoLogin()
    {
        SceneManager.LoadScene("Login");
    }
    public void GotoQuestmanager()
    {
        SceneManager.LoadScene("Quest_manager");
    }
    public void Gotolistquest()
    {
        SceneManager.LoadScene("showquest");
    }



}
