using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivador : MonoBehaviour
{
    [Header("To  Deactivate")]
    [Tooltip("todo lo que necesito desactivar")]
    public GameObject _negativeTimer;
    //public BigDoorScript _scriptBigDoor;
    public GameObject _sireneDesact;
    public GameObject _SFXFosaDesact;


    [Header("Explosion")]
    [Tooltip("La explosion ultima")]
    public ParticleSystem explosion;
    public AudioSource sfxExpl;
    //public CameraShake camerashake;

    [Header("Fire System")]
    [Tooltip("Fire + Lava")]
    public GameObject Lava;

    public ParticleSystem[] fire;
    public AudioSource[] sfxfire;


    int fireIndex = 0;
    int sfxfireIndex = 0;

    public bool _fireOn = false;


    private void Start()
    {        
        Lava.SetActive(false);
    }

   
    private void LateUpdate()
    {
        if (_fireOn == true)
        {
            Fire();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _negativeTimer.SetActive(false);
            //_scriptBigDoor._negativeTimer.SetActive(false);

            StartCoroutine(TimerExplosions());
           
            Lava.SetActive(true);
            GetComponent<Collider>().enabled = false;
            
        }
    }

    IEnumerator TimerExplosions()
    {
        ExplosionPlay();
        yield return new WaitForSeconds(0.2f);
        _fireOn = true;
    }

    public void ExplosionPlay()
    {
      //StartCoroutine(camerashake.Shake());

      explosion.Play();
      sfxExpl.Play();
      _sireneDesact.SetActive(false);
      _SFXFosaDesact.SetActive(false);

    }

    

    void Fire()
    {
        

        if (fireIndex < fire.Length) fire[fireIndex].Play();
        if (sfxfireIndex < sfxfire.Length) sfxfire[sfxfireIndex].Play();
        

        StartCoroutine(FireTimer());

        fireIndex++;
        sfxfireIndex++;

    
    }

    private IEnumerator FireTimer()
    {

        _fireOn = false;

        yield return new WaitForSeconds(0.3f);

        _fireOn = true;

       

    }

}
