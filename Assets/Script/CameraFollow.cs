using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    //Permet de mettre un décalage de temps à la caméra
    public float timeOffset;

    //Permet de donner la vitesse de déplacement de la caméra
    public Vector3 posOffset;

    //Réfèrence pour le SmoothDamp
    private Vector3 velocity;

    /// <summary>
    /// Permet d'accéder à la position de la caméra et de déplacer l'objet d'un endroit à un autre à une certaine vitesse
    /// On définie d'abord la position ou se trouve la caméra, puis l'endroit où elle va se déplacer à savoir la position du joueur + un décalage,
    /// On définie une référence de base, puis le temps que doit mettre la caméra à effectuer son mouvement.
    /// </summary>
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
