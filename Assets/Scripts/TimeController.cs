using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TimeController : MonoBehaviour
{
    [Space, Header("Text")]
    [SerializeField] private TextMeshProUGUI TimeText = null;

    [Space, Header("ButtonController")]
    [SerializeField] private ButtonController ButtonController = null;

    [Space, Header("Bool")]
    public bool flowOfTime = false;
    public bool isOpenVoice = false;

    [Space, Header("Audio")]
    public AudioSource audioSource;

    [Space, Header("Input")]
    public TMP_InputField hourInputField;
    public TMP_InputField minuteInputField; 
    public TMP_InputField secondInputField; 

    public int hour;
    public int minute;
    public int second;

    public IEnumerator CountTimer()
    {
        while (flowOfTime)
        {
            if (second > 0)
            {
                second--;
                yield return new WaitForSeconds(1);
            }
            else if (minute > 0)
            {
                minute--;
                second = 59;
                yield return new WaitForSeconds(1);
            }
            else if (hour > 0)
            {
                hour--;
                minute = 59;
                second = 59;
                yield return new WaitForSeconds(1);
            }
            else if (second == 0 && minute == 0 && hour == 0)
            {
                TimeOut();
                break;
            }
            TimeText.text = string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
        }
    }

    void TimeOut()
    {
        if (isOpenVoice)
        {
            audioSource.Play();
        }
        TimeText.gameObject.transform.DOScale(Vector3.one * 2, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }
}
