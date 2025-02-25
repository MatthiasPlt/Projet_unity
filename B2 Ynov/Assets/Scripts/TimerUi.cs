using TMPro;
using UnityEngine;

public class TimerUi : MonoBehaviour
{
    private float _timer = 0;
    private bool isRunning = false;

    public void StartTimer()
    {
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            _timer += Time.deltaTime;
            GetComponent<TMP_Text>().text = (int)_timer + " sec";
        }
    }

    public float GetTime()
    {
        return _timer; // Retourne le temps actuel
    }
}
