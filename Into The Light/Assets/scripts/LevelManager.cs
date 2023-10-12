using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject GameOverScreen;
    public GameObject GameWonScreen;

    public string LobbyScene="Lobby";
    public int lastsceneint;

    public void pause()
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
    }
    public void GameOver()
    {

        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
    }
    public void GameWon()
    {
        Time.timeScale = 0;
        GameWonScreen.SetActive(true);
    }
    public void Unpause()
    {
        
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        
        int currScene=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene);
    }
    public void LoadNextScene()
    {
        
        int currScene = SceneManager.GetActiveScene().buildIndex;
        if (currScene == lastsceneint)
        {
            SceneManager.LoadScene(LobbyScene);
        }
        else
        {
            SceneManager.LoadScene(currScene + 1);
        }
        
    }
    public void LoadLobbyScene()
    {
        
        SceneManager.LoadScene(LobbyScene);
    }
}
