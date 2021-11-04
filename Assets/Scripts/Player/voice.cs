using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="FPS/FootStep_Audio data")]


public class voice : ScriptableObject
{
    public List<Footstep_Audio> footstep_Audios = new List<Footstep_Audio>();

    // Start is called before the first frame update
    void Start()
    {
        
    }
}

[System.Serializable]
public class Footstep_Audio
{
    public string tag;
    public List<AudioClip> AudioClips = new List<AudioClip>();
    public float Delay;
}

