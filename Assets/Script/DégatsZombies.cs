using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DégatsZombies : MonoBehaviour
{
    private bool zombieInRange = false;
    VieDuJoueur vieDuJoueur;
    public int damage=20;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
        if ((zombieInRange)&& gameObject.GetComponent<DetectionZombies>().detected) //le joueur est dans le box collider du zombie et le zombie l'a decouvert
            vieDuJoueur.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zombieInRange = true;
            vieDuJoueur = collision.transform.GetComponent<VieDuJoueur>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zombieInRange = false;
        }
    }
}
