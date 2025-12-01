using UnityEngine;
public class LevelSelectManager : MonoBehaviour
{
    public void SelectLevel(int level)
    {
        if (GameManager.Instance != null) GameManager.Instance.LoadLevel(level);
    }
}