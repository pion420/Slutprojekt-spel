using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vapen : MonoBehaviour
{
    public GameObject sv�rd;
    public bool CoolDown = false;
    public bool RoteraBort = false;
    public bool RoteraHem = false;
    public float snabb = 0;
    public bool H�llISv�rd = true;    
    public MeshRenderer Sv�rdet;



    IEnumerator attack()
    {
        RoteraBort = true;
        CoolDown = true;
        sv�rd.tag = "vapen";
        yield return new WaitForSecondsRealtime(0.2f);
        RoteraBort = false;
        RoteraHem = true;
        yield return new WaitForSecondsRealtime(0.2f);
        RoteraHem = false;
        sv�rd.tag = "v�nster";
        CoolDown = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        sv�rd.tag = "v�nster";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && CoolDown == false && H�llISv�rd == true)
        {
            
            StartCoroutine(attack());
            
        }
        if (RoteraHem == true)
        {
            sv�rd.transform.Rotate(new Vector3(0, 0, -1 * snabb) * Time.deltaTime);
        }
        if (RoteraBort == true)
        {
            sv�rd.transform.Rotate(new Vector3(0, 0, snabb) * Time.deltaTime);
            
        }

        if (Input.GetKey("1"))
        {
            H�llISv�rd = true;
            Sv�rdet.enabled = true;
        }
        if (Input.GetKey("2"))
        {
            H�llISv�rd = false;
            Sv�rdet.enabled = false;
        }
    }
}
