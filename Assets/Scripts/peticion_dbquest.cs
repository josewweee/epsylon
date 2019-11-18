using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peticiondb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getquestdb(string myjson)
    {
        //string myjson = getall();

        //VARIABLES COLECTORAS
        string tempquest = "";
        string tempanswer = "";

        List<uquest> myDeserializedObjList = (List<uquest>)Newtonsoft.Json.JsonConvert.DeserializeObject(myjson, typeof(List<uquest>));

        foreach (uquest o in myDeserializedObjList)
        {
            if (!String.Equals(o.question, null))
            {
                //AQUI AGREGA UNA POR UNA AQUI AGREGAS A EL ARREGLO QUE UQERAS
                tempquest = (o.question);
                tempanswer = (o.answer);
                
            }
        }

        //SALIDA
        //tquest.text = tempquest;
        //tanswer.text = tempanswer;
        //Debug.Log(myDeserializedObjList);
    }


    //METODO QUE SE LLAMA
    public void getall()
    {
        string urll = "http://52.0.82.220/api/post/preguntas/allpreguntas";

        WWW wwwl = new WWW(urll);
        StartCoroutine(GetdataEnumerator(www: wwwl));
        IEnumerator GetdataEnumerator(WWW www)
        {
            //Wait for request to complete
            yield return www;
            string json = www.text;
            getquestdb(json);
        }
    }
        public class uquest
    {
        public string idcomida { get; set; }
        public string id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
    }
}
