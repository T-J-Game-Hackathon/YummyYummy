using UnityEngine;
using UnityEngine.UI;

public class GoldHoeButton : MonoBehaviour
{
    public void OnClick()
    {
        if (GameManager.Money >= 3000)
        {
            GameManager.Money -= 3000;
            if (Item.hoe3 > Player.GetItem())
            {
                Player.SetItem(Item.hoe3);
            }
        }

        gameObject.GetComponent<Button>().interactable = false;
    }
}
