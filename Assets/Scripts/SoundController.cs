using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public void PlayScreenChange()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(SoundManager.instance.changeCamera);
    }
}
