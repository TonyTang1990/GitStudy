using UnityEngine;

/// <summary>
/// 游戏主入口
/// </summary>
public class MainGame : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("MainGame()");
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        
    }
}