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
        machineReceived = false;
        nextBip = true;
    }

    void Update()
    {
        if (machineReceived && nextBip)
        {
            TestDistance();
            nextBip = false;
        }
    }
    IEnumerator TestDistance()
    {
        if (2==2)
        {

        }
        yield return new WaitForSeconds(bipTiming);
        nextBip = true;
    }
}
