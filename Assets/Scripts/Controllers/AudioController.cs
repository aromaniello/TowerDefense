using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioBox _audioBox;
    [SerializeField] private AudioSource[] _audioChannels;

    private void Start()
    {
        PlayAudio("GameMusic");
    }

    public void PlayAudio(string audioName)
    {
        for (int i = 0; i < _audioChannels.Length; i++)
        {
            if (_audioChannels[i].clip == null)
            {
                for (int j = 0; j < _audioBox.Audios.Length; j++)
                {
                    if (_audioBox.Audios[j].AudioName == audioName)
                    {
                        _audioChannels[i].clip = _audioBox.Audios[j].AudioClip[0];
                        _audioChannels[i].volume = _audioBox.Audios[j].Volume;
                        _audioChannels[i].pitch = _audioBox.Audios[j].Pitch;
                        _audioChannels[i].loop = _audioBox.Audios[j].Loop;
                        _audioChannels[i].PlayDelayed(_audioBox.Audios[j].StartDelay);
                    }
                }
                break;
            }
        }
    }


}
