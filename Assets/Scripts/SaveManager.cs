using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void SaveLevelProgress(int level)
    {
        PlayerPrefs.SetInt("ProgressLevel", Mathf.Max(GetSavedLevel(), level));
        PlayerPrefs.Save();
    }

    public int GetSavedLevel()
    {
        return PlayerPrefs.GetInt("ProgressLevel", 0);
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("ProgressLevel");
    }
}