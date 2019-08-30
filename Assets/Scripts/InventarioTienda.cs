using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventarioTienda : MonoBehaviour, IPointerClickHandler 
{

    public baseDatos baseDatos;
    public Tendero tr;
    public int ID;
    private Image icono;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        tr.comprar(ID);
    }

    void Start()
    {
        icono = GetComponent<Image>();
        icono.sprite = baseDatos.dataBase[ID].icono;
        
    }

    void Update()
    {
        
    }

    public void actualizar(){
        icono.GetComponent<Image>();
        icono.sprite = baseDatos.dataBase[ID].icono;
    }
  

}
