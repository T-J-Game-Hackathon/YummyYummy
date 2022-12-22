using UnityEngine;
using UnityEngine.SceneManagement;

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
    private string SceneName;

    public void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;
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
        if(Equals(SceneName,"Return")){
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
                Score += 10;
                break;
            case Crop.Spinach:
                Score += 30;
                break;
            case Crop.Tomato:
                Score += 50;
                break;
            default:
                break;
        }
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
