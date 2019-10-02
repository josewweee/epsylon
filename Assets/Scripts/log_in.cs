using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class log_in : MonoBehaviour
{
    public Text textusers;
    public Text textscore;
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
        //input = gameObject.GetComponent<log_in_user>();
        string username = "Area51";
        string password = "";
        string url = "http://52.0.82.220/api/post/peoples";

        string myJson = "{" +
            "\"username\":\"" + username + "\"," +
            "\"password\":\"" + password +  "\"" +
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


    }
