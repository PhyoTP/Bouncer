using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class EndScript : MonoBehaviour
{
    public AudioClip clip;
    public string nextScene;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
