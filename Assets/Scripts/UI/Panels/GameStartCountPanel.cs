using System.Collections;
using UnityEngine;
using TMPro;

public class GameStartCountPanel : UIPanel
{
    [SerializeField] private TextMeshProUGUI _counter;
    private void OnEnable()
    {
        GameManager.OnGameStarting += StartCounter;
    }

    private void OnDisable()
    {
        GameManager.OnGameStarting -= StartCounter;
    }

    private void StartCounter(float time)
    {
        StartCoroutine(Counter(time));
    }

    IEnumerator Counter(float time)
    {
        _counter.text = ((int)time).ToString();

        while (time > 0 || gameObject.activeInHierarchy)
        {
            time -= Time.deltaTime;
            _counter.text = ((int)(time + 1)).ToString();

            yield return new WaitForEndOfFrame();
        }

        time = 0;
        _counter.text = ((int)time).ToString();
        yield break;
    }
}
