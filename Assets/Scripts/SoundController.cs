using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public GameObject audioFilesObject; 
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is not present, add it to objB
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void playAudio(string value)
    {
        string vTag = value;
        // DebugLog(vTag);
        AudioClip audioClip = audioFilesObject.GetComponent<AudioFilesManager>().GetAudioClipForTag(vTag);

        if (audioClip != null)
        {
            // Play the audio clip
            audioSource.PlayOneShot(audioClip);
        }
    }
}
