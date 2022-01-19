using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animals : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
        }
            
    }
}
