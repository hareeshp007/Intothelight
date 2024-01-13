using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject LevelMenu;
    private void Start()
    {
        LevelMenu.SetActive(false);
    }
    public void MenuLevel()
    {
        GameService.Instance.SoundController.Play(Sounds.ButtonClick);
        LevelMenu.gameObject.SetActive(true);
    }
    public void exit()
    {
        GameService.Instance.SoundController.Play(Sounds.ButtonClick);
        Application.Quit();
    }
    public void LevelReset()
    {
        GameService.Instance.LevelController.LevelReset();
    }
    public void MainMenu()
    {
        LevelMenu.SetActive(false);
    }
    public void ChangeSoundVolume(Slider slider)
    {
        GameService.Instance.SoundController.SetVolume(slider.value);
    }
    
}
