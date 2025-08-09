using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float xSpeed = 5f;
    float ySpeed = 5f;

    float xVector;
    float yVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");

        xVector = xDirection * xSpeed * Time.deltaTime;

        float yDirection = Input.GetAxis("Vertical");

        yVector = yDirection * ySpeed * Time.deltaTime;
        transform.Translate(xVector, yVector, 0);
    }
}
