using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmarCompra : MonoBehaviour
{
    [SerializeField]
    BaseDatos baseDatos;
    [SerializeField]
    Tendero tendero;
    public int ID;
    public int cantidad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aceptar()
    {
        tendero.Comprar(ID,cantidad);
        this.gameObject.SetActive(false);
    }

    public void cancelar()
    {
        this.gameObject.SetActive(false);
        print ("Compra cancelada");
    }
}
