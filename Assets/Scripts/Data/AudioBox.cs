using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AudioBox", menuName = "ScriptableObjects/CreateAudioBox")]
public class AudioBox : ScriptableObject
{
    [Serializable]
    public struct AudioParameters
    {
        public string AudioName;
        public AudioClip[] AudioClip;
        public float Volume;
        public float Pitch;
        public bool Loop;
        public float StartDelay;
    }

    public AudioParameters[] Audios;
}
