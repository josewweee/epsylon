using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    //PUNTAJE
    public static float puntajeJugador = 100;


    //EL OBJETO NO SE DESTRUYE TRAS CAMBIAR ESCENAS
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
