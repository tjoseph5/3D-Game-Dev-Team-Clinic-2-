using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip voiceClip;
    private bool hasBeenPlayed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenPlayed)
        {
            other.gameObject.GetComponent<AudioSource>().Stop();
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(voiceClip, 1.0f);
            hasBeenPlayed = true;
        }
    }
}
