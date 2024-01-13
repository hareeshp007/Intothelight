using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject GameOverScreen;
    public GameObject GameWonScreen;
    [SerializeField]
    private const string LobbyScene = "Lobby";
    [SerializeField]
    private int lastsceneint;
    private void Start()
    {
        Debug.Log("Level manager");
        GameService.Instance.PlayerServices.SetLevelManager(this);
    }
    public void pause()
    {
        GameService.Instance.SoundController.Play(Sounds.ButtonClick);
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
        GameService.Instance.LevelController.LoadNextLevel();
    }
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene(LobbyScene);
    }

}
