using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource audioSource;
    public AudioClip backgroundMusic; // Assign your MP3 audio clip here
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene changes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Loop the audio
        audioSource.Play(); // Start playing the background music
        audioSource.volume = 1.0f;
    }
    public void ChangeVolume(System.Single newVolume)
    {
        audioSource.volume = newVolume;
    }
    
    // You can add more methods to control the audio playback (pause, stop, volume control, etc.)
}
