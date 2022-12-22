using UnityEngine;
using UnityEngine.UI;

public class BlueHoeButton : MonoBehaviour
{
    public void OnClick()
    {
        if (GameManager.Money >= 2000)
        {
            GameManager.Money -= 2000;
            if (Item.hoe2 > Player.GetItem())
            {
                Player.SetItem(Item.hoe2);
            }
        }

        gameObject.GetComponent<Button>().interactable = false;
    }
}
