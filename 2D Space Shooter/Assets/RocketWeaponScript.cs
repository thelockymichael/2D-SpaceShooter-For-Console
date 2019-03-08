﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeaponScript : MonoBehaviour
{
    private BossScript bossScript;
    private GameController gameController;
    private PlayerController playerController;

    public GameObject explosion;

    public GameObject rocketExplosion;

    public Collider explosionTrigger;


    int damage = 200;

    private bool timeOut;
    private float timer;
    private float innerTimer;

    public float timeLimit;

    private int objects;

    void Update()
    {

    }
    
    
    IEnumerator delayDestruction()
    {
        yield return new WaitForSeconds(0.8f);
        explosionTrigger.enabled = true;
   
        Instantiate(explosion, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);

    }



    // Start is called before the first frame update
    void Start()
    {
        objects = 0;
       StartCoroutine(delayDestruction());

        //timeOut = false;
        // timer = 0f;
        // innerTimer = timeLimit;

        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        playerController = playerControllerObject.GetComponent<PlayerController>();

        GameObject bossScriptObject = GameObject.FindWithTag("EnemyBoss");
        bossScript = bossScriptObject.GetComponent<BossScript>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {


        Collider[] hits = Physics.OverlapSphere(transform.position, 7);

        int i = 0;

        //int i = hits.Length;
        //gameController.AddScore(i * 20);

        foreach (Collider hit in hits)
        {
            if (hit.tag == "Enemy" || hit.tag == "EnemyShip" || hit.tag == "Asteroid")
            {
           
                Debug.Log(i);
                i++;

                Destroy(hit.gameObject);
            }

        }
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        gameController.AddScore(i * 20);
        /*if (other.tag == "EnemyShip" || other.tag == "Enemy" || other.tag == "Asteroid")
        {
           // Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            objects++;
            Debug.Log("Objects:" + objects);

            //gameController.AddScore(objects * 20);
            //StartCoroutine(giveScore());
        }*/

        if (other.tag == "EnemyBoss")
        {
            Debug.Log("Boss took damage");
            bossScript.TakeDamage(damage);
            Destroy(this.gameObject);
           // Instantiate(explosion, transform.position, transform.rotation);

        }
    }
}
