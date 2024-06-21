using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SphereScript : MonoBehaviour
{
    private GameObject camera;
    public float moveSpeed;
    public AudioClip clip;
    private bool death = false;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        transform.rotation = camera.transform.rotation;
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * moveSpeed);
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * moveSpeed);


        //respawn
        if (transform.localPosition.y < -10 && !death)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            print("bong");
            death = true;
        }
        if (transform.localPosition.y < -40)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
