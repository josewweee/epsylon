using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class tiempoRecorrido : MonoBehaviour
{
    private float tiempoFinal = ((float)System.DateTime.Now.Minute + ((float)System.DateTime.Now.Second * 0.01f));
    public float tiempoTotal;

    //UI DEL TIEMPO
    public Text textoValorTiempo;


    void Start()
    {
        tiempoTotal = tiempoFinal - Puntaje.tiempoComienzo;
        textoValorTiempo.text = tiempoTotal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
