using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindowsManager : MonoBehaviour
{
    [SerializeField]
    private WindowsAsset mainMenuWindowsAsset;

    public void Host()
    {
        
    }

    public void Connect()
    {
        
    }

    public void Settings()
    {
        
    }

    public void Extra()
    {
        
    }

    public void Exit()
    {
        Debug.Log("Exit game...");
        Application.Quit();
    }
}
