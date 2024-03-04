using System;
using TMPro;
using UnityEngine;

public class PlayTimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playTimeCounter;
    private string formattedTime = "";
    private void OnEnable()
    {
        InGameDatas.SendPlayTime += UpdateCounter;
    }

    private void OnDisable()
    {
        InGameDatas.SendPlayTime -= UpdateCounter;
    }

    private void UpdateCounter(float value)
    {
        _playTimeCounter.text = TimeFormatted(value);
    }

    private string TimeFormatted(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);

        DateTime dateTime = DateTime.Today.Add(timeSpan);
        formattedTime = "";

        if (dateTime.Hour > 0)
            formattedTime += dateTime.ToString("HH:");


        if (dateTime.Minute > 0 || dateTime.Hour > 0)
            formattedTime += dateTime.ToString("mm:");

        formattedTime += dateTime.ToString("ss:ff");
        return formattedTime;
    }
}
