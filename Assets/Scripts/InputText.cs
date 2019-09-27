 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using System;
 
 public class InputText : MonoBehaviour
 {
 
     InputField input;
     InputField.SubmitEvent se;
     public Text output;
 
 
     void Start()
     {
         input = gameObject.GetComponent<InputField>();
         se = new InputField.SubmitEvent();
         se.AddListener(SubmitInput);
         
         //MOSTRAR EL TEXTO SI ES POSIBLE
         if(output != null){
            input.onEndEdit = se;
         }
         
 
     }
 
     private void SubmitInput(string A)
     {
         string currentText = output.text;
         string newText = currentText + "\n" + ">" + A;
         output.text = newText;
         input.text = "";
         input.ActivateInputField();
     }
 }
 