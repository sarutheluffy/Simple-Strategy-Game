using UnityEngine;

public enum GameState
{
    Idle,
    Ready
}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    public string PlayerName { get; private set; }
    public GameState currentState = GameState.Idle;

    public void OnClickButtonPlay(string playerName)
    {
        PlayerName = playerName;
        currentState = GameState.Ready;
        PanelHUD.ShowPanel().SetPlayerName(PlayerName);
    }
}
