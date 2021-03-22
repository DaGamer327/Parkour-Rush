using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 4.0f;
    //Optional audioclip that plays when picked up//
    public AudioClip powerClip;
    //Optional particaleffect that plays once when picked up, must be created in unity//
    public GameObject pickupEffect;

    public PlayerController Player;


    public bool isFast = false;

    void Start()
    {
        Player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //rename this to whatever the player's tag is//
        if (other.tag == "Player")
        {
            Fast();
        }
    }

    IEnumerator Pickup()
    {
        isFast = true;

        Player.speed *= 2;

        Instantiate(pickupEffect, transform.position, transform.rotation);

        for (float i = 0; i < duration; i -= duration)
        {

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;

            yield return new WaitForSeconds(duration);
        }

        Player.speed /= 2;

        isFast = false;

        Destroy(this);
    }

    public void Fast()
    {
        if (isFast)
        {

            return;
        }

        if (!isFast)
        {
            StartCoroutine(Pickup());

        }
    }
}
