using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownScript : MonoBehaviour
{
    public int countdownTimer;
    public TextMeshProUGUI countdownDisplay;

    [SerializeField]
    Rigidbody2D myBody;

    public void StartCountdown()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTimer > 0)
        {
            countdownDisplay.text = countdownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countdownTimer--;
        }

        countdownDisplay.text = "GO!";

        myBody.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }
}
