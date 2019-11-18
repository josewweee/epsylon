using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using System.Text;
using UnityEngine.Networking;

public class QuestManager : MonoBehaviour
{



    private bool statuspost = false;
    public Text textstatusscore;
    public InputField in_quest;
    public InputField in_answer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deletequest()
    {
        string urll = "http://52.0.82.220/api/post/preguntas/deletepreguntas";

        StartCoroutine(DeleteRequest(url:urll));
        IEnumerator DeleteRequest(string url)
        {
            UnityWebRequest uwr = UnityWebRequest.Delete(url);
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                Debug.Log("Deleted");
            }
        }
    }
    public async void postearAsync()
    {
        System.Random r = new System.Random();
        int genRand = r.Next(1000, 100000);
        string id = (genRand).ToString();
        string idcomida = "1";
        string quest = in_quest.text;
        string answer = in_answer.text;

        string urll = "http://52.0.82.220/api/post/preguntas";

        string myJson = "{" +
            "\"id\":\"" + id + "\"," +
            "\"idcomida\":\"" + idcomida + "\"," +
            "\"question\":\"" + quest + "\"," +
            "\"answer\":\"" + answer + "\"" +
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
            textstatusscore.text = "Pregunta Guardada";
            statuspost = false;
            in_quest.text = "";
            in_answer.text = "";
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
                    "http://52.0.82.220/api/post/preguntas",
                     new StringContent(myJson, Encoding.UTF8, "application/json"));
            }
            textstatusscore.text = "Pregunta Guardada";
            statuspost = false;
            in_quest.text = "";
            in_answer.text = "";
        }
        else
        {
            textstatusscore.text = "Ya ha sido Guardado tu Pregunta";
        }
        */


    }
}
    public class quest{
    public int idcomida { get; set; }
    public int id { get; set; }
    public string question { get; set; }
    public string answer { get; set; }
}
