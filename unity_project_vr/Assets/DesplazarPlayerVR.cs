using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazarPlayerVR : MonoBehaviour
{
    public GameObject vrPlayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Attach")
        {
            vrPlayer.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Attach")
        {
            vrPlayer.transform.parent = null;
        }
        
    }
}
