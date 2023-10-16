using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject LevelMenu;
    private void Start()
    {
        LevelMenu.SetActive(false);
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
    public void LevelReset()
    {
        LevelController.Instance.LevelReset();
    }
    public void MainMenu()
    {
        LevelMenu.SetActive(false);
    }
}
