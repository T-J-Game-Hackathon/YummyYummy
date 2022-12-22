using UnityEngine;
using UnityEngine.SceneManagement;

public class BackFromShop : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("InGame");
    }
}
