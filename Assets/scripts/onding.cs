using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onding : MonoBehaviour
{

    public int NuHälsa = 100;
    public GameObject fiende1;
    public GameObject fiende2;
    public bool IFrames;
    public Rigidbody kropp;
    public int gåx;
    public int gåz;
    public int gåy;
    public bool går;
    public bool HoppCooldown = false;
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("vapen") && IFrames == false)
        {
            if (IFrames == false)
            {
                NuHälsa = NuHälsa - 20;
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
    IEnumerator Gå()
    {
        gåx = Random.Range(-1, 2);
        gåz = Random.Range(-1, 2);
        gåy = Random.Range(0, 6);
        går = false;
        yield return new WaitForSecondsRealtime(1);
        går = true;
    }

    IEnumerator IFrame()
    {
        IFrames = true;
        yield return new WaitForSecondsRealtime(0.5f);
        IFrames = false;
    }

    void Start()
    {
        går = true;
    }

    void Update()
    {
        //död D:
        if (NuHälsa < 1)
        {
            Destroy(fiende1);
            Destroy(fiende2);
        }

        //går
        kropp.AddForce(gåx * 2, 0, gåz * 2);

        if (går == true)
        {
            StartCoroutine(Gå());
        }
        if (gåy == 1 && HoppCooldown == false)
        {
            kropp.AddForce(0, 2, 0);
            StartCoroutine(Hopp());
        }
        else if (gåy != 1)
        {
            kropp.AddForce(0, 0, 0);
        }

    }

}
