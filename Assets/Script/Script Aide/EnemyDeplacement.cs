using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeplacement : MonoBehaviour
{
    // J'ai r�utilis� les bases du d�placement du player de Th�o �
    public float moveSpeedEnemy;
    public Rigidbody2D rbEnemy;
    public DetectionZombies detectionZombies;
    public GameObject player;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;

    private void FixedUpdate()
    {

        if (detectionZombies.detected)
        {
            //D�termine la direction dans laquelle les zombies se dirigent lorsqu'ils ont d�tect� le joueur
            horizontalMovement = moveSpeedEnemy * Time.fixedDeltaTime * 1;
        }
        else 
        {
            // D�termine al�atoirement le d�placement des ennemis en fonction de leur vitesse
            horizontalMovement = Random.Range(-1, 2) * Random.Range(0,moveSpeedEnemy) * Time.fixedDeltaTime;
            verticalMovement = Random.Range(-1, 2) * Random.Range(0, moveSpeedEnemy) * Time.fixedDeltaTime;
        }
        //Cr�� un vecteur d�sigant la direction dans laquel va aller l'ennemi
        Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);

        //Permet au personnage de se d�placer de fa�on progressive allant de sa position au vecteur d�clarer au dessus
        rbEnemy.velocity = Vector3.SmoothDamp(rbEnemy.velocity, targetVelocity, ref velocity, .05f);
    }

}