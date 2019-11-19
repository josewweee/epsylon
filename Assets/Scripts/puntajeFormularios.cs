using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puntajeFormularios : MonoBehaviour
{
    //ARREGLO CON PREGUNTAS Y RESPUESTAS
    public List<string> preguntas;
    public List<string> respuestas;

    public List<string> tempquest;
    public List<string> tempanswer;

    //EL PUNTAJE VIENE DE LA CLASE 'Puntaje'
    public bool[] completed;

    //VARIABLE QUE NOS AVISARA CUANDO LA DB HAYA SIDO DESCARGADA
    public bool dbDescargada = false;
    

    //RESPUESTAS DEL USUARIO
    public InputField inp1;
    public InputField inp2;
    public InputField inp3; 
    public InputField inp4;
    public InputField inp5;
    public InputField inp6;
    public InputField inp7;

    //RESPUESTAS DE LA DB
    public string respuesta0;
    public string respuesta1;
    public string respuesta2; 
    public string respuesta3;
    public string respuesta4;
    public string respuesta5;
    public string respuesta6;


    //PREGUNTAS DE LA DB
    public Text Pregunta0;
    public Text Pregunta1;
    public Text Pregunta2; 
    public Text Pregunta3;
    public Text Pregunta4; 
    public Text Pregunta5;
    public Text Pregunta6;



    void Start()
    {
        //INICIAMOS LAS VARIABLES QUE RECOLECTAN DE LA DB
        preguntas = new List<string>();
        respuestas = new List<string>();

        //PEDIMOS LA INFO DE LA DB
        getall();

        //PONEMOS LOS VALORES DE LA DB EN UNITY
        /* foreach (var x in preguntas){
            inp1.text = x;
            Debug.Log("pregunta:" + x);
        } */


        //PONEMOS TODOS LOS CHECKEOS DE PREGUNTAS EN NO RESPONDIDAS
        completed = new bool [7];
        completed[0] = false;
        completed[1] = false;
        completed[2] = false;
        completed[3] = false;
        completed[4] = false;
        completed[5] = false;
        completed[6] = false;

    }


    void Update()
    {
        Scene escenaActual = SceneManager.GetActiveScene();
        string nombreEscena = escenaActual.name;
        if ( nombreEscena.ToUpper() == "story_time".ToUpper() && dbDescargada == true) {
            StoryQuestions();
        }
    }

    void StoryQuestions() {
        if ( completed[0] == false && inp1.text.ToUpper().Contains(respuesta0.ToUpper()) )
        {
            Debug.Log("completado" + respuesta0);
            Puntaje.puntajeJugador += 10f;
            completed[0] = true;
        }

        if ( completed[1] == false && inp2.text.ToUpper().Contains(respuesta1.ToUpper()) )
        {
            Puntaje.puntajeJugador += 10f;
            completed[1] = true;
        }

        if ( completed[2] == false && inp3.text.ToUpper().Contains(respuesta2.ToUpper()) )
        {
            Puntaje.puntajeJugador += 10f;
            completed[2] = true;
        }

        if ( completed[3] == false && inp4.text.ToUpper().Contains(respuesta3.ToUpper()) )
        {
            Puntaje.puntajeJugador += 10f;
            completed[3] = true;
        }

       if ( completed[4] == false && inp5.text.ToUpper().Contains(respuesta4.ToUpper()) )
        {
            Puntaje.puntajeJugador += 10f;
            completed[4] = true;
        }

        if ( completed[5] == false && inp6.text.ToUpper().Contains(respuesta5.ToUpper()) )
        {
            Puntaje.puntajeJugador += 10f;
            completed[5] = true;
        }

        if ( completed[6] == false && inp7.text.ToUpper().Contains(respuesta6.ToUpper()) )
        {
            Puntaje.puntajeJugador += 10f;
            completed[6] = true;
        }
        // Debug.Log("H: " + Puntaje.puntajeJugador);
    }


    public void getquestdb(string myjson)
    {

        //VARIABLES COLECTORAS
        tempquest = new List<string>();
        tempanswer = new List<string>();


        List<uquest> myDeserializedObjList = (List<uquest>)Newtonsoft.Json.JsonConvert.DeserializeObject(myjson, typeof(List<uquest>));

        foreach (uquest o in myDeserializedObjList)
        {
            if (!string.Equals(o.question, null))
            {
                //AQUI AGREGA UNA POR UNA AQUI AGREGAS A EL ARREGLO QUE UQERAS
                tempquest.Add(o.question);
                tempanswer.Add(o.answer);
                
            }
        }
        //ASIGNAMOS LAS LISTAS DE LA DB A VARIABLES LOCALES
        preguntas = tempquest;
        respuestas = tempanswer;

         for (int i = 0; i < preguntas.Count; i++)
        {
            switch (i)
            {
            case 0:
                Pregunta0.text = preguntas[i];
                respuesta0 = respuestas[i];
                break;
            case 1:
                Pregunta1.text = preguntas[i];
                respuesta1 = respuestas[i];
                break;
            case 2:
                Pregunta2.text = preguntas[i];
                respuesta2 = respuestas[i];
                break;
            case 3:
                Pregunta3.text = preguntas[i];
                respuesta3 = respuestas[i];
                break;
            case 4:
                Pregunta4.text = preguntas[i];
                respuesta4 = respuestas[i];
                break;
            case 5:
                Pregunta5.text = preguntas[i];
                respuesta5 = respuestas[i];
                break;
            case 6:
                Pregunta6.text = preguntas[i];
                respuesta6 = respuestas[i];
                break;
            default:
                break;
            }
        }
        dbDescargada = true;
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
