using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    //VARIABLES PARA MANEJAR EL PUNTAJE
    public static float puntajeJugador = 0;
    private static float maximoPuntaje = puntajeJugador;

    //VARIABLES PARA MANEJAR EL TIEMPO
    public static float tiempoComienzo = ((float)System.DateTime.Now.Minute + ((float)System.DateTime.Now.Second * 0.01f));

    //UI DEL PUNTAJE
    public Text puntaje_UI;


    //ESTE OBJETO NO SE DESTRUIRA EN LAS NUEVAS ESCENAS
    void Start()
    {
        Debug.Log(GeneroPersonaje.genero);
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        puntaje_UI = GameObject.FindWithTag("Slot").GetComponent<Text>();
        puntaje_UI.text = puntajeJugador.ToString();
       /*  if ( puntajeJugador > maximoPuntaje ) {
            puntaje_UI = GameObject.FindWithTag("Slot").GetComponent<Text>();
            puntaje_UI.text = puntajeJugador.ToString();
        } */
    }
}
