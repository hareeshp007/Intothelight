

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
        _playerView.SetController(this);
        Debug.Log("MVC connected");
        Debug.Log("health" + _playerModel.CurrentHealth + " Drain:" + _playerModel.healthDraining);
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
        float Drain = _playerModel.healthDraining;
        _playerModel.CurrentHealth -= Drain;
    }

    public void HealUnderTheLight()
    {
        float Maxhealth = _playerModel.MaxHealth;
        float Health = _playerModel.CurrentHealth;
        float Gain = _playerModel.healthGaining;
        if (Health < Maxhealth)
        {
            _playerModel.CurrentHealth += Gain;
        }
        
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
