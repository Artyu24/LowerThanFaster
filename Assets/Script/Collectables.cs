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

    public Image visuel1; //images dans l'inventaire de chacun des objets à ramasser
    public Image visuel2;
    public Image visuel3;
    public Image visuel4;
    public Image visuel5;
    public Image visuel6;
    public Image visuel7;
    public Image visuel8;
    public Image visuel9;
    public Image visuel10;

    private int nbImages = 0; // chaque case de l'inventaire prise oblige les autres à se decaler
    Vector3 delta = new Vector3(50, 0, 0); //decalement de x=+70 vers la droite pour chaque enplacement occupé
    public Vector3 positionInventaire = new Vector3(-170, 90, 0); //position du 1er emplacement inventaire

    void Start()
    {
        
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F)) //le joueur recupere un objet
        {
            
            StartCoroutine(Obtenu());
            Destroy(objet);// un message "est obtenu" reste 2 secondes
            switch (nomObjet) //l'image de l'objet apparait dans l'inventaire. Def de sa position, l'active, et sort du switch.
            {
                case "Objet1":  { 
                        visuel1.rectTransform.localPosition = positionInventaire + delta * nbImages;
                        visuel1.gameObject.SetActive(true); 
                        break; }
                case "Objet2": { 
                        visuel2.rectTransform.localPosition = positionInventaire + delta * nbImages;
                        visuel2.gameObject.SetActive(true);
                        break; }
                case "Objet3": { 
                        visuel3.rectTransform.localPosition = positionInventaire + delta * nbImages;
                        visuel3.gameObject.SetActive(true);
                        break; }
                case "Objet4": { 
                        visuel4.rectTransform.localPosition = positionInventaire + delta * nbImages;
                        visuel4.gameObject.SetActive(true); 
                        break; }
                case "Objet5":
                    {
                        visuel5.rectTransform.localPosition = positionInventaire + delta * nbImages;
                        visuel5.gameObject.SetActive(true);
                        break;
                    }
                case "Objet6":
                    {
                        visuel6.rectTransform.localPosition = positionInventaire + delta * nbImages;
                        visuel6.gameObject.SetActive(true);
                        break;
                    }
                case "Objet7":
                    {
                        visuel7.rectTransform.localPosition = positionInventaire + delta * nbImages;
                        visuel7.gameObject.SetActive(true);
                        break;
                    }
                case "Objet8":
                    {
                        visuel8.rectTransform.localPosition = positionInventaire + delta * nbImages;
                        visuel8.gameObject.SetActive(true);
                        break;
                    }
                case "Objet9":
                    {
                        visuel9.rectTransform.localPosition = positionInventaire + delta * nbImages;
                        visuel9.gameObject.SetActive(true);
                        break;
                    }
                case "Objet10":
                    {
                        visuel10.rectTransform.localPosition = positionInventaire + delta * nbImages;
                        visuel10.gameObject.SetActive(true);
                        break;
                    }


            }
            nbImages++; //un objet recupéré en plus
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Collectable")
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
        if (collision.gameObject.tag == "Collectable")
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
