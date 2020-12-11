using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;

    [SerializeField] Text healthText;

    [SerializeField] AudioClip playerDamageSFX;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        health--;
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        healthText.text = health.ToString();
    }
}
