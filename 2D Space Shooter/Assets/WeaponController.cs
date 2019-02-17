using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

    public GameObject shot;
    public Transform[] shotSpawn;
    public float fireRate;
    public float delay;
    
    private AudioSource audioSource;

    void Start()
    {
        //audio = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        foreach (var shotSpawn in shotSpawn)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        audioSource.Play();
    }
}