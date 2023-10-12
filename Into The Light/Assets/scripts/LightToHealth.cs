using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToHealth : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Player Stay");
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.AddHealth();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Player exit");
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.DecHealth();
        }
    }
}
