using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ArableLand : MonoBehaviour
{
    [SerializeField]
    private GameObject spriteObject;

    [SerializeField]
    private Sprite potatoSprite;

    [SerializeField]
    private Sprite spinachSprite;

    [SerializeField]
    private Sprite tomatoSprite;

    //   植物が植えられているかのboolean
    [SerializeField]
    private bool hasPlanted = false;

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
    private bool isHarvestable = false;

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
            switch (plantedCrop)
            {
                case Crop.Potato:
                    spriteObject.GetComponent<SpriteRenderer>().sprite = potatoSprite;
                    break;
                case Crop.Spinach:
                    spriteObject.GetComponent<SpriteRenderer>().sprite = spinachSprite;
                    break;
                case Crop.Tomato:
                    spriteObject.GetComponent<SpriteRenderer>().sprite = tomatoSprite;
                    break;
            }
        }
        else
        {
            // 植えられていない場合
            spriteObject.SetActive(false);
        }
    }
}
