using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puntajeFormularios : MonoBehaviour
{
    //EL PUNTAJE VIENE DE LA CLASE 'Puntaje'
    public bool[] completed;
    

    //VARIABLES NIVEL HISTORIA
    public InputField inp1;
    public InputField inp2;
    public InputField inp3; 
    public InputField inp4;
    public InputField inp5;
    public InputField inp6;
    public InputField inp7;


    //VARIABLES NIVEL QUIZ
    public InputField quiz_inp1;
    public InputField quiz_inp2;
    public InputField quiz_inp3; 
    public InputField quiz_inp4;



    void Start()
    {
        completed = new bool [11];
        completed[0] = false;
        completed[1] = false;
        completed[2] = false;
        completed[3] = false;
        completed[4] = false;
        completed[5] = false;
        completed[6] = false;
        completed[7] = false;
        completed[8] = false;
        completed[9] = false;
        completed[10] = false;
    }


    void Update()
    {
        Scene escenaActual = SceneManager.GetActiveScene();
        string nombreEscena = escenaActual.name;
        if ( nombreEscena.ToUpper() == "Quiz".ToUpper() ) {
            QuizQuestions();
        } else if ( nombreEscena.ToUpper() == "story_time".ToUpper() ) {
            StoryQuestions();
        }
    }

    void StoryQuestions() {
        if( completed[4] == false && inp1.text.ToUpper() == "His name is Dubois".ToUpper()) 
        {
            Puntaje.puntajeJugador += 5f;
            completed[4] = true;
        } else if ( completed[4] == false && inp1.text.ToUpper().Contains("Dubois".ToUpper()) )
        {
            Puntaje.puntajeJugador += 2.5f;
            completed[4] = true;
        }

        if( completed[5] == false && inp2.text.ToUpper() == "His last name Carpentier".ToUpper()) 
        {
            Puntaje.puntajeJugador += 5f;
            completed[5] = true;
        } else if ( completed[5] == false && inp2.text.ToUpper().Contains("Carpentier".ToUpper()) )
        {
            Puntaje.puntajeJugador += 2.5f;
            completed[5] = true;
        }

        if( completed[6] == false && inp3.text.ToUpper() == "He was born in Bordeaux".ToUpper()) 
        {
            Puntaje.puntajeJugador += 5f;
            completed[6] = true;
        } else if ( completed[6] == false && inp3.text.ToUpper().Contains("Bordeaux".ToUpper()) )
        {
            Puntaje.puntajeJugador += 2.5f;
            completed[6] = true;
        }

        if( completed[7] == false && inp4.text.ToUpper() == "For 3 years".ToUpper()) 
        {
            Puntaje.puntajeJugador += 5f;
            completed[7] = true;
        } else if ( completed[7] == false && inp4.text.ToUpper().Contains("3".ToUpper()) )
        {
            Puntaje.puntajeJugador += 2.5f;
            completed[7] = true;
        }

       if ( completed[8] == false && inp5.text.ToUpper().Contains("no".ToUpper()) )
        {
            Puntaje.puntajeJugador += 5f;
            completed[8] = true;
        }

        if( completed[9] == false && inp6.text.ToUpper() == "They are green".ToUpper()) 
        {
            Puntaje.puntajeJugador += 5f;
            completed[9] = true;
        } else if ( completed[9] == false && inp6.text.ToUpper().Contains("green".ToUpper()) )
        {
            Puntaje.puntajeJugador += 2.5f;
            completed[9] = true;
        }

        if ( completed[10] == false && inp7.text.ToUpper().Contains("playful".ToUpper()) && inp1.text.ToUpper().Contains("attentive".ToUpper()) )
        {
            Puntaje.puntajeJugador += 5f;
            completed[10] = true;
        } else if ( completed[0] == false && inp7.text.ToUpper().Contains("playful".ToUpper()) && inp1.text.ToUpper().Contains("attentive".ToUpper()) )
        {
            Puntaje.puntajeJugador += 2.5f;
            completed[10] = true;
        }
        // Debug.Log("H: " + Puntaje.puntajeJugador);
    }


    //CALIFICACION PREGUNTAS QUIZ
    void QuizQuestions() {

        if( completed[0] == false && quiz_inp1.text.ToUpper() == "CHINESE FRIED RICE".ToUpper()) 
        {
            Puntaje.puntajeJugador += 5f;
            completed[0] = true;
        } else if ( completed[0] == false && quiz_inp1.text.ToUpper().Contains("RICE".ToUpper()) )
        {
            Debug.Log( "complatdo = " +  completed[0]);
            Puntaje.puntajeJugador += 2.5f;
            completed[0] = true;
        }

        if( completed[1] == false && quiz_inp2.text.ToUpper() == "Dice them".ToUpper()) 
        {
            Puntaje.puntajeJugador += 5f;
            completed[1] = true;
        } else if ( completed[1] == false && quiz_inp2.text.ToUpper().Contains("Dice".ToUpper()) )
        {
            Puntaje.puntajeJugador += 2.5f;
            completed[1] = true;
        }

        if( completed[2] == false && quiz_inp3.text.ToUpper() == "8 kilos".ToUpper()) 
        {
            Puntaje.puntajeJugador += 5f;
            completed[2] = true;
        } else if ( completed[2] == false && quiz_inp3.text.ToUpper().Contains("8".ToUpper()) )
        {
            Puntaje.puntajeJugador += 2.5f;
            completed[2] = true;
        }

        if( completed[3] == false && quiz_inp4.text.ToUpper() == "the rice".ToUpper()) 
        {
            Puntaje.puntajeJugador += 5f;
            completed[3] = true;
        } else if ( completed[3] == false && quiz_inp4.text.ToUpper().Contains("rice".ToUpper()) )
        {
            Puntaje.puntajeJugador += 2.5f;
            completed[3] = true;
        }
        // Debug.Log("Q: " + Puntaje.puntajeJugador);
    }
    
}
