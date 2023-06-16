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

    void OnTriggerEnter(Collider other)
    {
        
        // SphereCollider sphereCollider = other.GetComponent<SphereCollider>();

        if (other.CompareTag("Targets"))
        {
            // Play the audio clip
            audioSource.Play();
        }
    }
}
