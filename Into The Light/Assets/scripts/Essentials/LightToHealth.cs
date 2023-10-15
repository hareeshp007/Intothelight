using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToHealth : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>()!=null)
        {
            Debug.Log("Player Stay");
            PlayerView playerView = collision.gameObject.GetComponent<PlayerView>();
            playerView.AddHealth();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>() != null)
        {
            Debug.Log("Player exit");
            PlayerView playerView = collision.gameObject.GetComponent<PlayerView>();
            playerView.DecHealth();
        }
    }
}
