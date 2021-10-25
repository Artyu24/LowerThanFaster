using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HORLOGE : MonoBehaviour
{
    public float timeToPlay;
    private float memory;
    private bool isStart;

    private void Start()
    {
        memory = timeToPlay;
        timeToPlay = 360 / timeToPlay;
    }

    private void Update()
    {
        if (!isStart)
            StartCoroutine(Aiguille());
    }

    private IEnumerator Aiguille()
    {
        isStart = true;
        for(int i = 0; i < memory; i++)
        {
            yield return new WaitForSeconds(1);
            gameObject.transform.Rotate(new Vector3(0, 0, -timeToPlay));
        }

    }
}
