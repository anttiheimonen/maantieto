using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip buttonClick;
    public AudioClip rightAnswer;
    public AudioClip wrongAnswer;
    public AudioClip changeCamera;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
}
