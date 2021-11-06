using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeplacement : MonoBehaviour
{
    // J'ai r�utilis� les bases du d�placement du player de Th�o �
    public float moveSpeedEnemy;
    public Rigidbody2D rbEnemy;
    public DetectionZombies detectionZombies;
    private GameObject player;
    public GameObject zombies;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {

        if (detectionZombies.detected)
        {
            //D�termine la direction dans laquelle les zombies se dirigent lorsqu'ils ont d�tect� le joueur
            bool test1 = player.GetComponent<Transform>().position.x > zombies.GetComponent<Transform>().position.x;
            bool test2 = player.GetComponent<Transform>().position.x < zombies.GetComponent<Transform>().position.x;
            horizontalMovement = moveSpeedEnemy * Time.fixedDeltaTime * ( test1 ? 1 : test2 ? -1 : 0 );
            bool test3 = player.GetComponent<Transform>().position.y > zombies.GetComponent<Transform>().position.y;
            bool test4 = player.GetComponent<Transform>().position.y < zombies.GetComponent<Transform>().position.y;
            verticalMovement = moveSpeedEnemy * Time.fixedDeltaTime * (test3 ? 1 : test4 ? -1 : 0);
        }
        else if (Random.Range(0,1000)<=10)
        {
            // D�termine al�atoirement le prochain d�placement des ennemis en fonction de leur vitesse
            horizontalMovement = Random.Range(-1, 2) * moveSpeedEnemy/2 * Time.fixedDeltaTime;
            verticalMovement = Random.Range(-1, 2) * moveSpeedEnemy / 2 * Time.fixedDeltaTime;
        }
        //Cr�� un vecteur d�sigant la direction dans laquel va aller l'ennemi
        Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);

        //Permet au personnage de se d�placer de fa�on progressive allant de sa position au vecteur d�clarer au dessus
        rbEnemy.velocity = Vector3.SmoothDamp(rbEnemy.velocity, targetVelocity, ref velocity, .05f);


        //Orientation du sprite
        if (horizontalMovement < 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (horizontalMovement > 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        


    }
}