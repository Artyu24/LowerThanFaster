using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{

    private bool isInRange;
    private bool presence=true; 
    public Text message;
    public Image visuel;

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        if (isInRange && (Input.GetKeyDown(KeyCode.F) && presence))
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(Obtenu());
            presence = false;
            visuel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            message.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            message.gameObject.SetActive(false);
            message.text = "Appuyer \"F\" pour ramasser l'objet";
        }
    }

    IEnumerator Obtenu()
    {
        message.text = "Objet obtenu!";
        yield return new WaitForSeconds(3);
        message.gameObject.SetActive(false);
        Destroy(gameObject);
        
    }
}
