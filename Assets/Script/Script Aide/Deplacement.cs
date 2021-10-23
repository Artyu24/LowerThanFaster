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
        // Permet de définir le mouvement horizontal et sa puissance en fonction de la touche préssé, la vitesse et le temps
        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        //Créé un vecteur désigant la direction dans laquel va aller le personnage. Le x correspond à la vitesse calculer et le y c est la vitesse du personnage à ce moment la
        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);

        //Permet au personnage de se déplacer de façon progressive allant de sa position au vecteur déclarer au dessus
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
}
