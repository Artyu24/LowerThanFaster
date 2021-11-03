using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolSafe : MonoBehaviour


{

    private bool isInRange = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GentilsZombies()
    {
        DetectionZombies[] tabZombies = FindObjectsOfType<DetectionZombies>();
        foreach(DetectionZombies zombie in tabZombies)
        {
            zombie.detected = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            StartCoroutine(ActivationZoneSafe());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
    IEnumerator ActivationZoneSafe()
    {
        while (isInRange)
        {
            yield return new WaitForSeconds(5);
            GentilsZombies();
        }
    }
}
