using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                PlayerController playerController = (PlayerController)collision.gameObject.GetComponent<PlayerController>();
                playerController.LevelCompleted();
                Debug.Log("Level Completed");
                
            }
        
    }
}
