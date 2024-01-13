using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private Button LevelButton;
    public string LevelName;
    public int Levelnum;
    void Start()
    {
        LevelButton = GetComponent<Button>();
        LevelButton.onClick.AddListener(LevelSelect);
    }

    private void LevelSelect()
    {

        LevelStatus levelStatus = GameService.Instance.LevelController.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.locked:
                Debug.Log(Levelnum + " This Level is Locked:");
                break;
            case LevelStatus.unlocked:
                GameService.Instance.SoundController.Play(Sounds.ButtonClick);
                Debug.Log(Levelnum + " This Level is Unlocked:");
                GameService.Instance.LevelController.LoadAnyLevel(Levelnum);
                break;
            case LevelStatus.completed:
                GameService.Instance.SoundController.Play(Sounds.ButtonClick);
                Debug.Log(Levelnum + " This Level is Completed:");
                GameService.Instance.LevelController.LoadAnyLevel(Levelnum);
                break;
        }

    }
}
