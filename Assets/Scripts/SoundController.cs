using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public void PlaySound(AudioClip sound)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound);
    }
}
