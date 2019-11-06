using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tendero : MonoBehaviour
{
    public Text output;

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
    public string[] ingredientes = {"ONIONS" , "CARROTS"};

    void Start()
    {
        itemCompra = new List<ItemTienda>();
        for (int i = 0; i < ContenedorItems.transform.childCount; i++)
        {
            itemCompra.Add(ContenedorItems.transform.GetChild(i).GetComponent<ItemTienda>());
        }
        Confirmar.SetActive(false);
        CartelCantidad.SetActive(false);
        DineroInsuficiente.SetActive(false);
        
       tachar();

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void Comprar(int id, int cantidad)
    {
        if (dinero >= itemCompra[id].precio * cantidad)
        {
            itemCompra[id].cantidad -= cantidad;
            dinero -= itemCompra[id].precio * cantidad;
            cantidad -= itemCompra[id].cantidad;
            inventario.GetComponent<Inventario>().Agregar(id, cantidad);
            if (id == 0 || id == 1 || id == 2 || id == 3 || id == 4 || id == 5)
            {
                Puntaje.puntajeJugador += 5f;
                ingredientes[0] = " ̶O̶N̶I̶O̶N̶S̶";
                tachar();
            }
            else
            {
                Puntaje.puntajeJugador -= 3f;
            }
        }
    }

    public void tachar()
    {
        output.text = "  ";

        for (int i = 0; i < ingredientes.Length; i++)
        {
            string currentText = output.text;
            string newText = currentText + "\n" + ">" + ingredientes[i];
            output.text = newText;
        }
    }
}
