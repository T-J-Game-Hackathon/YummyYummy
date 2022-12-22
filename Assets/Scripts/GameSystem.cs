using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSystem : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}