using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onding : MonoBehaviour
{

    public int NuH�lsa = 100;
    public GameObject fiende1;
    public GameObject fiende2;
    public bool IFrames;
    public Rigidbody kropp;
    public int g�x;
    public int g�z;
    public int g�y;
    public bool g�r;
    public bool HoppCooldown = false;
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("vapen") && IFrames == false)
        {
            if (IFrames == false)
            {
                NuH�lsa = NuH�lsa - 20;
            }
            StartCoroutine(IFrame());
        }
    }

    IEnumerator Hopp()
    {
        yield return new WaitForSecondsRealtime(1);
        HoppCooldown = true;
        yield return new WaitForSecondsRealtime(2);
        HoppCooldown = false;
    }
    IEnumerator G�()
    {
        g�x = Random.Range(-1, 2);
        g�z = Random.Range(-1, 2);
        g�y = Random.Range(0, 6);
        g�r = false;
        yield return new WaitForSecondsRealtime(1);
        g�r = true;
    }

    IEnumerator IFrame()
    {
        IFrames = true;
        yield return new WaitForSecondsRealtime(0.5f);
        IFrames = false;
    }

    void Start()
    {
        g�r = true;
    }

    void Update()
    {
        //d�d D:
        if (NuH�lsa < 1)
        {
            Destroy(fiende1);
            Destroy(fiende2);
        }

        //g�r
        kropp.AddForce(g�x * 2, 0, g�z * 2);

        if (g�r == true)
        {
            StartCoroutine(G�());
        }
        if (g�y == 1 && HoppCooldown == false)
        {
            kropp.AddForce(0, 2, 0);
            StartCoroutine(Hopp());
        }
        else if (g�y != 1)
        {
            kropp.AddForce(0, 0, 0);
        }

    }

}
