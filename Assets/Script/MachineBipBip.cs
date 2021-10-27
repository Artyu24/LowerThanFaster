using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBipBip : MonoBehaviour
{
    public bool machineReceived;
    private bool nextBip;
    public int bipTiming;
    public GameObject player;
    public GameObject item;
    public AudioSource sound;
    private bool cercleLoin;
    private bool cercleProche;
    private bool cercleMoyen;

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
            
            //Relance la coroutine dès que celle-ci se finit 
            TestDistance();
            nextBip = false;
        }
    }
    IEnumerator TestDistance()
    {
        
        yield return new WaitForSeconds(bipTiming);
        nextBip = true;
    }
}
