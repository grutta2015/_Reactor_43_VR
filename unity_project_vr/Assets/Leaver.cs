using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaver : MonoBehaviour
{
    public Brucke _brucke; 
    public GameObject leaverOn;
    public GameObject leaverOff;
    public AudioSource _sfxOn;
    public AudioSource _sfxClose;

    public bool switchOn;

    private void Start()
    {
        leaverOn.SetActive(switchOn);
        leaverOff.SetActive(!switchOn);
    }

    public void onOff()
    {
        switchOn = !switchOn;

        leaverOn.SetActive(switchOn);
        leaverOff.SetActive(!switchOn);

        if (switchOn == true)
        {
            _brucke.OpenBrucke();
            _sfxOn.Play();
        }
        if (switchOn == false)
        {
            _brucke.ClosedBrucke();
            _sfxClose.Play();
        }
    }
    
}
