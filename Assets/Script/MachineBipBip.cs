using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBipBip : MonoBehaviour
{
    public bool machineReceived;
    private bool nextBip;
    public int bipTiming;
    public GameObject Player;
    public GameObject Item;
    void Start()
    {
        //Initialise le fait que le bipeur n'ait pas possédé par le joueur
        machineReceived = false;
        //Initialise le bipeur
        nextBip = true;
    }

    void Update()
    {
        if (machineReceived && nextBip)
        {
            //
            float distance;
            //Relance la coroutine dès que celle-ci se finit
            TestDistance();
            nextBip = false;
        }
    }
    IEnumerator TestDistance()
    {
        if (2==2)
        {
            //Travail encore à faire
            //Il faut augmenter la fréquence des bips en fonction de la distance avec l'item
        }
        yield return new WaitForSeconds(bipTiming);
        nextBip = true;
    }
}
