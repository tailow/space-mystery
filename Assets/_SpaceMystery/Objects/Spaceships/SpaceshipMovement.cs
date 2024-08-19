using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float resetAfterSeconds = 180;

    private Vector3 startPosition;

    private float lastReset;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Time.time - lastReset > resetAfterSeconds)
        {
            transform.position = startPosition;
            
            lastReset = Time.time;
        }
    }
}
