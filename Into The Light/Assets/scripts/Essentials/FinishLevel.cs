using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.gameObject.GetComponent<PlayerView>()!=null)
            {
                PlayerView playerView = (PlayerView)collision.gameObject.GetComponent<PlayerView>();
                playerView.LevelCompleted();
                Debug.Log("Level Completed");
        }
    }
}
