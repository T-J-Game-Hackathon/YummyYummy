using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ItemButton : MonoBehaviour
{
    public int price = 500;
    public int money = 3000;
    private Button itemButton;

    void Awake()
    {
        if(money < 0)
        {
            
        }
        else if(money < price)
        

    }
    private void OnMoneyChange(int money)
    {
        itemButton.interactable = money >= price ;
    }
}