using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    public bool destroyAll = false;
    private DestroyByContact destroyByContactController;

    public GameObject explosion;
    private GameController gameController;

    // private GameObject destroyByContactObject;

    //GameObject[] objs;
    GameObject[] destroyByContactObject;

    public GameObject enemyPrefab;
    public GameObject[] enemies;

    public GameObject destroyAllExplosion;

    private void Update()
    {
        if (enemies == null)
        {
        }
    }

    void Explosion(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("AddDamage");
            i++;
        }
    }


public void explosions()
    {
        /* int vihu = 0;
         vihu++;
         int enemyAmount = vihu;
         Debug.Log(enemyAmount);*/
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");

        string[] tagsToDisable =
                {
                 "Enemy",
                 "Asteroid",
                 "EnemyShip"
             };
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // Debug.Log(enemies.Length);
        int i = tagsToDisable.Length;
        gameController.AddScore(i * 2);
        foreach (string tag in tagsToDisable)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
                                                //Increment loop
            foreach (GameObject gameObj in gameObjects)
            {
               // gameObj.GetComponent<DestroyByContact>().enemiesExplode();
               Destroy(gameObj);
            }
            //Debug.Log("EMEMIES = " + (i));
            if (i == 0)
            {
           //     Debug.Log("NO EMEMIES LEFT IN SCENE");
            }
            // enemy.GetComponent<DestroyByContact>().enemiesExplode();
            // Debug.Log("Make enemies explode!");
            //  Instantiate(explosion, enemy.transform.position, enemy.transform.rotation);
            //  Debug.Log("ENEMY FOUND");
        }
    }
 
             

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        destroyByContactObject = GameObject.FindGameObjectsWithTag("Enemy");

    }

    public void OnTriggerStay(Collider other)
    {   if ((other.tag == "Enemy" || other.tag == "EnemyShip" || other.tag == "Asteroid") && destroyAll)
        {

            explosions();
           // Destroy(other.gameObject);
            StartCoroutine(destroyAllDelay());
        }

        /*
        if ((other.tag == "Enemy" || other.tag == "EnemyShip" || other.tag == "Asteroid") && destroyAll)
        {

            explosions();
           // Destroy(other.gameObject);
            StartCoroutine(destroyAllDelay());
        }*/

        /*  if (destroyAll)
          {
              explosions();
              Debug.Log("Make enemies explode!");

          }*/
    }

    IEnumerator destroyAllDelay()
    {
        destroyAllExplosion.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        destroyAllExplosion.SetActive(false);

        destroyAll = false;
        // destroyAllDisable();
    }
    /*
    void destroyAllDisable()
    {
        //timeAgain = timeLimit;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        destroyAll = false;


        Debug.Log("Enemies stop destroying");
    }*/

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}