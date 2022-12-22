using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

enum GrowPhase
{
    Phase0, // 未使用(植えられていない)
    Phase1,
    Phase2,
    Phase3 // 収穫可能
}

public class ArableLand : MonoBehaviour
{
    [SerializeField]
    private GameObject spriteObject;

    [SerializeField]
    private Sprite phase1Sprite;

    [SerializeField]
    private Sprite phase2PotatoSprite;

    [SerializeField]
    private Sprite phase3PotatoSprite;

    [SerializeField]
    private Sprite phase2SpinachSprite;

    [SerializeField]
    private Sprite phase3SpinachSprite;

    [SerializeField]
    private Sprite phase2TomatoSprite;

    [SerializeField]
    private Sprite phase3TomatoSprite;

    //   植物が植えられているかのboolean
    [SerializeField]
    public bool hasPlanted = false;

    // 植えられた時間
    // private DateTime plantedTime = DateTime.MinValue;
    [SerializeField]
    private float elapsedGrowTime = 0.0f;

    // 植えてから成長が完了するまでの時間
    [SerializeField]
    private float growTime = 10; // in seconds

    // 資金を追加する処理
    // 植えられている食物の種類
    [SerializeField]
    private Crop plantedCrop;

    // 成長の処理
    // 収穫可能かどうか
    [SerializeField]
    public bool isHarvestable = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAppearance();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAppearance();
    }

    void FixedUpdate()
    {
        if (hasPlanted)
        {
            elapsedGrowTime += Time.fixedDeltaTime;
        }
        if (hasPlanted && !isHarvestable)
        {
            // 成長が完了しているかどうか
            if (elapsedGrowTime > growTime)
            {
                isHarvestable = true;
            }
        }
    }

    void UpdateAppearance()
    {
        // 植えられているかどうか
        if (hasPlanted)
        {
            spriteObject.SetActive(true);
            // 成長が完了している場合
            switch (getGrowPhase())
            {
                case GrowPhase.Phase1:
                    spriteObject.GetComponent<SpriteRenderer>().sprite = phase1Sprite;
                    break;
                case GrowPhase.Phase2:
                    switch (plantedCrop)
                    {
                        case Crop.Potato:
                            spriteObject.GetComponent<SpriteRenderer>().sprite = phase2PotatoSprite;
                            break;
                        case Crop.Spinach:
                            spriteObject.GetComponent<SpriteRenderer>().sprite = phase2SpinachSprite;
                            break;
                        case Crop.Tomato:
                            spriteObject.GetComponent<SpriteRenderer>().sprite = phase2TomatoSprite;
                            break;
                    }
                    break;
                case GrowPhase.Phase3:
                    switch (plantedCrop)
                    {
                        case Crop.Potato:
                            spriteObject.GetComponent<SpriteRenderer>().sprite = phase3PotatoSprite;
                            break;
                        case Crop.Spinach:
                            spriteObject.GetComponent<SpriteRenderer>().sprite = phase3SpinachSprite;
                            break;
                        case Crop.Tomato:
                            spriteObject.GetComponent<SpriteRenderer>().sprite = phase3TomatoSprite;
                            break;
                    }
                    break;
            }
        }
        else
        {
            // 植えられていない場合
            spriteObject.SetActive(false);
        }
    }

    public void Plant(Crop crop)
    {
        plantedCrop = crop;
        hasPlanted = true;
        isHarvestable = false;
        elapsedGrowTime = 0.0f;
    }

    public void Harvest()
    {
        if (isHarvestable)
        {
            // Find game object with tag named "GameController"
            GameObject gameControllerObject = GameObject.FindWithTag("GameController");
            // Get component of the game object
            GameManager gameManager = gameControllerObject.GetComponent<GameManager>();
            // Add money
            gameManager.IncrementMoney(plantedCrop);

            hasPlanted = false;
            isHarvestable = false;
        }
    }

    private GrowPhase getGrowPhase()
    {
        if (!hasPlanted)
        {
            return GrowPhase.Phase0;
        }
        if (elapsedGrowTime < growTime / 2)
        {
            return GrowPhase.Phase1;
        }
        if (elapsedGrowTime < growTime)
        {
            return GrowPhase.Phase2;
        }
        return GrowPhase.Phase3;
    }
}
