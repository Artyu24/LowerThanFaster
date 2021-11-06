using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    //Permet de mettre un d�calage de temps � la cam�ra
    public float timeOffset;

    //Permet de donner la vitesse de d�placement de la cam�ra
    public Vector3 posOffset;

    //R�f�rence pour le SmoothDamp
    private Vector3 velocity;

    /// <summary>
    /// Permet d'acc�der � la position de la cam�ra et de d�placer l'objet d'un endroit � un autre � une certaine vitesse
    /// On d�finie d'abord la position ou se trouve la cam�ra, puis l'endroit o� elle va se d�placer � savoir la position du joueur + un d�calage,
    /// On d�finie une r�f�rence de base, puis le temps que doit mettre la cam�ra � effectuer son mouvement.
    /// </summary>
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
