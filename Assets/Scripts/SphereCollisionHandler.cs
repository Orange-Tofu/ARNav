using UnityEngine;

public class SphereCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject audioManager;

    private void HandleContact()
    {
        // Do something when the spheres come into contact
        Debug.Log("Spheres are in contact!");
        PlayAudioInstruction();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider belongs to sphere A
        if (other.CompareTag("IndicatorSphere"))
        {
            // Invoke the HandleContact function
            Debug.Log("Invoked without contact!");
            HandleContact();
        }
        // HandleContact();
    }

    private void PlayAudioInstruction()
    {
        Debug.Log("Inside Playaudio");
        // Get the AudioSource component from the audioManager GameObject
        AudioSource audioSource = audioManager.GetComponent<AudioSource>();

        // Stop any currently playing audio
        audioSource.Stop();

        // Play the audio clip
        audioSource.Play();
    }

}
