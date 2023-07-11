// This Script manages thr audio files by collecting them in one place and then returns appropriate audio files
// back to calling function. This helps maintain and easily switch in-out a audio file without changing two much things.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioFilesManager : MonoBehaviour
{
    // These are the variable handler for the audio clips
    public AudioClip sound_Left; 
    public AudioClip sound_Right;
    public AudioClip sound_Forward;
    public AudioClip sound_Backward;
    public AudioClip sound_default; 

    // This function returns the audio clip based on the tag name
    public AudioClip GetAudioClipForTag(string tag)
    {
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
