 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using System;
 
 public class InputText : MonoBehaviour
 {
 
     InputField input;
     InputField.SubmitEvent se;
     public Text output;
     public GameObject Malescrito;
 
 
     void Start()
     {
 
         input = gameObject.GetComponent<InputField>();
         se = new InputField.SubmitEvent();
         se.AddListener(SubmitInput);
         input.onEndEdit = se;
 
     }
 
     private void SubmitInput(string textoIngresado)
     { 

        if ( textoIngresado.ToUpper().Contains("BEANS") || textoIngresado.ToUpper().Contains("CARROT") || textoIngresado.ToUpper().Contains("PEAS") || textoIngresado.ToUpper().Contains("ONIONS") || textoIngresado.ToUpper().Contains("PORK") || textoIngresado.ToUpper().Contains("CHICKEN") || textoIngresado.ToUpper().Contains("RICE") || textoIngresado.ToUpper().Contains("SESAME OIL") || textoIngresado.ToUpper().Contains("SOY SAUCE") ) 
        {
            Puntaje.puntajeJugador += 5f;
            string currentText = output.text;
            string newText = currentText + "\n" + ">" + textoIngresado;
            output.text = newText;
            input.text = "";
            input.ActivateInputField();
        }
        else
        {
          Puntaje.puntajeJugador -= 2f;  
          Malescrito.SetActive(true);
        }

     }
 }
 