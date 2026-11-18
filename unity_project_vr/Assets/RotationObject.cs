using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    [SerializeField] protected GameObject _visual;
    [SerializeField] protected float velocityRotationVisual = 10;
    [SerializeField] protected float angleRotationVisual = 20f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _visual.transform.Rotate(angleRotationVisual * Vector3.up * velocityRotationVisual * Time.deltaTime, Space.World);
    }
}
