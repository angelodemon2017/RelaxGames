using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PanelButtonLevel : MonoBehaviour
{
    public TextMeshProUGUI TextThisLevel;
    public TextMeshProUGUI TextCostBuy;

    public int NumberLevel;
    public string NameScene;

    public delegate void ChangeLevel();
    public static event ChangeLevel changeLevel;

    void Start()
    {
        
    }

    public void Init()     
    {

    }

    public void ButtonThisPanel() 
    {
        MoveToLevel();
    }

    private void MoveToLevel() 
    {
        changeLevel?.Invoke();
        SceneManager.LoadScene(NameScene);
        UIController.Instance.CloseMenu();
    }

    private void TryUnlock() 
    {

    }
}
