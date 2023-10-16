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

        LevelStatus levelStatus = LevelController.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.locked:
                Debug.Log(Levelnum + " This Level is Locked:");
                break;
            case LevelStatus.unlocked:
                SoundController.Instance.Play(Sounds.ButtonClick);
                Debug.Log(Levelnum + " This Level is Unlocked:");
                LevelController.Instance.LoadAnyLevel(Levelnum);
                break;
            case LevelStatus.completed:
                SoundController.Instance.Play(Sounds.ButtonClick);
                Debug.Log(Levelnum + " This Level is Completed:");
                LevelController.Instance.LoadAnyLevel(Levelnum);
                break;
        }

    }
}
