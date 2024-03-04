using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private List<UIPanel> _uýPanels;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        GameManager.OnGameStarted += OnGameStart;
        GameManager.OnGameOver += OnGameEnd;
    }

    private void OnDisable()
    {
        GameManager.OnGameStarted -= OnGameStart;
        GameManager.OnGameOver -= OnGameEnd;
    }

    private void OnGameStart()
    {
        CloseAllPanels();
        OpenPanel("InGamePanel");
    }
    private void OnGameEnd()
    {
        CloseAllPanels();
        OpenPanel("GameOverPanel");
    }

    public void CloseAllPanels()
    {
        foreach (var panel in _uýPanels)
        {
            if(panel.isPanelActive)
            panel.Close();
        }
    }

    public void OpenPanel(string panelName)
    {
        foreach (var panel in _uýPanels)
        {
            if (panel.panelName.Equals(panelName))
            {
                panel.Open();
                return;
            }
        }
    }
}
