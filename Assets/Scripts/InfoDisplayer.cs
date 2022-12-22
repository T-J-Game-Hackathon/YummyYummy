using UnityEngine;
using TMPro;

public class InfoDisplayer : MonoBehaviour
{
    [SerializeField]
    private readonly GameObject infomation;
    private static float ScoreInfo,
        FullInfo;
    string ScoreText,
        FullText;

    [SerializeField]
    private readonly TextMeshProUGUI text;

    public void Start()
    {
        GetScore();
        ScoreDisplay();

        Time.timeScale = 0f;
    }

    void GetScore()
    {
        ScoreInfo = infomation.GetComponent<GameManager>().Show("Score");
        FullInfo = infomation.GetComponent<GameManager>().Show("Full");
        ScoreText = ((int)ScoreInfo).ToString();
        FullText = FullInfo.ToString() + "%";
    }

    void ScoreDisplay()
    {
        text.text = ScoreText + "\n\n" + FullText;
    }
}
