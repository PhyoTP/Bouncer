using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class EndScript : MonoBehaviour
{
    public AudioClip clip;
    public string nextScene;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Play the audio clip
            if (audioSource != null && clip != null)
            {
                audioSource.Play();
            }

            // Load the next scene after a delay, or immediately after audio clip length
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        if (nextScene == null) {

        }
        else
        {
            yield return new WaitForSeconds(clip.length); // Wait for the audio clip to finish

            // Load the next scene

            SceneManager.LoadScene(nextScene);
        }
    }
}
