using UnityEngine;

/// <summary>
/// ��Ϸ�����
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