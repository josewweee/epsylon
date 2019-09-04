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
 
     private void SubmitInput(string A)
     {

        if (A == "Banana" || A == "Sugar"){
           
            string currentText = output.text;
         string newText = currentText + "\n" + ">" + A;
         output.text = newText;
         input.text = "";
         input.ActivateInputField();
        }
        else
        {
          Malescrito.SetActive(true);
        
        }

     }
 }
 