using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickleController : MonoBehaviour {
    SpriteRenderer rend;
    public AudioClip pickUp;
    private AudioSource source;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        int num = Random.Range(0, 2);
        rend.flipX = (num == 0) ? true : false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("PickUp", 0.5f);
        source.PlayOneShot(pickUp,1F);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Invoke("PickUp", 0.5f);
    }

    void PickUp()
    {
        PlayerController.player.heldPickles++;
        Destroy(gameObject);
    }
}
