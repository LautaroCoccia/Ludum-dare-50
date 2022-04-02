using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float miliSeconds = 0;
    [SerializeField] int seconds = 0;
    [SerializeField] int minutes = 0;

    [SerializeField] private TextMeshProUGUI UITime;
    
    [SerializeField] private TextMeshProUGUI UIExtras;
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject QuitMenuUI;
    [SerializeField] private GameObject GameOverMenuUI;

    private static bool pause = false;
    private static LevelManager _instanceLevelManager;
    public static LevelManager Get()
    {
        return _instanceLevelManager;
    }
    private void Awake()
    {
        if (_instanceLevelManager == null)
        {
            _instanceLevelManager = this;
        }
        else if (_instanceLevelManager != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
        if(!pause)
        {
            if (miliSeconds < 1)
                miliSeconds += Time.deltaTime;
            else
            {
                miliSeconds = 0;
                seconds++;
                if (seconds > 59)
                {
                    seconds = 0;
                    minutes++;
                }
                UpdateTime(minutes, seconds);
            }
        }
    }
    private void UpdateTime(int minutes, int seconds)
    {
        //UITime.text = minutes.ToString() + ":" + seconds.ToString();
        Debug.Log(minutes.ToString() + ":" + seconds.ToString());
    }
    
    private void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
    private void GameOver()
    {
        SetTimeScale(0);
        //GameOverMenuUI.SetActive(true);
    }
    public void SetPause()
    {
        pause = !pause;
        if (pause)
        {
            SetTimeScale(0);
            //PauseMenuUI.SetActive(pause);
        }
        else
        {
            SetTimeScale(1);
            //PauseMenuUI.SetActive(pause);
            //QuitMenuUI.SetActive(pause);
        }
    }
}
