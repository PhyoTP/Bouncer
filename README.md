# Welcome to Bouncers!
- A game where you are a bouncing ball
- Reach the end with the help of trampolines
- This game was created by Phyo Thet Pai during the Unity Bootcamp 2024
- Background music: LawnReality — Equnoix
## How I made it
I used `AddForce' to simulate a trampoline like this:
```cs
private void OnCollisionEnter(Collision collision)
{
    if (collision.collider.CompareTag("Trampoline"))
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*10, ForceMode.Impulse);
        AudioSource.PlayClipAtPoint(bounceClip,transform.localPosition);
    }
}
```
Then I made the camera rotate using the mouse like this. It initially was tilting whenever it was rotating, but I used `eulerAngles` to offset the Z axis.
```cs
transform.position = ball.transform.position;
//mouse control
transform.RotateAround(gameObject.transform.position, Vector3.up, Input.GetAxis("Mouse X"));
transform.RotateAround(gameObject.transform.position, -transform.right, Input.GetAxis("Mouse Y"));

gameObject.transform.Rotate(0, Input.GetAxis("Mouse X"), -transform.eulerAngles.z);

if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(1))
{
    Cursor.lockState = CursorLockMode.Locked;
}
else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
{
    Cursor.lockState = CursorLockMode.None;
}
```
It was hard to make the ball's rotation the same as the camera's rotation while also making the camera's position the same as the ball's position by making the ball the child of the camera or vice versa, so I just made them equal like in the first line in the previous code snippet as well as the first line below. To move, use WASD or arrow keys. originally I wanted to play a sound when the player dies, however I couldn't find a suitable sound. To make the player respawn, I made it so that it reloads the scene.
```cs
//movement
transform.rotation = camera.transform.rotation;
transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * moveSpeed);
transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * moveSpeed);


//respawn
if (transform.localPosition.y < -10 && !death)
{
    //AudioSource.PlayClipAtPoint(clip, transform.position);
    print("bong");
    death = true;
}
if (transform.localPosition.y < -40)
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
```
To ensure the background didn't stop playing when the scene changes, i added `DontDestroyOnLoad(gameObject);` to the empty holding the [music script](https://github.com/PhyoTP/Bouncer/blob/master/Assets/Scripts/AudioManager.cs). I made the audio persist by writing this:
```cs
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
    yield return new WaitForSeconds(clip.length); // Wait for the audio clip to finish

    // Load the next scene
    
    SceneManager.LoadScene(nextScene);
}
```
I made the moving platforms in Level 4 like this:
```cs
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
```
