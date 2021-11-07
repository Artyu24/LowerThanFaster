using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public static MiniMap instance;

    public bool canActivateMinimap;

    private GameObject player;

    private void Start()
    {
        if (instance == null)
            instance = this;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && canActivateMinimap)
        {
            if (GetComponent<Camera>().enabled == false)
            {
                GetComponent<Camera>().enabled = true;
                GetScript(false);
            }
            else
            {
                GetComponent<Camera>().enabled = false;
                GetScript(true);
            }
        }
    }

    private void GetScript(bool canActivate)
    {
        player.GetComponent<Deplacement1>().enabled = canActivate;
        player.GetComponent<Collectables>().enabled = canActivate;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (GameObject zombie in enemy)
        {
            zombie.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            zombie.GetComponent<EnemyDeplacement>().enabled = canActivate;
            foreach (Transform child in zombie.transform)
            {
                if (child.gameObject.tag == "AttaqueZombie")
                {
                    child.GetComponent<DégatsZombies>().enabled = canActivate;
                }
                child.GetComponent<DetectionZombies>().enabled = canActivate;
            }
        }
    }
}
