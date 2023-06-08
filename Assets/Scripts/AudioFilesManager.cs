using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioFilesManager : MonoBehaviour
{
    public AudioClip sound_Left; // Sound for tag T1
    public AudioClip sound_Right;
    public AudioClip sound_Destination;
    public AudioClip sound_default; // Sound for tag T2
    // Add more AudioClip variables for additional tags

    public AudioClip GetAudioClipForTag(string tag)
    {
        // Return the appropriate audio clip based on the tag
        // DebugLog(tag);
        switch (tag)
        {
            case "Left":
                return sound_Left;
            case "Right":
                return sound_Right;
            case "Destination":
                return sound_Destination;
            default:
                return sound_default;
            // Add more cases for additional tags and corresponding sounds
        }

        // If no audio clip found for the tag, return null
        return null;
    }

    public void DebugLog(string message)
    {
        Debug.Log(message);
        LogViewer logViewer = FindObjectOfType<LogViewer>();
        if (logViewer != null)
        {
            logViewer.HandleLogMessage(message, string.Empty, LogType.Log);
        }
    }

}
