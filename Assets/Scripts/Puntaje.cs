using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public static float puntajeJugador = 0;
    private static float maximoPuntaje = puntajeJugador;
    public Text puntaje_UI;


    void Start()
    {
        
        Debug.Log(puntajeJugador);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if ( puntajeJugador > maximoPuntaje ) {
            puntaje_UI = GameObject.FindWithTag("Slot").GetComponent<Text>();
            puntaje_UI.text = puntajeJugador.ToString();
        }
    }
}
