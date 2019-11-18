using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Showquest : MonoBehaviour
{
    public Text pquest;
    public Text panswer;
    public Text pid;

    public InputField in_code;

    public InputField tquest;
    public InputField tanswer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void showspesific()
    {
        getall(2);
    }

    public void showquests()
    {
        getall(1);  
    }

    public void showsquesttin(string myjson)
    {
        //string myjson = getall();
        string tempquest = "";
        string tempanswer = "";
        string tempid = "";
        List<uquest> myDeserializedObjList = (List<uquest>)Newtonsoft.Json.JsonConvert.DeserializeObject(myjson, typeof(List<uquest>));
        foreach (uquest o in myDeserializedObjList)
        {
            if (!String.Equals(o.question, null))
            {
                tempquest += (o.question) + "\n";
                tempanswer += (o.answer) + "\n";
                tempid += (o.idcomida) + "\n";
            }
        }
        pquest.text = tempquest;
        panswer.text = tempanswer;
        pid.text = tempid;
        Debug.Log(myDeserializedObjList);
    }

    public void getall(int i)
    {
        string urll = "http://52.0.82.220/api/post/preguntas/allpreguntas";

        WWW wwwl = new WWW(urll);
        StartCoroutine(GetdataEnumerator(www: wwwl));
        IEnumerator GetdataEnumerator(WWW www)
        {
            //Wait for request to complete
            yield return www;
            string json = www.text;
            if (i == 1)
            {
                showsquesttin(json);
            }
            else
            {
                getsquespesific(json);
            }

        }

        /*
        using (WebClient webClient = new System.Net.WebClient())
        {
            //Debug.Log("Hello World!");
            WebClient n = new WebClient();
            var json = n.DownloadString("http://52.0.82.220/api/post/puntajes/allpuntaje");
            string valueOriginal = Convert.ToString(json);
            //Debug.Log(json);
            //Debug.Log(valueOriginal);
            return valueOriginal;
        }
        */
    }

    public void getsquespesific(string myjson)
    {
        //string myjson = getall();
        string tempquest = "";
        string tempanswer = "";
        List<uquest> myDeserializedObjList = (List<uquest>)Newtonsoft.Json.JsonConvert.DeserializeObject(myjson, typeof(List<uquest>));
        
        foreach (uquest o in myDeserializedObjList)
        {
            if (!String.Equals(o.question, null))
            {
                if (String.Equals(o.question, in_code.text))
                {
                    tempquest = (o.question);
                    tempanswer = (o.answer) ;
                }                    
            }
        }
        tquest.text = tempquest;
        tanswer.text = tempanswer;
        //Debug.Log(myDeserializedObjList);
    }
    
    

    public class uquest
    {
        public string idcomida { get; set; }
        public string id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        /*
     * //Code to StackOverflow.com question: http://stackoverflow.com/questions/34302845/deserialize-json-into-object-c-sharp

    using System;
    using System.Collections.Generic;

    public class MyObject
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            List<Dictionary<string, string>> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(JsonFile.Text);

            foreach(Dictionary<string, string> lst in obj)
            {
                Console.WriteLine("--NewObject--");
                //Console.WriteLine(string.Format("Rk: {0} Gcar: {1}", lst["Rk"], lst["Gcar"]));
                foreach(KeyValuePair<string, string> item in lst)
                {
                    Console.WriteLine(string.Format("Key: {0} Value: {1}", item.Key, item.Value));
                }
            }
        }
    }

    public static class JsonFile
    {
        public static string Text = "[{\"_id\":\"5d943a988a425d001d178413\",\"username\":\"cris\",\"id\":5,\"score\":\"1\",\"description\":\"Test2\",\"__v\":0},{\"_id\":\"5d9443e08a425d001d178415\",\"username\":\"Bihil\",\"id\":322,\"score\":\"21\",\"description\":\"soy bihil\",\"__v\":0}]";
    }
     */



    }
}
