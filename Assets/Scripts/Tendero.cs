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
    public string[] ingredientes2 = {"ONIONS" , "CARROTS" , "RICE" , "PEATS" ,"PORK","CHICKEN","GREEN ONION"
            ,"SESAME OIL","SOY SAUCE"};
    
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
            if (id == 0)
            {
                Puntaje.puntajeJugador += 5f;
                ingredientes2[0] = "̶O̶N̶I̶O̶N̶S̶";
                tachar();
            }
            else if (id == 1)
            {
                ingredientes2[1] = "̶C̶A̶R̶R̶O̶T̶S̶";
                Puntaje.puntajeJugador -= 3f;
                tachar();
            }
            else if (id == 2)
            {
                ingredientes2[2] = "̶R̶I̶C̶E̶";
                Puntaje.puntajeJugador -= 3f;
                tachar();
            }
            else if (id == 3)
            {
                ingredientes2[3] = "̶P̶O̶R̶K̶";
                Puntaje.puntajeJugador -= 3f;
                tachar();
            }
            else if (id == 4)
            {
                ingredientes2[4] = "̶C̶H̶I̶C̶K̶E̶N̶";
                Puntaje.puntajeJugador -= 3f;
                tachar();
            }
            else if (id == 5)
            {
                ingredientes2[5] = "̶B̶E̶A̶N̶S̶";
                Puntaje.puntajeJugador -= 3f;
                tachar();
            }
            else if (id == 6)
            {
                ingredientes2[6] = "̶G̶R̶E̶E̶N̶̶O̶N̶I̶O̶N̶";
                Puntaje.puntajeJugador -= 3f;
                tachar();
            }
            else if (id == 7)
            {
                ingredientes2[7] = "̶S̶E̶S̶A̶M̶E̶̶O̶I̶L̶";
                Puntaje.puntajeJugador -= 3f;
                tachar();
            }
            else if (id == 8)
            {
                ingredientes2[8] = "̶S̶O̶Y̶̶S̶A̶U̶C̶E̶";
                Puntaje.puntajeJugador -= 3f;
                tachar();
            }
        }
    }

    public void tachar()
    {
        output.text = "  ";

        for (int i = 0; i < ingredientes2.Length; i++)
        {
            string currentText = output.text;
            string newText = currentText + "\n" + ">" + ingredientes2[i];
            output.text = newText;
        }
    }
}
