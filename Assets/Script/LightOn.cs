using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightOn : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Light2D>().enabled = false;
    }

    /// <summary>
    /// Si le joueur entre dans la salle
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Light2D>().enabled = true;
            gameObject.SetActive(true);
        }
    }
}
