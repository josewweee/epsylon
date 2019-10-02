using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorBotones : MonoBehaviour
{
    public string accionBoton;
    private controladorPasosReceta controlador = new controladorPasosReceta();
    public Ingredientes ingredientes = new Ingredientes();

    public void Procesar() {
        int i = controladorPasosReceta.instruccionActual;
        string[] pasosReceta = controladorPasosReceta.instruccionesCorrectas;
        if ( pasosReceta[i]  == accionBoton ) {
            Puntaje.puntajeJugador+=5f;
            controladorPasosReceta.instruccionActual++;
            AumentarNivel();
            //ingredientes.CrearIngrediente("carne");
        }
    }

     public void AumentarNivel () {
        GameObject objeto;
        switch (controladorPasosReceta.instruccionActual)
        {
            
            case 0:
                break;
            case 1:
                objeto = GameObject.FindWithTag("cebolla");
                Destroy( objeto );
                ingredientes.CrearIngrediente("carne");
                break;
            case 2:
                objeto = GameObject.FindWithTag("carne");
                Destroy( objeto );
                ingredientes.CrearIngrediente("carneCortada");
                break;
            case 3:
                objeto = GameObject.FindWithTag("carneCortada");
                Destroy( objeto );
                ingredientes.CrearIngrediente("zanahoria");
                break;
            case 4:
                objeto = GameObject.FindWithTag("zanahoria");
                Destroy( objeto );
                ingredientes.CrearIngrediente("arroz");
                break;
            case 5:
                objeto = GameObject.FindWithTag("arroz");
                Destroy( objeto );
                ingredientes.CrearIngrediente("cebollaVerde");
                break;
            case 6: //
                StartGame manejadorEscenas = new StartGame();
                manejadorEscenas.GotoLevel_4();
                break;
            default:
                break;
        }
    }


}
