using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_AudioSource;

    public void PlayAudio(AudioClip clip)
    {
        m_AudioSource.PlayOneShot(clip);
    }
}
