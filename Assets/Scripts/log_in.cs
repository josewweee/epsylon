using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class log_in : MonoBehaviour
{
    public Text text_login_users;
    public Text text_login_password;

    public Text text_register_users;
    public Text text_register_password;
    public Text status_login;

    //VARIABLE GLOBAL DEL USUARIO
    public static string nombreUsuario;
    public static bool is_teacherr;

    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
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
        string urll = "http://52.0.82.220/api/post/peoples";

        string myJson = "{" +
            "\"username\":\"" + username + "\"," +
            "\"password\":\"" + password + "\"," +
            "\"isteacher\": "+ "0" + "" +
            "}";

        myJson = myJson.Replace("\r\n", "");
        Debug.Log(myJson);
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
            status_login.text = "Te has registrado con exito";

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
            status_login.text = "Te has registrado con exito";
        }
        else
        {
            textstatusscore.text = "Ya ha sido Guardado tu puntaje";
        }
        */
    }

    public void log_in_user()
    {
        string urll = "http://52.0.82.220/api/post/peoples/allpeople";

        WWW wwwl = new WWW(urll);
        StartCoroutine(GetdataEnumerator(www: wwwl));
        IEnumerator GetdataEnumerator(WWW www)
        {
            //Wait for request to complete
            yield return www;
            string json = www.text;

            if (verifyaccount(text_login_users.text, text_login_password.text,json))
            {
                nombreUsuario = text_login_users.text;
                SceneManager.LoadScene("menu");
            }
            else
            {
                status_login.text = "Contraseña o usuario no encontrado";
                Debug.Log("ERROR LOGIN");
            }

        }

      
    }
    public bool verifyaccount(string tempusers, string temppassword,string myjson)
    {
        //string myjson = getall();

        List<userlogin> myDeserializedObjList = (List<userlogin>)Newtonsoft.Json.JsonConvert.DeserializeObject(myjson, typeof(List<userlogin>));
        
        foreach (userlogin o in myDeserializedObjList)
        {
            if (String.Equals(o.username, tempusers))
            {
                if (String.Equals(o.password, temppassword))
                {
                    if (o.isteacher ==true)
                    {
                        Debug.Log("ADMIN LOGIN");
                        is_teacherr = true;
                    }
                    else
                    {
                        is_teacherr = false;
                    }
                    return true;
                }
            }
        }
        return false;
    }

    /*
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
   */
}

public class userlogin
{
    public string username { get; set; }
    public string password { get; set; }
    public bool isteacher { get; set; }

}