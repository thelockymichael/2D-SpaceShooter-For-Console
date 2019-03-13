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
    public bool isFlameThrower;
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

    public void OnTriggerEnter(Collider other)
    {
        // Jos pelikentän sisällä on asteroideja, vihollisia, 'bosseja', Power Uppeja eli Enemy tai raketteja, älä tee MITÄÄN!!!
        if (other.tag == "Boundary" || other.CompareTag ("Asteroid") || other.CompareTag("EnemyBoss") || other.CompareTag("EnemyShip") || other.CompareTag("Enemy") || other.CompareTag("Rocket"))
        {
            return;
        }

        // Jos räjähdysefekti on olemassa tai on Pelaaja, luo räjähdys
        if(explosion != null || other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }


        // Jos tässä GameObjectin DestroyByContact-scriptissä on isPowerUpHealth bool-totuusarvo päällä ja pelaaja koskee tähän, niin pelaaja saa 20 elämäpistettä.
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

        // Jos tässä GameObjectin DestroyByContact-scriptissä on isFirePower bool-totuusarvo päällä ja pelaaja koskee tähän, niin pelaaja viideks sekunniks lisätulipäivityksen.
        if (other.tag == "Player" && isFirePower)
        {
            if (playerController.FlameThrowerIsActive)
            {
                playerController.FlameThrowerIsActive = true;
                playerController.GainFirePower();
                Destroy(this.gameObject);
            }
            else
            {
                playerController.GainFirePower();
                Destroy(this.gameObject);
                // Do nothing
            }
            playerController.GainFirePower();
            Destroy(this.gameObject);
            /*
            gameController.GameOver();
            PauseMenuManager.GameOver();
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);*/
        }

        // Jos tässä GameObjectin DestroyByContact-scriptissä on isFlameThrower bool-totuusarvo päällä ja pelaaja koskee tähän, niin pelaaja viideks sekunniks liekinheitinpäivityksen.

        if (other.tag == "Player" && isFlameThrower)
        {
            if (playerController.FirePowerIsActive)
            {
                playerController.FirePowerIsActive = false;
                playerController.GainFlameThrower();
                Destroy(this.gameObject);
            }
            else
            {
                playerController.GainFlameThrower();
                Destroy(this.gameObject);
                // Do nothing
            }
            /*
            gameController.GameOver();
            PauseMenuManager.GameOver();
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);*/
        }

        // Jos tässä GameObjectin DestroyByContact-scriptissä on isDestroyAll bool-totuusarvo päällä ja pelaaja koskee tähän, kaikki asiat pelikentältä tuhoutuvat.
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
        
        // Jos vihollinen, asteroidi tai jokin vastaava osuu pelajaan, pelajaa ottaa vahkinkoa.
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

     
        // Muissa tapauksissa anna pisteitä ja tuhoa skeidaa.
        else
        {
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
       
    }
}