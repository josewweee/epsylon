using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tendero : MonoBehaviour
{
    public int dinero;
    public GameObject inventario;
    public List<ItemTienda> itemCompra;
    public List<ItemTienda> itemDesactivar = new List<ItemTienda>();
    public List<ItemTienda> itemActivar = new List<ItemTienda>();
    [SerializeField]
    private BaseDatos baseDatos;
    public Text Dinero;    
    public GameObject ContenedorItems;
    public GameObject DineroInsuficiente;
    public GameObject Confirmar;
    public GameObject CartelCantidad;


    // Start is called before the first frame update
    void Start()
    {
        itemCompra = new List<ItemTienda>();
        for(int i = 0; i < ContenedorItems.transform.childCount;i++)
        {
            itemCompra.Add(ContenedorItems.transform.GetChild(i).GetComponent<ItemTienda>());
        }
        Confirmar.SetActive(false);
        CartelCantidad.SetActive(false);
        DineroInsuficiente.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Dinero.text = "Money: " + dinero.ToString();
    }

    public void Comprar(int id, int cantidad)
    {
        if(dinero >= itemCompra[id].precio*cantidad)
        {
            itemCompra[id].cantidad -= cantidad;
            dinero -= itemCompra[id].precio*cantidad;
            cantidad -=itemCompra[id].cantidad;
            inventario.GetComponent<Inventario>().Agregar(id,cantidad);
        }
        else
        {
            DineroInsuficiente.SetActive(true);
        }
    }

    public void esconderItem(int caso)
    {
        for(int i = 0; i<itemCompra.Count;i++)
        {
            if (caso == 0)
            {
                itemActivar.Clear();
                itemActivar = itemCompra.FindAll(x => x.ID !=5);
                foreach(ItemTienda itemA in itemActivar)
                {
                    itemA.gameObject.SetActive(true);
                }
                return;
            }
        desactivarItem(caso);
        activarItem(caso);
        }
        
    }

    void activarItem(int caso)
    {
        itemActivar.Clear();
        itemActivar = itemCompra.FindAll(x => x.ID == caso);
            foreach(ItemTienda itemA in itemActivar)
            {
                itemA.gameObject.SetActive(true);
            }
    }

    void desactivarItem(int caso)
    {
        itemDesactivar.Clear();
        itemDesactivar = itemCompra.FindAll(x => x.ID != caso);
        foreach(ItemTienda item in itemDesactivar)
            {
                if(item.gameObject.activeInHierarchy)
                item.gameObject.SetActive(false);
            }
    }

}


