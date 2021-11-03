using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(GetComponent<Camera>().enabled == false)
                GetComponent<Camera>().enabled = true;
            else
                GetComponent<Camera>().enabled = false;
        }

    }
}
