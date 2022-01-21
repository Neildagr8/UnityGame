using UnityEngine;
using UnityEngine.UI;
using System;


public class Report : MonoBehaviour
{

    public Text repo;


    float okjh;
    float escore; 
    // Start is called before the first frame update
    void Start()
    {
        
        escore = PlayerPrefs.GetInt("escore", 0);
        repo.text = escore.ToString();



    }

}
