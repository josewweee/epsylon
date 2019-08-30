using System.Collections.Generic;
using UnityEngine;

public class Tendero : MonoBehaviour
{
    private List<InventarioTienda> ItemCompra;
    public GameObject ContenedorItems;
    public GameObject Inventario;

public baseDatos baseDatos;
    void Start()
    {
        ItemCompra = new List<InventarioTienda>();
        for (int i = 0; i < ContenedorItems.transform.childCount; i++)
        {
            ItemCompra.Add(ContenedorItems.transform.GetChild(i).GetComponent<InventarioTienda>());
        }

    }

    public void comprar(int id){
        Inventario.GetComponent<Inventario>().agregarItem(id);
    }  
    void Update()
    {
        
    }
}
