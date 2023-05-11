using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hälsa : MonoBehaviour
{
    public float MaxHälsa = 100;
    public float NuHälsa;
    public TextMeshProUGUI HälsaText;
    public Image HälsaBild;
    public float MaxMat = 100;
    public float NuMat;
    public TextMeshProUGUI MAtText;
    public Image MatBild;
    public bool ÄrDöd;
    public bool Heal = false;
    public float FörrHälsa;
    public bool TogSkada = false;
    public bool healing = false;
    public bool IFrames = false;
    public MeshRenderer Maten;
    public bool HållIMat = false;


    IEnumerator IFrame()
    {
        IFrames = true;
        yield return new WaitForSecondsRealtime(0.5f);
        IFrames = false;

    }
    IEnumerator OntVänta()
    {
        TogSkada = false;
        yield return new WaitForSecondsRealtime(2);
        if (TogSkada == false)
        {
            healing = true;
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Skada") && IFrames == false)
        {
            if (IFrames == false)
            {
                NuHälsa = NuHälsa - 10;
                TogSkada = true;
            }
            StartCoroutine(IFrame());
        }
    }

    void Start()
    {
        NuHälsa = MaxHälsa;
        NuMat = MaxMat;
        ÄrDöd = false;
        FörrHälsa = NuHälsa;
        IFrames = false;
    }

    
    void Update()
    {
        //healthbar och sådant
        NuHälsa = Mathf.Round(NuHälsa);
        HälsaText.text = NuHälsa.ToString();
        HälsaBild.fillAmount = NuHälsa / MaxHälsa;
        if (NuHälsa > MaxHälsa)
        {
            NuHälsa = MaxHälsa;
        }
        if (NuHälsa < 0)
        {
            NuHälsa = 0;
        }

        //mat jag er hungerig
        NuMat = Mathf.Round(NuMat);
        MAtText.text = NuMat.ToString();
        MatBild.fillAmount = NuMat / MaxMat;
        if (NuMat> MaxMat)
        {
            NuMat = MaxMat;
        }
        if (NuMat < 0.1)
        {
            NuMat = 0;
        }

        if (Input.GetKey("1"))
        {
            HållIMat = false;
            Maten.enabled = false;

        }
        if (Input.GetKey("2"))
        {
            HållIMat = true;
            Maten.enabled = true;
        }

        if (Input.GetMouseButtonDown(0) && HållIMat == true)
            {

            }



            //healing och sådant
            if (NuHälsa < MaxHälsa)
        {
            //TogSkada = true;
        }
        if (TogSkada == true)
        {
            StartCoroutine(OntVänta());
        }
        if (healing == true && NuHälsa < MaxHälsa && NuMat > 0 && IFrames == false)
        {
            NuMat = NuMat -= 120 * Time.deltaTime;
            NuHälsa = NuHälsa += 120 * Time.deltaTime;
        }
        if (NuHälsa >= MaxHälsa)
        {
            healing = false;
        }


        //död :(
        if (NuHälsa <= 0)
        {
            ÄrDöd = true;
        }
        if (ÄrDöd == true)
        {
            SceneManager.LoadScene("Scen");
        }
        if (transform.position.y < -10)
        {
            ÄrDöd = true;
        }
    }
}
