using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HurricaneVR.Framework.Core.Player;


public class PlutonicReactor : ActionScript
{
    public AudioSource sfxPlutonic;
    public AudioSource confirm;
    public AudioSource negative;
    public GameObject _youWin;

    [SerializeField] private HVRTeleporter _vrController;

    [SerializeField] protected string _collectableDescription = "Debes cambiar la Bateria Plutonica por una nueva.\n Enceuntrala en el 3er piso";
    
    [SerializeField] protected TMP_Text _descriptionText;
   
    [SerializeField] protected Transform _textContainer;

    // public PlayerController_Simple _playerSimpleDeactItemHand;

    public GameObject _batteryNew;
    public GameObject _batteryOld;


    public string Description
    {
        get { return _collectableDescription; }
    }

    public void Start()
    {
        _descriptionText.text = _collectableDescription;
        _textContainer.gameObject.SetActive(false);
        _batteryNew.SetActive(false);
        _batteryOld.SetActive(true);
    }

    protected virtual void FixedUpdate()
    {
        // text always look to camera
        if (_textContainer.gameObject.activeSelf) _textContainer.LookAt(Camera.main.transform.position);        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isUnlocked)
            {

                sfxPlutonic.Play();
                confirm.Play();
                //other.GetComponent<PlayerController_Simple>().DeactivateItemOnHand();
                // if (_playerSimpleDeactItemHand != null) _playerSimpleDeactItemHand.DeactivateItemOnHand();
                _batteryNew.SetActive(true);
                _batteryOld.SetActive(false);
                _vrController.DoDie();
                _youWin.SetActive(true);

            }
            else
            {
                negative.Play();
                _textContainer.gameObject.SetActive(true);
            }
        }
                  

    }

    private void OnTriggerExit(Collider other)
    {
        _textContainer.gameObject.SetActive(false);
    }


}
