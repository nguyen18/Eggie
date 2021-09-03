using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip hoverFX;
    public AudioClip clickFX;

    public void HoverSound()
    {
        audio.PlayOneShot(hoverFX);
    }

    public void ClickSound()
    {
        audio.PlayOneShot(clickFX);
    }
}
