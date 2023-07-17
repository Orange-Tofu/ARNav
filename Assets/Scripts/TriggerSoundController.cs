// No longer used
// This script was used for an initial method in which the script would be attached to the direction collider object
// and then when collision occurs this would call the MyEvent function in SetNavigationTarget script which is attached
// Indicator object.

// The new method uses a different script attached directly to the indicator. This is kept for future reference.


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TriggerSoundController : MonoBehaviour
// {
//     public GameObject audioFilesObject; // Reference to the GameObject storing the audio files
//     private AudioSource audioSource;

//     public delegate void MyEventHandler();
//     public event MyEventHandler MyEvent;

//     public string tagName;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         // DebugLog("Workeas!!");
//         audioSource = GetComponent<AudioSource>();
//         if (audioSource == null)
//         {
//             // If AudioSource component is not present, add it to objB
//             audioSource = gameObject.AddComponent<AudioSource>();
//         }
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         // SphereCollider sphereCollider = other.GetComponent<SphereCollider>();
//         Debug.Log("1");
//         if (other.CompareTag("Mover"))
//         {
//             Debug.Log("2");
//             tagName = other.tag;
//             MyEvent?.Invoke();

//         }
//     }

//     public void playAudio(string value)
//     {
//         string vTag = value;
//         // DebugLog(vTag);
//         AudioClip audioClip = audioFilesObject.GetComponent<AudioFilesManager>().GetAudioClipForTag(vTag);

//         if (audioClip != null)
//         {
//             // Play the audio clip
//             audioSource.PlayOneShot(audioClip);
//         }
//     }

//     public void DebugLog(string message)
//     {
//         Debug.Log(message);
//         LogViewer logViewer = FindObjectOfType<LogViewer>();
//         if (logViewer != null)
//         {
//             logViewer.HandleLogMessage(message, string.Empty, LogType.Log);
//         }
//     }

// }
