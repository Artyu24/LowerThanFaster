using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    private bool isInRange;

    public Text pnjTalk;

    private void Update()
    {
        //Permet ici de changer le texte du PNJ quand on est dans la zone
        if (Input.GetKeyDown(KeyCode.F) && isInRange)
        {
            //Modifie le texte
            pnjTalk.text = "Coucou j'espere que tu comprends le code :D";
        }
    }


    /// <summary>
    /// Detecte quand on entre dans la zone
    /// Ici affiche un texte pour nous demander d'intéragir
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Dit qu'on est dans la zone
            isInRange = true;

            //Affiche le gameObject
            pnjTalk.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Detecte quand on sort de la zone
    /// Ici cela cache le texte et le reset avec la phrase de base
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Dit qu'on est plus dans la zone
            isInRange = false;

            //Desactive le gameObject
            pnjTalk.gameObject.SetActive(false);

            //Reset le Texte
            pnjTalk.text = "Appuie sur F pour me parler !";
        }
    }
}
