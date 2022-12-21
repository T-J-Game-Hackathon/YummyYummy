using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int Score;
    public static int Money;
    private static float TimeLimit; //Second
    private static float RateOfFull;
    private static float ElapsedTime;

    [SerializeField]private GameObject MenuUIPrefab;
    private GameObject MenuUIInstance;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Money = 0;
        TimeLimit = 180.0f; //Default: 3 min
        RateOfFull = 0;
        ElapsedTime = 0;
    }

    void TimeSwtiching(int mode)
    {
        switch (mode)
        {
            case 1:
                TimeLimit = 180;    break;
            case 2:
                TimeLimit = 300;    break;
            default:    break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuUIInstance == null)
            {
                MenuUIInstance = GameObject.Instantiate(MenuUIPrefab) as GameObject;
                Time.timeScale = 0f;
            }
            else
            {
                Destroy(MenuUIInstance);
                Time.timeScale = 1f;
            }
        }
        if(Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        // Debug.Log("LIMIT: " + (int)(TimeLimit - Time.time) + " seconds");
    }
}
