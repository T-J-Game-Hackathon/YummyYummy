using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private static int Score;

    [SerializeField]
    private static int Money;
    private static float TimeLimit; //Second
    private static float RateOfFull;
    private static float ElapsedTime;

    [SerializeField]
    private GameObject MenuUIPrefab;
    private GameObject MenuUIInstance;

    [SerializeField]
    public static float GetSupportCoolTime = 5.0f;
    private float lastUsedTime;
    public static float ScoreBuff = 1f;
    public static int SupportCount = 0;

    [SerializeField]
    public int SupportMoney = 2000;

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

    public void FixedUpdate()
    {
        ElapsedTime += Time.fixedDeltaTime;
        if (ElapsedTime >= TimeLimit)
        {
            // Game Over
        }
    }

    public void IncrementScore(Crop crop)
    {
        switch (crop)
        {
            case Crop.Potato:
                Score += 50;
                break;
            case Crop.Spinach:
                Score += 30;
                break;
            case Crop.Tomato:
                Score += 10;
                break;
            default:
                break;
        }
    }

    public void IncrementMoney(Crop crop)
    {
        switch (crop)
        {
            case Crop.Potato:
                Money += 10;
                break;
            case Crop.Spinach:
                Money += 30;
                break;
            case Crop.Tomato:
                Money += 50;
                break;
            default:
                break;
        }
    }

    public void GetSuppport(int money)
    {
        if (!CanGetSupport())
        {
            return;
        }

        lastUsedTime = Time.time;

        Money += money;
    }

    public bool CanGetSupport()
    {
        return Time.time - lastUsedTime >= GetSupportCoolTime;
    }

    public float RemainingCoolTime()
    {
        return GetSupportCoolTime - (Time.time - lastUsedTime);
    }

    public void GiveSupport()
    {
        if (!CanGiveSupport())
        {
            return;
        }

        SupportCount++;
        ScoreBuff += 0.1f;
        Money -= SupportMoney;
    }

    public bool CanGiveSupport()
    {
        return Money >= SupportMoney;
    }
}
