using UnityEngine;
using UnityEngine.UI;

public class PanelMainMenu : MonoBehaviour
{
    [SerializeField] private InputField ifUserName;
    [SerializeField] private Button btnPlay, btnQuit;
    [SerializeField] private Text txtWarning;
    private void Start()
    {
        btnPlay.onClick.AddListener(OnClickButtonPlay);
        btnQuit.onClick.AddListener(OnClickButtonQuit);
    }

    private void OnClickButtonQuit() => Application.Quit();        

    private void OnClickButtonPlay()
    {
        if (string.IsNullOrEmpty(ifUserName.text))
        {
            txtWarning.text = "Please Enter the player name.";
            return;
        }
        GameManager.Instance.OnClickButtonPlay(ifUserName.text);
        Destroy(gameObject);
    }
}
