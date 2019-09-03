using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public int cantidad = 1;
    public Text texCantidad;
    public int ID;
    BaseDatos baseDatos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.GetComponent<Image>() != null)
        {
            transform.parent.GetComponent<Image>().fillCenter = true;
        }
            
    }
}
