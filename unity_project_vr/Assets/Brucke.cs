using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brucke : MonoBehaviour
{
    public Transform _brucke;
    public Transform _openBrucke;
    public Transform _closedBrucke;

    public float Speed = 5f;
    Vector3 _targetBruckePosition;    
    float time;

    void Start()
    {
        _targetBruckePosition = _closedBrucke.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_brucke.position != _targetBruckePosition)
        {
            _brucke.transform.position = Vector3.Lerp(_brucke.transform.position, _targetBruckePosition, time);
            time = +Time.deltaTime * Speed;
           
        }
    }


    public void OpenBrucke()
    {
        _targetBruckePosition = _openBrucke.position;
    }

    public void ClosedBrucke()
    {
        _targetBruckePosition = _closedBrucke.position;
    }


}


