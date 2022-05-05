using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float miliSeconds = 0;
    [SerializeField] int seconds = 0;
    [SerializeField] int minutes = 0;

    private int stage = 0;

    private bool markedStageOne = false;
    private bool markedStageTwo = false;
    private bool markedStageThree = false;

    [SerializeField] private TextMeshProUGUI UITime;
    
    [SerializeField] private TextMeshProUGUI UIExtras;
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject QuitMenuUI;
    [SerializeField] private GameObject GameOverMenuUI;

    Stack<GameObject> UIStack;
    private static bool pause = false;
    private static bool playerDied = false;

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
    private void OnEnable()
    {
        PlayerMovement.OnDie += GameOver;
    }
    private void OnDisable()
    {
        PlayerMovement.OnDie -= GameOver;
    }
    private void Start()
    {
        SetTimeScale(1);
        playerDied = false;
    }

    public int GetStage()
    {
        return stage;
    }

    private void Update()
    {
        if (seconds >= 30 && !markedStageOne)
        {
            stage = 1;
            markedStageOne = true;
            Debug.Log("Nivel 1");
            AnalyticsResult analyticsResult = Analytics.CustomEvent("LevelComplete", new Dictionary<string, object> 
            {
                { "Level", GetStage() } 
            }
            );
            Debug.Log("nivel1Result: " + analyticsResult);
        }

        if (minutes >= 1 && !markedStageTwo)
        {
            stage = 2;
            markedStageTwo = true;
            Debug.Log("Nivel 2");
            AnalyticsResult analyticsResult = Analytics.CustomEvent("LevelComplete", new Dictionary<string, object>
            {
                { "Level", GetStage() }
            }
            );
            Debug.Log("nivel2Result: " + analyticsResult);
        }

        if (minutes >= 2 && !markedStageThree)
        {
            stage = 3;
            markedStageThree = true;
            Debug.Log("Nivel 3");
            AnalyticsResult analyticsResult = Analytics.CustomEvent("LevelComplete", new Dictionary<string, object>
            {
                { "Level", GetStage() }
            }
            );
            Debug.Log("nivel3Result: " + analyticsResult);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
        if(!pause && !playerDied)
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
        UITime.text = minutes.ToString() + ":" + seconds.ToString();
        //Debug.Log(minutes.ToString() + ":" + seconds.ToString());
    }
    
    private void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
    private void GameOver()
    {
        SetTimeScale(0);
        playerDied = true;
        GameOverMenuUI.SetActive(true);
        //
    }
    public void SetPause()
    {
        if (!pause && !playerDied)
        {
            SetTimeScale(0);
            pause = true;
            PauseMenuUI.SetActive(true);
        }
        else if (QuitMenuUI.activeSelf && !playerDied)
        {
            PauseMenuUI.SetActive(true);
            QuitMenuUI.SetActive(false);
        }
        else if (PauseMenuUI.activeSelf)
        {
            SetTimeScale(1);
            PauseMenuUI.SetActive(false);
            pause = false;
        }
        else
        {
            GameOverMenuUI.SetActive(true);
            QuitMenuUI.SetActive(false);
        }
    }
}
