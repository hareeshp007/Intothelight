

using IntoTheLight.Player;
using System;
using UnityEngine;

public class PlayerController
{
    private PlayerView _playerView;
    private PlayerModel _playerModel;

    public PlayerController(PlayerSO playerSO,PlayerView playerView)
    {
        CreatePlayer(playerSO,playerView);
    }

    private void CreatePlayer(PlayerSO playerSO, PlayerView playerView)
    {
        _playerView = playerView;
        _playerModel = new PlayerModel(this,playerSO);
    }
    public float TakeDamage(int damage)
    {
        _playerModel.CurrentHealth -=damage;
        return _playerModel.CurrentHealth;
    }

    public float GetCurrentHealth()
    {
        return _playerModel.CurrentHealth;
    }

    public void HealthDraining()
    {
        float health = _playerModel.CurrentHealth;
        float Drain = _playerModel.healthDraining;
        _playerModel.CurrentHealth = health - Drain;
    }

    public void HealUnderTheLight()
    {
        float health = _playerModel.CurrentHealth;
        float Gain = _playerModel.healthGaining;
        _playerModel.CurrentHealth = health + Gain;
    }

    public int GetCurrentExtraJumps()
    {
        return _playerModel.CurrentExtraJumps;
    }

    public void SetJumpsOnGround()
    {
        int MaxExtraJumps = _playerModel.MaxExtraJumps;

        _playerModel.CurrentExtraJumps = MaxExtraJumps;
    }

    public float GetJumpForce()
    {
        return _playerModel.JumpForce;
    }

    public void SetJumps()
    {
        int CurrentExtraJumps = _playerModel.CurrentExtraJumps;
        if (CurrentExtraJumps > 0)
        {
            CurrentExtraJumps--;
        }
        _playerModel.CurrentExtraJumps=CurrentExtraJumps;
    }

    public float GetSpeed()
    {
        return _playerModel.speed;
    }
}
