using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int healthPoints = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamagedSFX;

    private void Start()
    {
        healthText.text = healthPoints.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        healthPoints -= healthDecrease;
        healthText.text = healthPoints.ToString();
        GetComponent<AudioSource>().PlayOneShot(playerDamagedSFX);
    }
}
