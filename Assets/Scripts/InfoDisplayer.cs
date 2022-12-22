using UnityEngine;
using System.Collections;
using TMPro;
public class InfoDisplayer : MonoBehaviour {
    [SerializeField] private GameObject infomation;
    private static float ScoreInfo, FullInfo;
    string ScoreText, FullText;
    [SerializeField] private TextMeshProUGUI text;
	void Start () {
        GetScore();
        ScoreDisplay();
    }
    void GetScore(){
        ScoreInfo = infomation.GetComponent<GameManager>().Show("Score");
        FullInfo = infomation.GetComponent<GameManager>().Show("Full");
        ScoreText = ((int)ScoreInfo).ToString();
        FullText = (FullInfo).ToString() + "%";
    }
    void ScoreDisplay(){
        text.text = ScoreText + "\n\n" + FullText;
    }
    
}
