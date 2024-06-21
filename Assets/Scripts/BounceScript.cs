using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BounceScript : MonoBehaviour
{
    public AudioClip bounceClip;
    public AudioClip winClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Trampoline"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*10, ForceMode.Impulse);
            AudioSource.PlayClipAtPoint(bounceClip,transform.localPosition);
        }
    }
    
}
