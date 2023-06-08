using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundMappingData
{
    public string tagName;
    // public AudioClip sound;
    public string sound;
}

// [System.Serializable]
// public class SoundMappingData {
//     public SoundMappingData[] sounds;
// }

public class CollisionSoundManager : MonoBehaviour
{
    public AudioClip defaultSound; // Default sound to play if tag name is not found
    public TextAsset soundConfigFile; // JSON file containing tag-sound mappings

    private Dictionary<string, AudioClip> soundMappings; // Dictionary to store tag-sound mappings

    void Start()
    {
        Debug.Log("In start");
        // Load and parse the JSON file
        LoadSoundMappings();
    }

    public void LoadSoundMappings()
    {
        TextAsset Dialog_Data;

        soundMappings = new Dictionary<string, AudioClip>();

        SoundMappingData[] mappingData = new SoundMappingData[3];
        // Dialog_Data = Resources.Load<TextAsset>("txt/soundConfigFile");
        Dialog_Data = soundConfigFile;
        // SoundMappingData[] mappingData = JsonUtility.FromJson<SoundMappingData[]>(Dialog_Data.text);
        mappingData = JsonUtility.FromJson<SoundMappingData[]>(Dialog_Data.text);

        // SoundMappingData[] mappingData = JsonUtility.FromJson<SoundMappingData>("{\"users\":" + soundConfigFile.text + "}");
        foreach (SoundMappingData data in mappingData)
        {
            // Load the audio clip from the provided path
            AudioClip audioClip = Resources.Load<AudioClip>(data.sound);

            if (audioClip != null)
            {
                soundMappings[data.tagName] = audioClip;
            }
            else
            {
                Debug.LogWarning("Failed to load audio clip: " + data.sound);
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("In ontrigger");
        // Get the tag name of the collided object
        SphereCollider sphereCollider = other.GetComponent<SphereCollider>();

        if (sphereCollider != null)
        {
            string tagName = other.tag;
            Debug.Log(tagName);


            int mappingsCount = soundMappings.Count;
            Debug.Log("Sound Mappings Count: " + mappingsCount);


            foreach (var entry in soundMappings)
            {
                Debug.Log("Entered here");
                Debug.Log("Key: " + entry.Key + ", Value: " + entry.Value);
            }

            // Check if a sound is mapped to the tag name
            if (soundMappings.ContainsKey(tagName))
            {
                Debug.Log("True but no audio!!");
                // Play the sound mapped to the tag name
                AudioClip sound = soundMappings[tagName];
                AudioSource.PlayClipAtPoint(sound, transform.position);
            }
            else
            {
                Debug.Log("Default");
                // Play the default sound
                AudioSource.PlayClipAtPoint(defaultSound, transform.position);
            }
        }
    }
}

