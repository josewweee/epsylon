using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ItemTienda : MonoBehaviour , IPointerClickHandler
{

    public BaseDatos DB;
    public Tendero tendero;
    public int tipo;
    public int ID;
    public int precio;
    public int cantidad;
    public Image icono;
    public Text precioText;
    public Text cantidadText;
    GameObject confirmacion;
    GameObject Cartelcantidad;

    // Start is called before the first frame update
    void Start()
    {
        switch(DB.baseDatos[ID].tipo){
            case BaseDatos.Tipo.Fruta:
                tipo = 1;
                break;
            case BaseDatos.Tipo.Verdura:
                tipo = 2;
                break;
            case BaseDatos.Tipo.Condimento:
                tipo = 3;
                break;
            case BaseDatos.Tipo.Liquido:
                tipo = 4;
                break;
            default:
                tipo = 0;
                break;
        }

        confirmacion = tendero.Confirmar;
        Cartelcantidad = tendero.CartelCantidad;
        precio = DB.baseDatos[ID].precio;
        icono = GetComponent<Image>();
        icono.sprite = DB.baseDatos[ID].icono;
        precioText.text = precio.ToString();
        cantidadText.text = cantidad.ToString();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (cantidad <= 1)
        {
            confirmacion.SetActive(true);
            confirmacion.GetComponent<ConfirmarCompra>().ID = ID;
            confirmacion.GetComponent<ConfirmarCompra>().cantidad = cantidad;
        }
        else
        {
            Cartelcantidad.SetActive(true);
            Cartelcantidad.GetComponent<CantidadCompra>().id = ID;
            Cartelcantidad.GetComponent<CantidadCompra>().slider.maxValue = cantidad;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
