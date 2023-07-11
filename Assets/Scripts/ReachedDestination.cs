// Script to check if the indicator cube collides with target objects or not and if yes then play the 
// reached destination audio clip.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedDestination : MonoBehaviour
{
    public AudioClip destination_Sound;
    private AudioSource audioSource;
    
    private void Start()
    {
        // Add an AudioSource component to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = destination_Sound;
    }

    // Function to check for collision and play the appropriate audio if condition satisfied.
    void OnTriggerEnter(Collider other)
    {
        // Only trigger if the object it collided with is the target object denoted by its tag name.
        if (other.CompareTag("Targets"))
        {
            // Play the audio clip
            audioSource.Play();
        }
    }
}
