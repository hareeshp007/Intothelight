
using IntoTheLight.Player;
using System.Collections.Generic;

public class PlayerModel 
{
    private PlayerController controller;
    public float CurrentHealth { get;  set; }
    public float MaxHealth { get; private set; }
    public float JumpForce { get; set; }
    public float speed { get; set; }
    public float healthDraining { get; set; }
    public float healthGaining{ get; set; }
    public int MaxExtraJumps { get; private set; }
    public int CurrentExtraJumps { get; set; }
    public Dictionary<string, string> Animations; 
    public PlayerModel(PlayerController playerController, PlayerSO playerSO)
    {
        controller = playerController;
        SetModel(playerSO);
    }
    public void SetModel( PlayerSO playerSO)
    {
        
        MaxHealth = playerSO.MaxHealth;
        CurrentHealth = MaxHealth;
        speed = playerSO.speed;
        Animations=playerSO.PlayerAnim;
        JumpForce = playerSO.JumpForce;
        healthDraining = playerSO.healthDraining;
        healthGaining = playerSO.healthGaining;
        MaxExtraJumps = playerSO.MaxExtraJumps;
        CurrentExtraJumps = MaxExtraJumps;
    }
}
