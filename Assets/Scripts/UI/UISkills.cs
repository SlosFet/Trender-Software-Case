using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UISkills : MonoBehaviour
{
    [SerializeField] private Skill skill;
    [SerializeField] private Button skillButton;
    [SerializeField] private GameObject _skillCountdown;
    [SerializeField] private Image _skillCountdownImage;
    [SerializeField] private TextMeshProUGUI _skillCountdownText;

    private void OnEnable()
    {
        skill.OnSkillActivated += OpenSkillCountdown;
        skill.OnSkillLoading += UpdateCountdowner;
        skill.OnSkillActivateable += CloseCountdowner;
    }

    private void OnDisable()
    {
        skill.OnSkillActivated -= OpenSkillCountdown;
        skill.OnSkillLoading -= UpdateCountdowner;
        skill.OnSkillActivateable -= CloseCountdowner;
    }

    private void Start()
    {
        if (GameManager.Instance.currentOS == CurrentOS.Windows)
            skillButton.interactable = false;
    }

    private void OpenSkillCountdown()
    {
        SetStateOfCountDowning(true);
        _skillCountdownImage.fillAmount = 1;
    }

    private void UpdateCountdowner(float value)
    {
        _skillCountdownImage.fillAmount = value;
        _skillCountdownText.text = ((int)(skill._coolDown * value) + 1).ToString(); 
    }

    private void CloseCountdowner()
    {
        SetStateOfCountDowning(false);
    }

    private void SetStateOfCountDowning(bool state)
    {
        _skillCountdown.SetActive(state);
        if (GameManager.Instance.currentOS == CurrentOS.Android)
            skillButton.interactable = !state;
    }


}
