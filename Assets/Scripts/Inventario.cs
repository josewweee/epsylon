using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventario : MonoBehaviour
{
    
    public struct itemID {
        public int id;

        public itemID(int id)
        {
            this.id = id;
        }
    }

    [SerializeField]
    baseDatos datos;
    public GraphicRaycaster rayo;
    private PointerEventData data;
    private List<RaycastResult> resultadoRayo;
    public static Transform canvas;
    public GameObject itemSeleccionado;
    public Item item;
    public List<itemID> inventario = new List<itemID>();
    public Transform contenido;
    void Start()
    {
      data = new PointerEventData(null);
      resultadoRayo = new List<RaycastResult>();

    }

       void Update()
    {
        
    }
    

    List<Item> pool = new List<Item>();

    public void agregarItem(int id){
        for (int i = 0 ;i<inventario.Count;i++){
            if (inventario[id].id == id){
                inventario[id] = new itemID(inventario[i].id);
                actualizarInventario();
                return;
            }
        }
        
        inventario.Add(new itemID(id));
        actualizarInventario();
    }



    public void actualizarInventario(){
        for (int i = 0; i < pool.Count;i++){
            if (i< inventario.Count){
                itemID id = inventario[i];
                pool[i].ID = id.id;
                pool[i].GetComponent<Image>().sprite = datos.dataBase[id.id].icono;
                pool[i].gameObject.SetActive(true);
            }else{
                pool[i].gameObject.SetActive(false);
            }
        }
            
            
        if (inventario.Count > pool.Count){
            for (int i = pool.Count; i < inventario.Count;i++){
            }
        }          
    }
}



