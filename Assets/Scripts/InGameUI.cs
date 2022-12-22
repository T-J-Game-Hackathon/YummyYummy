using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject holdingCropSpriteObject;
    public GameObject ItemSpriteObject;

    [SerializeField]
    private TMPro.TMP_Text scoreLabel;

    [SerializeField]
    private TMPro.TMP_Text moneyLabel;

    [SerializeField]
    private TMPro.TMP_Text remainingTimeLabel;

    [SerializeField]
    private TMPro.TMP_Text satisfactionLabel;

    public Sprite potatoSprite;
    public Sprite spinachSprite;
    public Sprite tomatoSprite;
    public Sprite baseHoeSprite;
    public Sprite hoe1Sprite;
    public Sprite hoe2Sprite;
    public Sprite hoe3Sprite;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI(0);
        UpdateMoneyUI(0);
        UpdateRemainingTimeUI(0);
        UpdateSatisfactionUI(0);
        UpdateHoldingCropSprite(Crop.Potato);
        UpdateItemSprite(Item.None);
    }

    // Update is called once per frame
    void Update()
    {
        // Eキーが押されたら
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Shopを開く
            OnShopOpened();
        }
        UpdateItemSprite(Player.item);
    }

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
        satisfactionLabel.GetComponent<TMPro.TMP_Text>().text =
            satisfaction < 0.1
                ? string.Format("{0:0.0}%", satisfaction * 100)
                : string.Format("{0:0}%", satisfaction * 100);
    }

    public void UpdateHoldingCropSprite(Crop crop)
    {
        switch (crop)
        {
            case Crop.Potato:
                holdingCropSpriteObject.GetComponent<Image>().sprite = potatoSprite;
                break;
            case Crop.Spinach:
                holdingCropSpriteObject.GetComponent<Image>().sprite = spinachSprite;
                break;
            case Crop.Tomato:
                holdingCropSpriteObject.GetComponent<Image>().sprite = tomatoSprite;
                break;
            default:
                holdingCropSpriteObject.GetComponent<Image>().sprite = potatoSprite;
                break;
        }
    }

    public void UpdateItemSprite(Item item)
    {
        switch (item)
        {
            case Item.None:
                ItemSpriteObject.GetComponent<Image>().sprite = baseHoeSprite;
                break;
            case Item.hoe1:
                ItemSpriteObject.GetComponent<Image>().sprite = hoe1Sprite;
                break;
            case Item.hoe2:
                ItemSpriteObject.GetComponent<Image>().sprite = hoe2Sprite;
                break;
            case Item.hoe3:
                ItemSpriteObject.GetComponent<Image>().sprite = hoe3Sprite;
                break;
            default:
                ItemSpriteObject.GetComponent<Image>().sprite = baseHoeSprite;
                break;
        }
    }

    public void OnShopOpened()
    {
        Debug.Log("Shop opened! or at least it should have.");
    }
}
