using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBipBip : MonoBehaviour
{
    public AudioSource sound;

    private Transform point;

    public float radiusLoin;
    public float radiusMoyen;
    public float radiusProche;

    public LayerMask playerLayer;

    private bool cercleLoin;
    private bool cercleMoyen;
    private bool cercleProche;

    private bool secuCoroutine;

    void Awake()
    {
        sound = this.gameObject.GetComponent<AudioSource>();
        point = this.gameObject.transform;
    }

    void Update()
    {
        cercleLoin = Physics2D.OverlapCircle(point.position, radiusLoin, playerLayer);
        cercleMoyen = Physics2D.OverlapCircle(point.position, radiusMoyen, playerLayer);
        cercleProche = Physics2D.OverlapCircle(point.position, radiusProche, playerLayer);

        if (cercleProche)
        {
            sound.volume = MusicManager.instance.volumeMusic;
            if (!secuCoroutine)
                StartCoroutine(TestDistance(0.2f));
        }
        else if (cercleMoyen)
        {
            sound.volume = MusicManager.instance.volumeMusic - 0.4f;
            if (!secuCoroutine)
                StartCoroutine(TestDistance(0.75f));
        }
        else if (cercleLoin)
        {
            sound.volume = MusicManager.instance.volumeMusic - 0.8f;
            if(!secuCoroutine)
                StartCoroutine(TestDistance(1.5f));
        }
        else
        {
            sound.volume = 0;
        }

        Debug.Log("VOLUME : " + sound.volume);
    }
    IEnumerator TestDistance(float time)
    {
        secuCoroutine = true;
        sound.Stop();
        sound.Play();
        Debug.Log("MUSIIIIC");
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
