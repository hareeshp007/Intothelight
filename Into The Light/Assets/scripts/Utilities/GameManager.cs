using IntoTheLight.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingletonGeneric<GameManager>
{
    public PlayerServices Player;
    public LevelManager InGameUIManger;
    private LevelManager InGameManger;
    private PlayerServices PlayerServices;
    public Transform StartPos { get; set; }

    private void Start()
    {
        PlayerServices = GameObject.Instantiate<PlayerServices>(Player);
        InGameManger = GameObject.Instantiate<LevelManager>(InGameUIManger);
        PlayerServices.SetLevelManager(InGameManger);
    }
}
