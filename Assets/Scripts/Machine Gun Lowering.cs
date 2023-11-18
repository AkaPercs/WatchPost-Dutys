using UnityEngine;

public class MoveObjectDown : MonoBehaviour
{
    public float speed = 1.0f; // Adjust the speed as needed
    public float distanceToMove = 2.5f; // Adjust the distance to move as needed
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the new position to move the object down
        Vector3 newPosition = transform.position - new Vector3(0, speed * Time.deltaTime, 0);

        // Check if the object has moved the desired distance
        if (Vector3.Distance(initialPosition, newPosition) >= distanceToMove)
        {
            newPosition = initialPosition - new Vector3(0, distanceToMove, 0);
        }

        // Update the object's position
        transform.position = newPosition;
    }
}
