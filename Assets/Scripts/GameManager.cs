using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static float gravitance = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this; // this refers to the current instance of the class
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
