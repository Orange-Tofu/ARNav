using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class AudioClipData
{
    public string condition;
    public AudioClip audioSource;
}


public class AudioFile : MonoBehaviour
{
    public TextAsset audioDataJson;
    private List<AudioClipData> audioClipDataList;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClipDataList = JsonUtility.FromJson<RootObject>(audioDataJson.text).audioClips.ToList();
    }

    private void Update()
    {
        // Check conditions and play corresponding audio clip
        foreach (AudioClipData clipData in audioClipDataList)
        {
            if (2==3)
            {
                PlayAudioClip(clipData.audioSource);
                break;
            }
        }
    }

    private void PlayAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}

[System.Serializable]
public class RootObject
{
    public AudioClipData[] audioClips;
}

