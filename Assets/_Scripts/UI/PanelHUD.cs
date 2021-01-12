using UnityEngine;
using UnityEngine.UI;

public class PanelHUD : MonoBehaviour
{
    public static PanelHUD Instance;
    [SerializeField] private Text txtPlayerName, textUnitName;

    public static PanelHUD ShowPanel()
    {
        if (Instance == null)
        {
            GameObject obj = Instantiate(Resources.Load("PanelHUD")) as GameObject;
            Transform canvas = GameObject.Find("Canvas").transform;
            obj.transform.SetParent(canvas, false);
            Instance = obj.GetComponent<PanelHUD>();
        }

        return Instance;
    }

    public void SetPlayerName(string playerName)
    {
        txtPlayerName.text = playerName;
    }

    public void SetUnitName(string name)
    {
        textUnitName.text = name;
    }
}
