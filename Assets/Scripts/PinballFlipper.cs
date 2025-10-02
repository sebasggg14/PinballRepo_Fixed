using UnityEngine;

public class PinballFlipper : MonoBehaviour
{
    [SerializeField]
    KeyCode flipKey;

    [SerializeField]
    Rigidbody2D myBody;

    AudioSource myAudioSource;

    [SerializeField]
    AudioClip flipperClip;

    [SerializeField]
    float flipPower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(flipKey))
        {
            myAudioSource.PlayOneShot(flipperClip);
            myBody.AddForce(transform.up * flipPower);
        }
    }
}
