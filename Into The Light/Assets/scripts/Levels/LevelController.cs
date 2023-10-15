using IntoTheLight.Utilities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoSingletonGeneric<LevelController>
{
    
    public string LobbyScene = "Lobby";

    public GameObject LevelMenu;
    public List<string> Levels;
    private int lastsceneint=4;
    public void LoadScene(int scenenumber)
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(scenenumber);
    }
    public void MenuLevel()
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        LevelMenu.gameObject.SetActive(true);
    }
    public void exit()
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }

    public void Restart()
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        int currScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene);
    }
    public void LoadNextScene()
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        
        int currScene = SceneManager.GetActiveScene().buildIndex;
        if (currScene < Levels.Count)
        {
            SceneManager.LoadScene(currScene + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
       

    }
    public void LoadLobbyScene()
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(LobbyScene);
    }
}
