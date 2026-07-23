using UnityEngine;

public class CircleRotate : MonoBehaviour
{
    public float minSpeed = 30f;
    public float maxSpeed = 120f;

    private float rotateSpeed;

    void Start()
    {

        rotateSpeed = Random.Range(minSpeed, maxSpeed);


        if (Random.value > 0.5f)
            rotateSpeed *= -1f;
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}