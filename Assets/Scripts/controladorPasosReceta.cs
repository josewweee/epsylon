using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorPasosReceta : MonoBehaviour
{
    //VARIABLE GLOBAL PARA LA INSTRUCCION DE LA RECETA EN QUE ESTAMOS
    public static int instruccionActual = 0;
    public Ingredientes ingredientes = new Ingredientes();
    public static string[] instruccionesCorrectas = new string[] {"dice", "chop", "cook", "cut", "cook", "chop"};

    void Start () {
        ingredientes.CrearIngrediente("cebolla");
    }

}
