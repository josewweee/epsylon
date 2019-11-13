using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text pusers;
    public Text pscore;
    public InputField in_code;
    public Text directcode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showscores()
    {
        string myjson = getall();
        string tempusers = "";
        string temphighscore = "";
        List<userScore> myDeserializedObjList = (List<userScore>)Newtonsoft.Json.JsonConvert.DeserializeObject(myjson, typeof(List<userScore>));
        foreach (userScore o in myDeserializedObjList)
        {
            if (!String.Equals(o.username, null))
            {
                tempusers += (o.username) + "\n";
                temphighscore += (o.score) + "\n";
            }
        }
        pusers.text = tempusers;
        pscore.text = temphighscore;
        //Debug.Log(myDeserializedObjList);
    }

    public string getall()
    {
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
    }

    public void getscorecode()
    {
        string myjson = getall();
        string tempusers = "";
        string temphighscore = "";
        List<userScore> myDeserializedObjList = (List<userScore>)Newtonsoft.Json.JsonConvert.DeserializeObject(myjson, typeof(List<userScore>));
        foreach (userScore o in myDeserializedObjList)
        {
            if (!String.Equals(o.username, null))
            {
                if (String.Equals(o.description, in_code.text))
                {
                    tempusers += (o.username) + "\n";
                    temphighscore += (o.score) + "\n";
                }                    
            }
        }
        pusers.text = tempusers;
        pscore.text = temphighscore;
        //Debug.Log(myDeserializedObjList);
    }
}

public class userScore
{
    public string username { get; set; }
    public string id { get; set; }
    public string score { get; set; }
    public string description { get; set; }

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
