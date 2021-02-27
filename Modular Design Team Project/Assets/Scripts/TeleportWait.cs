using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWait : MonoBehaviour
{
    private GameObject player;
    public Transform teleportTo;
    public float waitSeconds;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("TeleportPlayer", waitSeconds);
        }
    }

    public void TeleportPlayer()
    {
        player.transform.position = teleportTo.transform.position;
        // Set's the player's transform
        player.transform.rotation = Quaternion.identity; // or teleportTo.transform.rotation
        // Set's the camera's transform
        Camera.main.transform.rotation = Quaternion.identity;
    }
}