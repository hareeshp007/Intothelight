using IntoTheLight.Utilities;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IntoTheLight.Level
{

    public class LevelController
    {
        private string LobbyScene = "Lobby";
        private string[] Levels;
        public LevelController(string LobbyScene, string[] Levels)
        {
            this.LobbyScene = LobbyScene;
            this.Levels = Levels;
            if (GetLevelStatus(Levels[0]) == LevelStatus.locked)
            {
                SetLevelStatus(Levels[0], LevelStatus.unlocked);
            }
        }
        public void LoadAnyLevel(int LevelNumber)
        {
            SceneManager.LoadScene(LevelNumber);
            Debug.Log("Loading Level :" + LevelNumber);
        }
        public void LoadNextLevel()
        {
            UnityEngine.SceneManagement.Scene currentscene = SceneManager.GetActiveScene();
            int currentsceneIndex = Array.FindIndex(Levels, level => level == currentscene.name);
            int nextsceneindex = currentsceneIndex + 1;
            if (nextsceneindex < Levels.Length)
            {
                SceneManager.LoadScene(Levels[nextsceneindex]);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        public void MarkCurrentLevelCompleted()
        {
            UnityEngine.SceneManagement.Scene currentscene = SceneManager.GetActiveScene();
            SetLevelStatus(currentscene.name, LevelStatus.completed);
            int currentsceneIndex = Array.FindIndex(Levels, level => level == currentscene.name);
            int nextsceneindex = currentsceneIndex + 1;
            if (nextsceneindex < Levels.Length)
            {
                SetLevelStatus(Levels[nextsceneindex], LevelStatus.unlocked);
                Debug.Log(Levels[nextsceneindex] + "next scene name");
            }
            else if (nextsceneindex >= Levels.Length)
            {
                Debug.Log("All Levels Are completed");
            }
        }
        public void SetLevelStatus(string Level, LevelStatus levelStatus)
        {
            PlayerPrefs.SetInt(Level, (int)levelStatus);
            Debug.Log("level name :" + Level + " and its status is :" + levelStatus);
        }
        public LevelStatus GetLevelStatus(string level)
        {
            LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
            Debug.Log("level name :" + level + " and its status is :" + levelStatus);
            return levelStatus;
        }
        public void LevelReset()
        {
            for (int i = 1; i < Levels.Length; i++)
            {
                SetLevelStatus(Levels[i], LevelStatus.locked);
            }
            Debug.Log("Levels Has been reset");
        }
        public void Restart()
        {
            GameService.Instance.SoundController.Play(Sounds.ButtonClick);
            int currScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currScene);
        }

        public void LoadLobbyScene()
        {
            GameService.Instance.SoundController.Play(Sounds.ButtonClick);
            SceneManager.LoadScene(LobbyScene);
        }
        public int GetCurrentLevel()
        {
            int currentscene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log(currentscene);    
            return currentscene;
        }
    }
}