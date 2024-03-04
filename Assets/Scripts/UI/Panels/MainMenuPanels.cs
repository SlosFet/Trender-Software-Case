using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanels : UIPanel
{
    public void StartGame()
    {
        SceneManagement.Instance.LoadScene("Game");
    }

    public void Settings()
    {
        UIManager.Instance.CloseAllPanels();
        UIManager.Instance.OpenPanel("SettingsPanel");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
