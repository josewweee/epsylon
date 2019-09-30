using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puntajeFormularios : MonoBehaviour
{
    public float puntaje = 0;
    //VARIABLES NIVEL HISTORIA
    public InputField inp1;
    public InputField inp2;
    public InputField inp3; 
    public InputField inp4;
    public InputField inp5;
    public InputField inp6;
    public InputField inp7;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //PREGUNTAS HISTORIA
        if( inp1.text.ToUpper() == "His name is Dubois".ToUpper()) 
        {
            puntaje += 5f;
        } else if (inp1.text.ToUpper().Contains("Dubois".ToUpper()) )
        {
            puntaje += 2.5f;
        }

        if( inp2.text.ToUpper() == "His last name Carpentier".ToUpper()) 
        {
            puntaje += 5f;
        } else if (inp2.text.ToUpper().Contains("Carpentier".ToUpper()) )
        {
            puntaje += 2.5f;
        }

        if( inp3.text.ToUpper() == "He was born in Bordeaux".ToUpper()) 
        {
            puntaje += 5f;
        } else if (inp3.text.ToUpper().Contains("Bordeaux".ToUpper()) )
        {
            puntaje += 2.5f;
        }

        if( inp4.text.ToUpper() == "For 3 years".ToUpper()) 
        {
            puntaje += 5f;
        } else if (inp4.text.ToUpper().Contains("3".ToUpper()) )
        {
            puntaje += 2.5f;
        }

       if (inp5.text.ToUpper().Contains("no".ToUpper()) )
        {
            puntaje += 5f;
        }

        if( inp6.text.ToUpper() == "They are green".ToUpper()) 
        {
            puntaje += 5f;
        } else if (inp6.text.ToUpper().Contains("green".ToUpper()) )
        {
            puntaje += 2.5f;
        }

        if (inp7.text.ToUpper().Contains("playful".ToUpper()) && inp1.text.ToUpper().Contains("attentive".ToUpper()) )
        {
            puntaje += 5f;
        } else if ( inp7.text.ToUpper().Contains("playful".ToUpper()) && inp1.text.ToUpper().Contains("attentive".ToUpper()) )
        {
            puntaje += 2.5f;
        }
        //Debug(puntaje);
    }
    
}
