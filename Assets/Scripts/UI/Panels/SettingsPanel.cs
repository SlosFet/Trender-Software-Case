using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : UIPanel
{
    [SerializeField] private Slider _soundSlider;

    private void OnEnable()
    {
        _soundSlider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDestroy()
    {
        _soundSlider.onValueChanged.RemoveListener(SetVolume);
    }

    public void ReturnToMainMenu()
    {
        UIManager.Instance.CloseAllPanels();
        UIManager.Instance.OpenPanel("MainMenuPanel");
    }
    public override void Open()
    {
        _soundSlider.value = SoundManager.volume;
        base.Open();
    }

    public void SetVolume(float value)
    {
        SoundManager.SetVolume(value);
    }
}
