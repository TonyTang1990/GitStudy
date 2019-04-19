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

    void Start()
    {
        Debug.Log("Start()");
    }

    private void Update()
    {
        
    }
}