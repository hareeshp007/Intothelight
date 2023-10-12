using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paused : MonoBehaviour
{
    public Button Lobby;
    public Button Restart;
    // Start is called before the first frame update
    void Start()
    {
        Lobby=GetComponent<Button>();
        Restart=GetComponent<Button>();
        Lobby.onClick.AddListener(LevelController.Instance.LoadLobbyScene);
        Restart.onClick.AddListener(LevelController.Instance.Restart);
    }

}
