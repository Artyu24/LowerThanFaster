using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isDead;
    public bool victory;

    public GameObject[] listObject;

    private void Start()
    {
        if (instance == null)
            instance = this;
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
