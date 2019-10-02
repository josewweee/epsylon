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
        switch (controladorPasosReceta.instruccionActual)
        {
            case 0:
                break;
            case 1:
                Destroy( GameObject.Find("cebolla") );
                ingredientes.CrearIngrediente("carne");
                break;
            case 2:
                Destroy( GameObject.Find("carne(clone)") );
                ingredientes.CrearIngrediente("carneCortada");
                break;
            case 3:
                Destroy( GameObject.Find("carne(clone)") );
                ingredientes.CrearIngrediente("zanahoria");
                break;
            case 4:
                Destroy( GameObject.Find("zanahoria(clone)") );
                ingredientes.CrearIngrediente("arroz");
                break;
            case 5:
                Destroy( GameObject.Find("arroz(clone)") );
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
