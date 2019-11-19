using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivel3 : MonoBehaviour
{
    
    
    public string accionBoton;
    public controladorPasosReceta controlador;
    private string[] instrucciones = controladorPasosReceta.instruccionesCorrectas;


    public void Procesar(){
        int i = controladorPasosReceta.instruccionActual;
        if(instrucciones[i] == accionBoton){
            Puntaje.puntajeJugador+=15f;
            controladorPasosReceta.instruccionActual++;
            i++;
            controlador.DetenerAudio();
            AumentarNivel(i);
        }else{
            Puntaje.puntajeJugador-=15f;
            Debug.Log("BOTON ERRONEO INTENTA DE NUEVO: " + accionBoton);
        }
    }

    public void AumentarNivel(int i) {
        controlador.CambiarAccionBotones();
        controlador.ReproducirAudio(i);
    }

    void Start()
    {
    
    }
}
