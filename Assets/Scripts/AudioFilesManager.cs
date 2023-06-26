using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioFilesManager : MonoBehaviour
{
    public AudioClip sound_Left; 
    public AudioClip sound_Right;
    public AudioClip sound_Forward;
    public AudioClip sound_Backward;
    public AudioClip sound_default; 

    public AudioClip GetAudioClipForTag(string tag)
    {
        // Return the appropriate audio clip based on the tag
        switch (tag)
        {
            case "Left":
                return sound_Left;
            case "Right":
                return sound_Right;
            case "Forward":
                return sound_Forward;
            case "Backward":
                return sound_Backward;
            default:
                return sound_default;
        
            // Return a ding sound effect to indicate something went wrong and can also be used for debugging
        }
    }

    // Uncomment this function only for visual debugging

    // public void DebugLog(string message)
    // {
    //     Debug.Log(message);
    //     LogViewer logViewer = FindObjectOfType<LogViewer>();
    //     if (logViewer != null)
    //     {
    //         logViewer.HandleLogMessage(message, string.Empty, LogType.Log);
    //     }
    // }

}
