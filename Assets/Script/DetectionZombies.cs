using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZombies : MonoBehaviour
{
    public bool detected = false;
    public GameObject Range;
    public float rangeMax;
    public float rangeMin;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        
        //Change la portée de détection des zombies si le joueur court ou non
        if (player.GetComponent<Deplacement1>().sprint)
        {
            Range.GetComponent<CircleCollider2D>().radius = rangeMax;
        }
        else
        {
            Range.GetComponent<CircleCollider2D>().radius = rangeMin;
        }
    }
    //Vérifie si le joueur est a portée
    //Cela permettra de savoir si les zombies se baladent aléatoirement ou non
    private void OnTriggerEnter2D(Collider2D collision_in)
    {

        

        if (collision_in.CompareTag("Player")&& player.GetComponent<Deplacement1>().sprint)
        {//Penser à rajouter un système permettant de vérifier qu'il n'y a pas d'obstacle entre les zombies et le joueur
            detected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& player.GetComponent<Deplacement1>().sprint)
        {
            detected = false;
        }
    }
}
