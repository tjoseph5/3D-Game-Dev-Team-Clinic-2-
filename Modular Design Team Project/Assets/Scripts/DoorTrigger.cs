using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorAction
{
    Open,
    Close
}

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnim;
    public DoorAction doorAction;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetTrigger(doorAction.ToString());
        }
    }
}