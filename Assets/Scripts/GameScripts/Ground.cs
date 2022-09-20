using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    private static bool is_ground = false;
    public static bool Is_ground => is_ground;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) is_ground = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) is_ground = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) is_ground = false;
    }
}