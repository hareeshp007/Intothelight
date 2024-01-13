using IntoTheLight.Player;
using IntoTheLight.Utilities;
using System;

using UnityEngine;

public class PlayerServices : MonoSingletonGeneric<PlayerServices>
{
    private HealthBarController HealthBar;
    private LevelManager levelManager;
    private PlayerSO playerSO;
    [SerializeField]
    private PlayerView playerView;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private PlayerModel playerModel;
    public PlayerServices (PlayerSO playerSO)
    {
        Debug.Log("Player connected");
        this.playerSO = playerSO;
       
    }

    private void CreatePlayer()
    {
            this.playerView = GameObject.Instantiate<PlayerView>(playerSO.player);
            this.playerController = new PlayerController(playerSO, playerView);
            SetPlayer();
    }
    private void SetPlayer()
    {
        if (HealthBar != null)
        {
            playerView.SetHealthBar(HealthBar);
        }
        if(levelManager != null)
        {
            playerView.SetLevelManager(levelManager);
        }

        Debug.Log("HealthController connected");
    }
    public void SetLevelManager(LevelManager _levelManager)
    {
        levelManager = _levelManager;
        CheckPlayer();
    }
    public void SetHealthBar(HealthBarController healthBarController)
    {
        HealthBar = healthBarController;
        CheckPlayer();
    }
    private void CheckPlayer()
    {
        if (playerView == null)
        {
            CreatePlayer();
        }
        if (playerView != null)
        {
            SetPlayer();
        }
    }
    public void SetPlayer(PlayerView _playerView)
    {
        playerView= _playerView;
    }
}
