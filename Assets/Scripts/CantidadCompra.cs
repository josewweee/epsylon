using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CantidadCompra : MonoBehaviour
{
    [SerializeField]
    Tendero tienda;
    public Slider slider;
    public Text CantidadCompraText;
    public int id;
    GameObject cartelConfirmar;
    

    // Start is called before the first frame update
    void Start()
    {
        cartelConfirmar = tienda.Confirmar;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeInHierarchy)
        {
            CantidadCompraText.text = slider.value.ToString();
        }
    }

    public void aceptar()
    {
        cartelConfirmar.SetActive(true);
        cartelConfirmar.GetComponent<ConfirmarCompra>().ID = id;
        cartelConfirmar.GetComponent<ConfirmarCompra>().cantidad = Mathf.RoundToInt(slider.value);
        slider.value = 1;
        this.gameObject.SetActive(false);
    }

    public void cancelar()
    {
        slider.value = 1;
        this.gameObject.SetActive(false);
    }
}
