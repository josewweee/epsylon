using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class log_in : MonoBehaviour
{
    public Text text_login_users;
    public Text text_login_password;

    public Text text_register_users;
    public Text text_register_password;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    InputField input;
    private bool statuspost = false;
    public Text textstatusscore;

    public async void postearAsync()
    {
        string username = text_register_users.text;
        string password = text_register_password.text;
        string url = "http://52.0.82.220/api/post/peoples";

        string myJson = "{" +
            "\"username\":\"" + username + "\"," +
            "\"password\":\"" + password + "\"" +
            "}";

        myJson = myJson.Replace("\r\n", "");
        Debug.Log(myJson);

        if (!statuspost)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    url,
                     new StringContent(myJson, Encoding.UTF8, "application/json"));
            }
            textstatusscore.text = "Puntaje Guardado";
            statuspost = true;
        }
        else
        {
            textstatusscore.text = "Ya ha sido Guardado tu puntaje";
        }
    }

    public void log_in_user()
    {
        if (verifyaccount(text_login_users.text, text_register_password.text))
        {

            SceneManager.LoadScene("menu");
        }
        else
        {
            Debug.Log("ERROR LOGIN");
        }
    }
    public bool verifyaccount(string tempusers, string temppassword)
    {
        string myjson = getall();
        List<userlogin> myDeserializedObjList = (List<userlogin>)Newtonsoft.Json.JsonConvert.DeserializeObject(myjson, typeof(List<userlogin>));
        foreach (userlogin o in myDeserializedObjList)
        {
            if (String.Equals(o.username, tempusers))
            {
                if (String.Equals(o.password, temppassword))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public string getall()
    {
        using (WebClient webClient = new System.Net.WebClient())
        {
            Debug.Log("Hello World!");
            WebClient n = new WebClient();
            var json = n.DownloadString("http://52.0.82.220/api/post/peoples/allpeople");
            string valueOriginal = Convert.ToString(json);
            Debug.Log(json);
            Debug.Log(valueOriginal);
            return valueOriginal;

        }
    }
   
}

public class userlogin
{
    public string username { get; set; }
    public string password { get; set; }
}