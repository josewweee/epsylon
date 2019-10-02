﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PostScore : MonoBehaviour
{

    private bool statuspost = false;
    public Text textstatusscore ;

    public async void postearAsync()
    {
        string username = "Area51";
        string id = "666";
        string score = "51";
        string description = "Naruto";

        string url = "http://52.0.82.220/api/post/puntajes";

        string myJson = "{" +
            "\"username\":\"" + username + "\"," +
            "\"id\":\"" + id + "\"," +
            "\"score\":\"" + score + "\"," +
            "\"description\":\"" + description + "\"" +
            "}";
        myJson = myJson.Replace("\r\n", "");
        Debug.Log(myJson);
        if(!statuspost){
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
       

        /*
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

}