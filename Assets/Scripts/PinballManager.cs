using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PinballManager : MonoBehaviour
{
    public SceneTransition transitionReference;
    
    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    GameObject BallObject;

    Vector3 ballStartPos;

    int score = 00; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballStartPos = BallObject.transform.position;

        score = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore()
    {
        score+= 100;
        scoreText.text = "Score: " + score.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pinball"))
        {
            Debug.Log("works!");
            PlayerPrefs.SetInt("Score", score);
            transitionReference.FadeToLevel("SampleScene");
        }
    }
}