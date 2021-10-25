using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{

    private bool isInRange;
    private bool presence=true; 
    public Text message;

    private GameObject objet = null;
    private string nomObjet;
    private bool enDestruction=false;

    public Image visuel1;
    public Image visuel2;
    public Image visuel3;
    public Image visuel4;

    private int nbImages = 0;
    Vector3 delta = new Vector3(70, 0, 0);



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && presence && Input.GetKeyDown(KeyCode.F))
        {
            
            objet.transform.localScale = new Vector3(0, 0, 0);
            presence = false;
            StartCoroutine(Obtenu());
            switch(nomObjet)
            {
                case "Objet1":  { visuel1.rectTransform.position = visuel1.rectTransform.position + delta * nbImages; visuel1.gameObject.SetActive(true); break; }
                case "Objet2": { visuel2.rectTransform.position = visuel2.rectTransform.position + delta * nbImages; visuel2.gameObject.SetActive(true); break; }
                case "Objet3": { visuel3.rectTransform.position = visuel3.rectTransform.position + delta * nbImages; visuel3.gameObject.SetActive(true); break; }
                case "Objet4": { visuel4.rectTransform.position = visuel4.rectTransform.position + delta * nbImages; visuel4.gameObject.SetActive(true); break; }
            }
            nbImages++;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Collectable")
        {
            if (enDestruction==false)
                nomObjet = collision.transform.name;
                objet = GameObject.Find(nomObjet);
            message.gameObject.SetActive(true);
            presence = true;
            isInRange = true;
            message.text = "Appuyer \"F\" pour ramasser l'objet";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            objet = null;
            isInRange = false;
            message.gameObject.SetActive(false);
            message.text = "Appuyer \"F\" pour ramasser l'objet";
        }
    }

    IEnumerator Obtenu()
    {
        message.text = "Objet obtenu!";
        enDestruction = true; //parce que si on rentre dans la zone de trigger d'un autre objet avant, c'est lui qui disparait :((
        yield return new WaitForSeconds(1);
        enDestruction = false;
        if (message.text == "Objet obtenu!")
            message.gameObject.SetActive(false);
        Destroy(objet);
    }
}
