using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBossScript : MonoBehaviour
{

    private PlayerController playerMovement;
   public int damage = 20;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerMovementObject = GameObject.FindWithTag("Player");
        playerMovement = playerMovementObject.GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Plyayer took damage");
            playerMovement.TakeDamage(damage);
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

// Update is called once per frame
void Update()
    {
        
    }
}
