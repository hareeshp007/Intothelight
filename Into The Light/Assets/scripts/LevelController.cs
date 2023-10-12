using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static LevelController instance;
    public static LevelController Instance { get; private set; }
    public string LobbyScene = "Lobby";

    public GameObject LevelMenu;
    private int lastsceneint=5;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
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
        SoundController.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(LobbyScene);
    }
}
