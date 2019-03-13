using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoltScript : MonoBehaviour
{
    private BossScript bossScript;
    private GameController gameController;
    private PlayerController playerController;

    public GameObject explosion;


    int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        playerController = playerControllerObject.GetComponent<PlayerController>();

        GameObject bossScriptObject = GameObject.FindWithTag("EnemyBoss");
        bossScript = bossScriptObject.GetComponent<BossScript>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

    }


    void OnTriggerEnter (Collider other)
    {

        if (other.tag == "EnemyShip")
        {
            playerController.enemyCounter();

        }

        if (other.tag == "EnemyBoss")
        {
            Debug.Log("Boss took damage");
            bossScript.TakeDamage(damage);
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);

        }
    }
}
