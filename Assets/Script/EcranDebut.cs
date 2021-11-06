using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcranDebut : MonoBehaviour
{

    public GameObject healthbar;
    public GameObject horloge;
    public GameObject panel1;
    public GameObject panel2;

    public Image[] visuel;
    private int placeUI = 0;
    private bool page2 = false;
    private bool done = false;


    void Start()
    {

    }
    
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space)) && page2)
        {

            healthbar.SetActive(true);
            horloge.SetActive(true);
            Destroy(gameObject);
        }

        if ((Input.GetKeyDown(KeyCode.Space))&&page2==false)
        {
            page2 = true;
            panel2.SetActive(true);
            panel1.SetActive(false);
        }

        if ((GameManager.instance.objectToFind.Length == 4)&& done==false)
        {
            foreach (GameObject truc in GameManager.instance.objectToFind)
            {
                visuel[placeUI].sprite = truc.GetComponent<SpriteRenderer>().sprite;
                visuel[placeUI].gameObject.SetActive(true);
                placeUI++;
            }
            done = true;

        }

    }


}
