using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static int Score;

    [SerializeField]
    public static int Money;
    private static float TimeLimit; //Second
    public static float RateOfFull;
    private static float ElapsedTime;

    [SerializeField]
    public GameObject MenuUIPrefab;
    private GameObject MenuUIInstance;
    private string SceneName;

    [SerializeField]
    public static float GetSupportCoolTime = 5.0f;
    private float lastUsedTime;
    public static float ScoreBuff = 1f;
    public static int SupportCount = 0;

    [SerializeField]
    public int SupportMoney = 2000;

    public GameObject InGameUICanvasObject;
    private InGameUI InGameUIInstance;

    [SerializeField] private GameObject TimeUpPrefab;
    private GameObject TimeUp;
    
    public void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;
        Score = 0;
        Money = 0;
        // TimeLimit = 180.0f;
        TimeLimit = 20.0f;

        RateOfFull = 0;
        ElapsedTime = 0;

        // 常時表示UIのCanvasについているインスタンス`InGameUI`を取得
        if(Equals(SceneName,"Result")){
            return;
        }
        InGameUIInstance = InGameUICanvasObject.GetComponent<InGameUI>();
        
        DontDestroyOnLoad(gameObject);
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
        if(Equals(SceneName,"Result")){
            return;
        }
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
        if(Equals(SceneName,"Result")){
            return;
        }
        ElapsedTime += Time.fixedDeltaTime;
        UpdateRemainingTimeUI();
        if ((ElapsedTime >= TimeLimit))
        {   
            if(TimeUp == null){
                TimeUp = Instantiate(TimeUpPrefab);
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Result");
    }

    public void IncrementScore(Crop crop)
    {
        Debug.Log("IncrementScore has called!");
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

        if (InGameUIInstance != null)
        {
            InGameUIInstance.UpdateScoreUI(Score);
            UpdateSatisfactionUI();
        }
    }

    public void IncrementMoney(Crop crop)
    {
        Debug.Log("IncrementMoney has called!");

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
        InGameUIInstance?.UpdateMoneyUI(Money);
    }

    void UpdateSatisfactionUI()
    {
        float targetScore = 5000;
        RateOfFull = Score / targetScore;
        InGameUIInstance?.UpdateSatisfactionUI(RateOfFull);
    }

    private float GetRemainingTime()
    {
        return TimeLimit - ElapsedTime;
    }

    void UpdateRemainingTimeUI()
    {
        InGameUIInstance?.UpdateRemainingTimeUI(Mathf.Max(0, GetRemainingTime()));
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

    public float Show(string name){
        switch(name){
            case "Score":
                return (float)Score;
            case "Full":
                return RateOfFull;
            default: return 0f;
        }
    }
}
