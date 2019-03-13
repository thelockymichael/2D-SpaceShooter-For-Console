using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PowerUpHealth : MonoBehaviour
{
    private PlayerController playerController;



    public int healthBonus = 20;
    private Rigidbody rb;

 

    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerMovementObject = GameObject.FindWithTag("Player");
        playerController = PlayerMovementObject.GetComponent<PlayerController>();

        rb = GetComponent<Rigidbody>();

    }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {

        playerController.GainHealth(healthBonus);
        Destroy(this.gameObject);
    }
}*/

/*
IEnumerator Evade()
{
    yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

    while (true)
    {
        targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
       // targetManeuver = playerTransform.position.x;
        yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
      //  targetManeuver = 0;
        yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
    }
}

void FixedUpdate()
{
    float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
    rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
    rb.position = new Vector3
    (
        Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
        0.0f,
        Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
    );

    rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
}
}*/