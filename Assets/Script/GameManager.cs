using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isDead;
    public bool victory;

    public int nbrObjectToFind;

    [Header("Object")]
    public GameObject[] listObject;
    public GameObject[] ListBonusObjects;

    [Header("Spawn Point")]
    public GameObject[] spawnPointObject;

    public GameObject[] objectToFind;

    private void Start()
    {
        if (instance == null)
            instance = this;

        //Spawn des objets en random !
        foreach (GameObject collectable in listObject)
        {
            int random = Random.Range(0, spawnPointObject.Length);
            while (spawnPointObject[random].transform.position == new Vector3(0, 0, 0))
                random = Random.Range(0, spawnPointObject.Length);
            Instantiate(collectable, spawnPointObject[random].transform.position, Quaternion.identity);
            spawnPointObject[random].transform.position = new Vector3(0,0,0);
            Destroy(spawnPointObject[random]);
        }

        foreach (GameObject collectable in ListBonusObjects)
        {
            int random = Random.Range(0, spawnPointObject.Length);
            while (spawnPointObject[random].transform.position == new Vector3(0, 0, 0))
                random = Random.Range(0, spawnPointObject.Length);
            Instantiate(collectable, spawnPointObject[random].transform.position, Quaternion.identity);
            spawnPointObject[random].transform.position = new Vector3(0, 0, 0);
            Destroy(spawnPointObject[random]);
        }

        //Créé une liste contenant les objets à trouver !
        objectToFind = new GameObject[nbrObjectToFind];
        for(int i = 0; i < nbrObjectToFind; i++)
        {
            int randomItem = Random.Range(0, listObject.Length);
            int test = 0;
            while (test != objectToFind.Length)
            {
                test = 0;
                foreach(GameObject item in objectToFind)
                {
                    if (item == listObject[randomItem])
                        randomItem = Random.Range(0, listObject.Length);
                    else
                        test++;
                }
            }
            objectToFind[i] = listObject[randomItem];
            Debug.Log(listObject[randomItem]);
        }
    }

    void Update()
    {
        if (isDead)
        {
            SceneManager.LoadScene(2);
        }
        else if (victory)
        {
            SceneManager.LoadScene(3);
        }
    }
}
