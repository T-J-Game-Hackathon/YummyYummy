using UnityEngine;
using UnityEngine.UI;

public class RedHoeButton : MonoBehaviour
{
    public void OnClick()
    {
        if (GameManager.Money >= 1000)
        {
            GameManager.Money -= 1000;
            if (Item.hoe1 > Player.GetItem())
            {
                Player.SetItem(Item.hoe1);
            }

            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
