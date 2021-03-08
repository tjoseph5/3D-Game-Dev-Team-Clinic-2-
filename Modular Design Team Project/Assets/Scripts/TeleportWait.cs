using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWait : MonoBehaviour
{
    public GameObject player;
    public Transform teleportTo;
    public Animator fadeAnim;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        player.GetComponent<PlayerController>().speed = 0f;
        player.GetComponent<PlayerController>().jumpHeight = 0f;

        fadeAnim.SetTrigger("Next");
        yield return new WaitForSeconds(1f);
        TeleportPlayer();
        Debug.Log("I'm in Coroutine");
        yield return new WaitForSeconds(1f);
        Debug.Log(player.transform.position);
        player.GetComponent<PlayerController>().speed = 9f;
        player.GetComponent<PlayerController>().jumpHeight = 1.75f;
    }

    public void TeleportPlayer()
    {
        Debug.Log("WHY IS THIS NOT WORKING???");
        // Teleports the player to the designated location.
        player.transform.position = teleportTo.position;
        // Set's the player's transform
        //player.transform.rotation = Quaternion.identity; // or teleportTo.transform.rotation
        // Set's the camera's transform
        Camera.main.transform.rotation = Quaternion.identity;
    }
}