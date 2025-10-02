using UnityEngine;

public class PinballState : MonoBehaviour
{
    [SerializeField]
    GameObject gateObj;

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pinball"))
        {
            gateObj.SetActive(true);
        }
    }
}