using IntoTheLight.Level;
using IntoTheLight.Player;
using IntoTheLight.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class GameService : MonoSingletonGeneric<GameService>
{
    [Header("Player Service")]
    [SerializeField] private PlayerSO playerSO;

    [Header("sound Service")]
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private AudioSource SoundEffect;
    [SerializeField] private AudioSource SoundMusic;
    [SerializeField] private SoundType[] Sounds;
    [Header("Level Service")]
    [SerializeField] private string LobbyScene = "Lobby";
    [SerializeField] private string[] Levels;
    public LevelController LevelController { get; private set; }
    public SoundController SoundController { get; private set; }
    public PlayerServices PlayerServices { get; private set; }

    private void Start()
    {
        LevelController = new LevelController(LobbyScene,Levels);
        SoundController = new SoundController(VolumeSlider,SoundEffect,SoundMusic,Sounds);
        PlayerServices = new PlayerServices(playerSO);
    }
}
