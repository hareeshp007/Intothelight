using IntoTheLight.Player;
using IntoTheLight.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerServices : MonoSingletonGeneric<PlayerServices>
{
    private HealthBarController HealthBar;
    private LevelManager levelManager;
    public PlayerSO playerSO;
    [SerializeField]
    private PlayerView playerView;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private PlayerModel playerModel;
    private void Awake()
    {
        base.Awake();
        Debug.Log("Awake");
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        if (playerView == null)
        {
            this.playerView = GameObject.Instantiate<PlayerView>(playerSO.player);
        }
        this.playerController = new PlayerController(playerSO,playerView);
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
