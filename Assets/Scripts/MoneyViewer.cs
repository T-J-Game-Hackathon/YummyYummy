using UnityEngine;

public class MoneyViewer : MonoBehaviour
{
    public void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = GameManager.Money.ToString() + " coin";
    }
}
