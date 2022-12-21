using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int Score;
    public static int Money;
    private static float TimeLimit; //Second
    private static float RateOfFull;
    private static float ElapsedTime;

    [SerializeField]
    private GameObject MenuUIPrefab;
    private GameObject MenuUIInstance;

    public void Start()
    {
        Score = 0;
        Money = 0;
        TimeLimit = 180.0f;
        RateOfFull = 0;
        ElapsedTime = 0;
    }

    public void TimeSwtiching(int mode)
    {
        switch (mode)
        {
            case 1:
                TimeLimit = 180;
                break;
            case 2:
                TimeLimit = 300;
                break;
            default:
                break;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuUIInstance == null)
            {
                MenuUIInstance = Instantiate(MenuUIPrefab);
                Time.timeScale = 0f;
            }
            else
            {
                Destroy(MenuUIInstance);
                Time.timeScale = 1f;
            }
        }
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
    }
}
