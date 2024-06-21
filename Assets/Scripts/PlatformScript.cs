using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private Vector3 direction;
    public float startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition.z-2;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(direction * Time.deltaTime);
        if (transform.localPosition.z <= startPos) direction = Vector3.forward;
        else if (transform.localPosition.z == startPos+2) direction = Vector3.back;
        else if (transform.localPosition.z >= startPos+5) direction = Vector3.back;
        
        
    }
}
