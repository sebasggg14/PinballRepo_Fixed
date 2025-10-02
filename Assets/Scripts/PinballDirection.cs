using UnityEngine;

public class PinballDirection : MonoBehaviour
{
    [SerializeField]
    int rotation = 0;

    [SerializeField]
    float speed = 0.1f;

    [SerializeField]
    bool limitedRotation = false;

    private int direction = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("RotateDir", speed, speed);
    }

    void RotateDir()
    {
        if (!limitedRotation)
        {
            transform.Rotate(0, 0, rotation);
        }

        if (limitedRotation)
        {
            transform.Rotate(0, 0, direction * rotation);
            float z = transform.localEulerAngles.z;
            if (z > 180) z -= 360;

            if (z >= 90f && direction == 1)
            {
                direction = -1;
            }
            else if (z <= -90f && direction == -1)
            {
                direction = 1;
            }
        }
    }
}
