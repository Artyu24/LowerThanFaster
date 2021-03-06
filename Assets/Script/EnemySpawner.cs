using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numberEnemy;
    public int Difficulty;

    public GameObject enemy;

    void Start()
    {
        Difficulty = MainMenu.Hardeur;
        switch (Difficulty)
        {
            case 2:
                numberEnemy += 10;
                break;
            case 1:
                numberEnemy += 5;
                break;
            default:
                break;
        }

        for (int i = 0; i < numberEnemy; i++)
        {
            Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation); 
        }
    }
}
