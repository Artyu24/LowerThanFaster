using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROFESEUUUUUR : MonoBehaviour
{

    public static PROFESEUUUUUR instance;

    private void Start()
    {
        if(instance == null)
            instance = this;
    }

    void Update()
    {
        
    }

    public void BONJOUR()
    {

    }
}

