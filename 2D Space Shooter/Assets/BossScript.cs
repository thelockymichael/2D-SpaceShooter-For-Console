using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;

    public GameObject shot;
    public Transform[] shotSpawn;

    public GameObject bossExplosion;

    public float fireRate;
    public float delay;

    private GameController gameController;
    private PlayerController playerController;

    private AudioSource audioSource;

    private bool isDead = false;

    void Start()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
         gameController = gameControllerObject.GetComponent<GameController>();

        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        playerController = playerControllerObject.GetComponent<PlayerController>();

        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);

        currentHealth = startingHealth;
    }

    void Fire()
    {
        foreach (var shotSpawn in shotSpawn)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        audioSource.Play();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void continueGame()
    {
        isDead = false;
        gameController.StartCoroutine("SpawnWaves");
        Debug.Log("Start spawning enemies again");
    }

    void Death()
    {
        isDead = true;
        Debug.Log("Boss is dead");
        StartCoroutine(delayContinueGame());
        // Set the death flag so this function won't be called again.
       // gameController.Boss = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.TakeDamage(200);

        }
    }

    IEnumerator delayContinueGame()
    {
        yield return new WaitForSeconds(0.75f);
        Instantiate(bossExplosion, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            Debug.Log("Continue game");
            continueGame();
        }

       
    }
}
