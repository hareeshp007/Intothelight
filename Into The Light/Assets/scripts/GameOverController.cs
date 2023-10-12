using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button Restart;
    public Button Lobby;
    public string LobbyScene = "Lobby";
    // Start is called before the first frame update
    void Start()
    {
        Restart= GetComponent<Button>();
        Lobby= GetComponent<Button>();
        Restart.onClick.AddListener(restartButton);
        Lobby.onClick.AddListener(LobbyButton);
    }

    private void LobbyButton()
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(LobbyScene);
    }

    private void restartButton()
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        int currScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene);
    }


}
