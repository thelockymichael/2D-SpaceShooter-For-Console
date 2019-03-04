using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    //Health
    public int healthBonus = 20;

    public GameObject explosion;
    public GameObject explosionForDestroyAllPowerUp;

    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    private PauseMenuManager PauseMenuManager;
    private PlayerController playerController;
    private DestroyByBoundary boundaryController;

    public bool isPowerUpHealth;
    public bool isFirePower;
    public bool isDestroyAll;

    public bool explode = false;

    public int attackDamage = 10;               // The amount of health taken away per attack.

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        GameObject PauseMenuManagerObject = GameObject.FindWithTag("MainMenuManager");
        PauseMenuManager = PauseMenuManagerObject.GetComponent<PauseMenuManager>();

        GameObject PlayerMovementObject = GameObject.FindWithTag("Player");
        playerController = PlayerMovementObject.GetComponent<PlayerController>();

        GameObject BoundaryObject = GameObject.FindWithTag("Boundary");
        boundaryController = BoundaryObject.GetComponent<DestroyByBoundary>();

        /*if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }*/
    }

    public void enemiesExplode()
    {
        Instantiate(this.explosionForDestroyAllPowerUp, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.CompareTag ("Asteroid") || other.CompareTag("EnemyBoss") || other.CompareTag("EnemyShip") || other.CompareTag("Enemy") || other.CompareTag("Rocket"))
        {
            return;
        }

        if(explosion != null || explode)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player" && isPowerUpHealth)
        {
            playerController.GainHealth(healthBonus);
            Destroy(this.gameObject);
            /*
            gameController.GameOver();
            PauseMenuManager.GameOver();
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);*/
        }

        if (other.tag == "Player" && isFirePower)
        {
            playerController.GainFirePower();
            Destroy(this.gameObject);
            /*
            gameController.GameOver();
            PauseMenuManager.GameOver();
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);*/
        }

        if (other.tag == "Player" && isDestroyAll)
        {
            boundaryController.destroyAll = true;
            //Destroy(this.gameObject);
            /*
            gameController.GameOver();
            PauseMenuManager.GameOver();
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);*/
        }

        if (other.tag == "Player")
        {
            playerController.TakeDamage(attackDamage);
            Destroy(this.gameObject);
            /*
            gameController.GameOver();
            PauseMenuManager.GameOver();
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);*/
        }

     
        else
        {
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
       
    }
}