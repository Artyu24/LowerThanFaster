using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeplacement : MonoBehaviour
{
    // J'ai réutilisé les bases du déplacement du player de Théo ©
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
            //Détermine la direction dans laquelle les zombies se dirigent lorsqu'ils ont détecté le joueur
            horizontalMovement = moveSpeedEnemy * Time.fixedDeltaTime * 1;
        }
        else 
        {
            // Détermine aléatoirement le déplacement des ennemis en fonction de leur vitesse
            horizontalMovement = Random.Range(-1, 2) * Random.Range(0,moveSpeedEnemy) * Time.fixedDeltaTime;
            verticalMovement = Random.Range(-1, 2) * Random.Range(0, moveSpeedEnemy) * Time.fixedDeltaTime;
        }
        //Créé un vecteur désigant la direction dans laquel va aller l'ennemi
        Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);

        //Permet au personnage de se déplacer de façon progressive allant de sa position au vecteur déclarer au dessus
        rbEnemy.velocity = Vector3.SmoothDamp(rbEnemy.velocity, targetVelocity, ref velocity, .05f);
    }

}