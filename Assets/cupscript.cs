using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cupscript : MonoBehaviour
{
    [SerializeField]
    private Text pickUpText;

    [SerializeField]
    private AudioClip pickUpSound;

    [SerializeField]
    private GameObject henryGameObject; // Reference to the Henry GameObject

    private AudioSource audioSource;

    private bool pickUpAllowed;
  

    // Use this for initialization
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        // Ensure the AudioSource component is enabled
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.enabled = true;
        }

        Debug.Log("AudioSource initialized: " + (audioSource != null));
    }

    // Update is called once per frame
    private void Update()
    {

        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
            PlayPickUpSound();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("henry"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("henry"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        PlayPickUpSound();

        // Delay the destruction of the game object by the length of the audio clip
        float delay = pickUpSound != null ? pickUpSound.length : 0f;
        Invoke("DestroyObject", delay);
        Invoke("NotifyHenry", delay);
    
}

    private void DestroyObject()
    {
        // Find and destroy the "wall4" GameObject
        GameObject wall4 = GameObject.Find("wall4");
        if (wall4 != null)
        {
            Destroy(wall4);
        }

        // Destroy the "cup" GameObject
        Destroy(gameObject);
    }


    private void PlayPickUpSound()
    {
        if (pickUpSound != null && audioSource != null && audioSource.enabled)
        {
            Debug.Log("Audio Source is enabled");

            if (audioSource == null)
            {
                Debug.Log("Audio Source is null");
            }

            audioSource.PlayOneShot(pickUpSound);
        }
    }

    private void NotifyHenry()
    { // Check if henryGameObject has the necessary script
       
        PlayerMovement henryController = henryGameObject.GetComponent<PlayerMovement>();

        if (henryController != null)
        {
            // Call a method in the HenryAnimationController script to change animations
            henryController.ChangeAnimations(true);
        }
    }
}

