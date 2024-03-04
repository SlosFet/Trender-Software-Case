using System;
using UnityEngine;
using TMPro;

public class GameEndPanel : UIPanel
{
    [SerializeField] private TextMeshProUGUI _playTimeText;
    [SerializeField] private TextMeshProUGUI _collectedGoldText;
    [SerializeField] private TextMeshProUGUI _killCountText;

    [SerializeField] private string _playTimeString;
    [SerializeField] private string _collectedGoldString;
    [SerializeField] private string _killCountString;


    private void OnEnable()
    {
        InGameDatas.SendPlayTime += SetTimer;
        InGameDatas.SendCollectedMoney += SetCollectedGoldText;
        InGameDatas.SendKillCount += SetKillCountText;
        Close();
    }
    private void OnDestroy()
    {
        InGameDatas.SendPlayTime -= SetTimer;
        InGameDatas.SendCollectedMoney -= SetCollectedGoldText;
        InGameDatas.SendKillCount -= SetKillCountText;
    }

    private void SetTimer(float value)
    {
        _playTimeText.text = string.Format(_playTimeString, TimeFormatted(value));
    }
    private string TimeFormatted(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);

        DateTime dateTime = DateTime.Today.Add(timeSpan);
        string formattedTime = "";

        if (dateTime.Hour > 0)
            formattedTime += dateTime.ToString("HH:");


        if (dateTime.Minute > 0 || dateTime.Hour > 0)
            formattedTime += dateTime.ToString("mm:");

        formattedTime += dateTime.ToString("ss:ff");
        return formattedTime;
    }

    private void SetCollectedGoldText(float value)
    {
        _collectedGoldText.text = string.Format(_collectedGoldString, value);
    }

    private void SetKillCountText(int value)
    {
        _killCountText.text = string.Format(_killCountString, value);
    }
}
