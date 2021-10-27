using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBipBip : MonoBehaviour
{
    public AudioSource sound;

    public Transform point;

    public float radiusLoin;
    public float radiusMoyen;
    public float radiusProche;

    public LayerMask playerLayer;

    private bool cercleLoin;
    private bool cercleMoyen;
    private bool cercleProche;

    private bool secuCoroutine;

    void Update()
    {
        cercleLoin = Physics2D.OverlapCircle(point.position, radiusLoin, playerLayer);
        cercleMoyen = Physics2D.OverlapCircle(point.position, radiusMoyen, playerLayer);
        cercleProche = Physics2D.OverlapCircle(point.position, radiusProche, playerLayer);

        if (cercleProche && !secuCoroutine)
        {
            StartCoroutine(TestDistance(0.5f));
        }
        else if (cercleMoyen && !secuCoroutine)
        {
            StartCoroutine(TestDistance(1));
        }
        else if (cercleLoin && !secuCoroutine)
        {
            StartCoroutine(TestDistance(2));
        }
    }
    IEnumerator TestDistance(float time)
    {
        secuCoroutine = true;
        sound.Play();
        yield return new WaitForSeconds(time);
        secuCoroutine = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(point.position, radiusLoin);
        Gizmos.DrawWireSphere(point.position, radiusMoyen);
        Gizmos.DrawWireSphere(point.position, radiusProche);
    }
}
