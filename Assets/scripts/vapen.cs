using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vapen : MonoBehaviour
{
    public GameObject svärd;
    public bool CoolDown = false;
    public bool RoteraBort = false;
    public bool RoteraHem = false;
    public float snabb = 0;
    public bool HållISvärd = true;    
    public MeshRenderer Svärdet;



    IEnumerator attack()
    {
        RoteraBort = true;
        CoolDown = true;
        svärd.tag = "vapen";
        yield return new WaitForSecondsRealtime(0.2f);
        RoteraBort = false;
        RoteraHem = true;
        yield return new WaitForSecondsRealtime(0.2f);
        RoteraHem = false;
        svärd.tag = "vänster";
        CoolDown = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        svärd.tag = "vänster";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && CoolDown == false && HållISvärd == true)
        {
            
            StartCoroutine(attack());
            
        }
        if (RoteraHem == true)
        {
            svärd.transform.Rotate(new Vector3(0, 0, -1 * snabb) * Time.deltaTime);
        }
        if (RoteraBort == true)
        {
            svärd.transform.Rotate(new Vector3(0, 0, snabb) * Time.deltaTime);
            
        }

        if (Input.GetKey("1"))
        {
            HållISvärd = true;
            Svärdet.enabled = true;
        }
        if (Input.GetKey("2"))
        {
            HållISvärd = false;
            Svärdet.enabled = false;
        }
    }
}
