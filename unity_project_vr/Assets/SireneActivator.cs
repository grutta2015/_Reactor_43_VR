using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SireneActivator : MonoBehaviour
{
    public GameObject SireneOn;
    public GameObject Lava;
    
    public ParticleSystem[] fire;
    public AudioSource[] sfxfire;
    

    int fireIndex = 0;
    int sfxfireIndex = 0;

    bool sireneIsOn = false;


    private void LateUpdate()
    {
        if (sireneIsOn == true)
        {
            Sirene();
            print("Sirene en void Start");
        }


    }

    private void Start()
    {
        SireneOn.SetActive(false);
        Lava.SetActive(false); 
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SireneOn.SetActive(true);
            Lava.SetActive(true); 
           
            sireneIsOn = true;

        }
    }

    void Sirene()
    {
        if (fireIndex < fire.Length) fire[fireIndex].Play();
        if (sfxfireIndex < sfxfire.Length) sfxfire[sfxfireIndex].Play();

        StartCoroutine(SireneTimer());
        print("Sirene en void Sirene");
        fireIndex++;
        sfxfireIndex++;
    }

    IEnumerator SireneTimer()
    {
        print("Sirene en void Corutine");
        sireneIsOn = false;

        yield return new WaitForSeconds(1f);

        sireneIsOn = true;

    }

}
