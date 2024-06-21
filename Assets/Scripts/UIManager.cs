using UnityEngine;

public class UIManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Ensure UIManager persists across scene changes
    }
}
