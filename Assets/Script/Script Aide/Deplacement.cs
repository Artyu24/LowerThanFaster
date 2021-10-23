using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public float moveSpeed;
    private float input;

    public Rigidbody2D rb;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    private void FixedUpdate()
    {
        // Permet de d�finir le mouvement horizontal et sa puissance en fonction de la touche pr�ss�, la vitesse et le temps
        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        //Cr�� un vecteur d�sigant la direction dans laquel va aller le personnage. Le x correspond � la vitesse calculer et le y c est la vitesse du personnage � ce moment la
        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);

        //Permet au personnage de se d�placer de fa�on progressive allant de sa position au vecteur d�clarer au dessus
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
}
