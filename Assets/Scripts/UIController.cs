using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public TextMeshProUGUI TextCoinsMainMenu;
    public GameObject PanelMainMenu;
    public GameObject PanelTop;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Currencies.coinsUpdate += UpdateCoins;
    }

    public void UpdateCoins(int count) 
    {
        TextCoinsMainMenu.text = $"COINS: {count}";
    }

    public void OpenMenu()
    {
        PanelMainMenu.SetActive(true);
        PanelTop.SetActive(true);
    }

    public void CloseMenu()
    {
        PanelMainMenu.SetActive(false);
        PanelTop.SetActive(false);
    }
}