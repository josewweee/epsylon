using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionIngredientes : MonoBehaviour
{
    //LISTA CON TODOS LOS INGREDIENTES Y SUS CARACTERISTICAS
   /*  public Hashtable listaIngredientes = new Hashtable() {
        {"nombre", "carrot"}
    }; */
    public Ingredientes test = new Ingredientes();
    void Start()
    {
        //SiguienteIngrediente();
    }

    public void SiguienteIngrediente () {
        test.CrearIngrediente("carne");
        Debug.Log("entrada parte 1");
    }
    void Update()
    {
       /*  Debug.Log((string)listaIngredientes["accion"]); */
    }
}
