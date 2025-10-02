using UnityEngine;

public class PinballBall : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D myBody;

    [SerializeField]
    PinballManager ScoreScript;

    AudioSource myAudioSource;

    [SerializeField]
    AudioClip bumperClip, wallClip, directionClip;

    SpriteRenderer mySprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myAudioSource = GetComponent<AudioSource>();
        myBody.bodyType = RigidbodyType2D.Kinematic; // Ball doesn’t move until countdown
    }

    // Update is called once per frame
    void Update()
    {
        myAudioSource.volume = 1.0f;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    myBody.bodyType = RigidbodyType2D.Dynamic;
        //    myBody.linearVelocity = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bumper":
                myBody.AddForce(transform.up * 1000);
                ScoreScript.AddScore();
                myAudioSource.PlayOneShot(bumperClip);
                break;
            case "Flipper":
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    myBody.AddForce(transform.up * 2500);
                }
                break;
            case "Spring":
                myBody.AddForce(transform.up * Random.Range(3500, 4500));
                break;
            case "FireBumper":
                myBody.AddForce(transform.up * Random.Range(1500, 2500));
                mySprite.color = new Color(1f, 0.2705882f, 0f, 1f);
                ScoreScript.AddScore();
                ScoreScript.AddScore();
                ScoreScript.AddScore();
                ScoreScript.AddScore();
                myAudioSource.PlayOneShot(bumperClip);
                break;
            case "WaterBumper":
                myBody.AddForce(transform.up * Random.Range(1500, 2500));
                mySprite.color = new Color(0f, 0f, 1f, 1f);
                ScoreScript.AddScore();
                ScoreScript.AddScore();
                ScoreScript.AddScore();
                myAudioSource.PlayOneShot(bumperClip);
                break;
            case "EarthBumper":
                myBody.AddForce(transform.up * Random.Range(1500, 2500));
                mySprite.color = new Color(0f, 1f, 0f, 1f);
                ScoreScript.AddScore();
                ScoreScript.AddScore();
                myAudioSource.PlayOneShot(bumperClip);
                break;
            case "Wall":
                myAudioSource.PlayOneShot(wallClip);
                myAudioSource.volume = 100f;
                break;


        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Direction"))
        {
            ScoreScript.AddScore();
            //Vector2 dirVec = new Vector2(collision.gameObject.transform.up.x, collision.gameObject.transform.up.y);
            myBody.linearVelocity += (Vector2)collision.gameObject.transform.up * 20;
            myAudioSource.PlayOneShot(directionClip);
        }
    }
}
