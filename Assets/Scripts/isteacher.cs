using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isteacher : MonoBehaviour
{

    public GameObject cat;
    // Start is called before the first frame update
    void Start()
    {
        string username = log_in.nombreUsuario;

        if (log_in.is_teacherr == true)
        {
            cat.SetActive(true); // false to hide, true to show
        }
        else
        {
            cat.SetActive(false); // false to hide, true to show
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
