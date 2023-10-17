using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject LevelMenu;
    public Slider MusicVolumeSlider;
    private void Start()
    {
        LevelMenu.SetActive(false);
        SetSliderValueMusic();
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
    public void ChangeSoundVolume(Slider slider)
    {
        SoundController.Instance.SetVolume(slider.value);
    }
    public void SetSliderValueMusic()
    {
        SoundController.Instance.SetVolumeSlider(MusicVolumeSlider);
    }
}
