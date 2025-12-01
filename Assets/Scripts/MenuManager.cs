using UnityEngine;
public class MenuManager : MonoBehaviour
{
    public void OnStartButton()
    {
        if (UIManager.Instance != null) UIManager.Instance.StartGame();
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}