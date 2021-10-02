using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPeel : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.StartCoroutine("Slipped");
            Destroy(gameObject);
        }
    }
}
