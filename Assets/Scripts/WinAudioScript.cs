using UnityEngine;

public class WinAudioScript : MonoBehaviour
{
    public static WinAudioScript instance;
    public AudioSource audioSource;
    public AudioClip sceneChangeClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound()
    {
        if (audioSource != null && sceneChangeClip != null)
        {
            audioSource.clip = sceneChangeClip;
            audioSource.Play();
        }
    }
}
