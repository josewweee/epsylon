using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredientes : MonoBehaviour
{
    //LISTA CON TODOS LOS INGREDIENTES Y SUS CARACTERISTICAS
   /*  public Hashtable listaIngredientes = new Hashtable() {
        {"nombre", "carrot"}
    }; */

    //LISTA DE PREFAB DE INGREDIENTES
    public GameObject cebolla;
    public GameObject carne;
    public GameObject cebollaVerde;
    public GameObject arroz;
    public GameObject zanahoria;

    void Start()
    {
        //CrearIngrediente("cebolla");
    }

    
    void Update()
    {
       
    }

    public void CrearIngrediente ( string ingrediente ) {
        Debug.Log(ingrediente);
        switch (ingrediente)
        {
            case "cebolla":
            Instantiate(cebolla, new Vector3(-0.054f, 0f, -7.579053f), Quaternion.identity);
                break;
            case "carne":
            Instantiate(carne, new Vector3(-0.054f, 0f, -7.579053f), Quaternion.identity);
            Debug.Log("completado parte 2");
                break;
            case "cebollaVerde":
            Instantiate(cebollaVerde, new Vector3(-0.054f, 0f, -7.579053f), Quaternion.identity);
                break;
            case "arroz":
            Instantiate(arroz, new Vector3(-0.054f, 0f, -7.579053f), Quaternion.identity);
                break;
            case "zanahoria":
            Instantiate(zanahoria, new Vector3(-0.054f, 0f, -7.579053f), Quaternion.identity);
                break;
            default:
                break;
        }
    }

    public void BorrarIngrediente ( GameObject prefab) {
        Destroy(prefab);
    }
}
