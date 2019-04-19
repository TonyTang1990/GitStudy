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

    void Start()
    {
        Debug.Log("Start()");
    }
}