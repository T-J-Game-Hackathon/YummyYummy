using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text scoreLabel;

    [SerializeField]
    private TMPro.TMP_Text moneyLabel;

    [SerializeField]
    private TMPro.TMP_Text remainingTimeLabel;

    [SerializeField]
    private TMPro.TMP_Text satisfactionLabel;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI(0);
        UpdateMoneyUI(0);
        UpdateRemainingTimeUI(0);
        UpdateSatisfactionUI(0);
    }

    // Update is called once per frame
    void Update() { }

    public void UpdateScoreUI(int score)
    {
        scoreLabel.GetComponent<TMPro.TMP_Text>().text = score.ToString();
    }

    public void UpdateMoneyUI(int money)
    {
        moneyLabel.GetComponent<TMPro.TMP_Text>().text = money.ToString();
    }

    public void UpdateRemainingTimeUI(float remainingTime) // in seconds
    {
        int flooredRemainingTime = Mathf.FloorToInt(remainingTime);
        remainingTimeLabel.GetComponent<TMPro.TMP_Text>().text =
            (flooredRemainingTime / 60).ToString() + ":" + (flooredRemainingTime % 60).ToString("00");
    }

    public void UpdateSatisfactionUI(float satisfaction) // 0 to 1
    {
        satisfactionLabel.GetComponent<TMPro.TMP_Text>().text = string.Format("{0:0.0}%", satisfaction * 100);
    }
}
