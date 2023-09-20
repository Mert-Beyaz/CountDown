using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [Space, Header("TimeController")]
    [SerializeField] private TimeController TimeController = null;

    [Space, Header("AppButtons")]
    [SerializeField] private Button QuitButton = null;
    [SerializeField] private Button StartButtons = null;
    [SerializeField] private Button StopButtons = null;
    [SerializeField] private Button ResetButtons = null;

    [Space, Header("VoiceButtons")]
    [SerializeField] private Button OpenVoiceButtons = null;
    [SerializeField] private Button CloseVoiceButtons = null;

    void Start()
    {
        QuitButton.onClick.AddListener(() => QuitApp());
        StartButtons.onClick.AddListener(() => StartTime());
        StopButtons.onClick.AddListener(() => StopTime());
        ResetButtons.onClick.AddListener(() => ResetTime());
        OpenVoiceButtons.onClick.AddListener(() => OpenVoice());
        CloseVoiceButtons.onClick.AddListener(() => CloseVoice());
    }

    void QuitApp()
    {
        Application.Quit();
    }       
    void StartTime()
    {
        if (!TimeController.flowOfTime)
        {
            int.TryParse(TimeController.hourInputField.text, out TimeController.hour);
            int.TryParse(TimeController.minuteInputField.text, out TimeController.minute);
            int.TryParse(TimeController.secondInputField.text, out TimeController.second);
            TimeController.flowOfTime = true;
            StartCoroutine(TimeController.CountTimer());
            StartButtons.GetComponent<Image>().color = Color.gray;
        }
    }       
    void StopTime()
    {
        TimeController.flowOfTime = !TimeController.flowOfTime;
        if (TimeController.flowOfTime)
        {
            StopButtons.GetComponent<Image>().color = Color.gray;
            StartCoroutine(TimeController.CountTimer());
            TimeController.audioSource.Stop();
        }
        else StopButtons.GetComponent<Image>().color = Color.white;
    }      
    void ResetTime()
    {
        SceneManager.LoadScene(0);
    }    
    void OpenVoice()
    {
        TimeController.isOpenVoice = true;
        OpenVoiceButtons.GetComponent<Image>().color = Color.green;
        CloseVoiceButtons.GetComponent<Image>().color = Color.white;
    }    
    void CloseVoice()
    {
        TimeController.isOpenVoice = false;
        OpenVoiceButtons.GetComponent<Image>().color = Color.white;
        CloseVoiceButtons.GetComponent<Image>().color = Color.red;
    }    

}
