using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RedNebulaScript : MonoBehaviour
{

    public float lifetime = 3f;

    public Image damageImage;

    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    void Start()
    {
        GameObject damageImageController = GameObject.FindWithTag("DamageImage");
        damageImage = damageImageController.GetComponent<Image>();

        Destroy(gameObject, lifetime);
        StartCoroutine(flash());
    }

    IEnumerator flash()
    {
        while(true)
        {
            damageImage.color = flashColour;
            yield return new WaitForSeconds(0.2f);
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.2f);
        }

    }
}