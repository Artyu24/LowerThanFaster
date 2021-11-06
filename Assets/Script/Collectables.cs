using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    private bool isInRange;  
    public Text message; //indication "appuyer sur F"

    private GameObject objet = null; //le dernier objet rencontré par le joueur
    private string nomObjet; //son nom 
    private bool enDestruction=false;

    public Image[] visuel;
    private int placeUI=0;
    private bool isInList=false;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F)) //le joueur recupere un objet
        {
            isInList = false;
            foreach (GameObject truc in GameManager.instance.objectToFind)
            {
                if (truc.GetComponent<SpriteRenderer>().sprite == objet.GetComponent<SpriteRenderer>().sprite)
                {
                    visuel[placeUI].sprite = objet.GetComponent<SpriteRenderer>().sprite;
                    visuel[placeUI].gameObject.SetActive(true);
                    placeUI++;
                    isInList  =  true;
                }
                
            }
            if (isInList==false)
            {
                if (objet.tag == "MusicItem")
                {
                    GameObject[] aled = GameObject.FindGameObjectsWithTag("Collectable");
                    for (int i = 0; i < aled.Length; i++)
                    {
                        foreach (GameObject menfou in GameManager.instance.objectToFind)
                        {
                            if (aled[i].GetComponent<SpriteRenderer>().sprite == menfou.GetComponent<SpriteRenderer>().sprite)
                                aled[i].GetComponent<MachineBipBip>().enabled = true;
                        }
                    }
                }
                else if (objet.tag == "MapItem")
                {
                    MiniMap.instance.canActivateMinimap = true;
                }
            }
            StartCoroutine(Obtenu());
            Destroy(objet);// un message "est obtenu" reste 2 secondes
        }

        if (placeUI == GameManager.instance.nbrObjectToFind)
        {
            GameObject victoire = GameObject.FindGameObjectWithTag("VICTORY");
            victoire.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Collectable" || collision.gameObject.tag == "MusicItem" || collision.gameObject.tag == "MapItem")
        {
            nomObjet = collision.transform.name; 
            objet = GameObject.Find(nomObjet); //on identifie l'objet trouvé
            message.text = "Appuyer \"F\" pour ramasser l'objet"; //(ré)initialisation
            message.gameObject.SetActive(true); //le message apparait
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable" || collision.gameObject.tag == "MusicItem" || collision.gameObject.tag == "MapItem")
        {
            objet = null; //on remet l'objet enregistré à 0
            isInRange = false;
            if (enDestruction == false) //si l'objet se detruit, le joueur sort automatiquement de la zone trigger et le massage disparait alors qu'on veut pas
            {
                message.gameObject.SetActive(false); //disparition du message
                message.text = "Appuyer \"F\" pour ramasser l'objet"; //(ré)initialisation
            }
        }
    }

    IEnumerator Obtenu()
    {
        message.text = "Objet obtenu!";
        enDestruction = true; //parce que si on rentre dans la zone de trigger d'un autre objet avant, c'est lui qui disparait :((
        yield return new WaitForSeconds(2);
        enDestruction = false;
        if (message.text == "Objet obtenu!") //si on est entré dans la zone d'un autre objet et que le message s'est reset, il doit resté affiché et non pas disparaitre
            message.gameObject.SetActive(false);
        
    }
}
