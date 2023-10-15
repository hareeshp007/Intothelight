using IntoTheLight.Player;
using IntoTheLight.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerServices : MonoSingletonGeneric<PlayerServices>
{
    public HealthBarController HealthBar;
    public PlayerSO playerSO;
    [SerializeField]
    private PlayerView playerView;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private PlayerModel playerModel;
    private void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        playerView = GameObject.Instantiate<PlayerView>(playerSO.player);
        playerController = new PlayerController(playerSO,playerView);
        SetHealthBar();
    }
    private void SetHealthBar()
    {
        playerView.SetHealthBar(HealthBar);
        Debug.Log("HealthController connected");
    }
}
