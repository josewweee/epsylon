using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostScore : MonoBehaviour
{

    private bool statuspost = false;
    public Text textstatusscore ;
    public Text textusername;
    public InputField in_description;
    void Start()
    {
        string username = log_in.nombreUsuario;
        textusername.text = username;
    }
    public async void postearAsync()
    {
        
        string username = log_in.nombreUsuario;
        textusername.text = username;

       // textusername.text = "User1";
        //username = "User1";

        System.Random r = new System.Random();
        int genRand = r.Next(1000, 100000);
        string id = (genRand).ToString();
        string score = (Puntaje.puntajeJugador).ToString();
        string description = in_description.text;

        string urll = "http://52.0.82.220/api/post/puntajes";

        string myJson = "{" +
            "\"username\":\"" + username + "\"," +
            "\"id\":\"" + id + "\"," +
            "\"score\":\"" + score + "\"," +
            "\"description\":\"" + description + "\"" +
            "}";
        myJson = myJson.Replace("\r\n", "");

        StartCoroutine(PostRequest(url: urll, json: myJson));

        IEnumerator PostRequest(string url, string json)
        {
            var uwr = new UnityWebRequest(url, "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");

            //Send the request then wait here until it returns
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                Debug.Log("Received: " + uwr.downloadHandler.text);
            }

        }


        /*
        Debug.Log(myJson);
        if (!statuspost)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "http://52.0.82.220/api/post/puntajes",
                     new StringContent(myJson, Encoding.UTF8, "application/json"));
            }
            textstatusscore.text = "Puntaje Guardado";
            statuspost = true;
        }
        else
        {
            textstatusscore.text = "Ya ha sido Guardado tu puntaje";
        }


        
        var httpWebRequest = WebRequest.Create(url);
        //var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.ContentType = "application/json; charset=utf-8";
        httpWebRequest.Method = "POST";
        //httpWebRequest.Accept = "application/json; charset=utf-8";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            
            //json = json.Replace("\",", "\","   + "\"" +"\u002B");
            streamWriter.Write(myJson);
            streamWriter.Flush();
            streamWriter.Close();
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
           // pass.Text = result.ToString();
        }
        */



    }

    public class userScore
    {
        public string username { get; set; }
        public string id { get; set; }
        public string score { get; set; }
        public string description { get; set; }

    }

}
