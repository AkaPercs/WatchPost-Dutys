using UnityEngine;
using System.Collections;

public class MoveTurretsDown : MonoBehaviour
{
    public float moveDownSpeed = 1.0f; // Adjust the speed as needed for moving down
    public float moveBackSpeed = 0.5f; // Adjust the speed as needed for moving back
    public float distanceToMove = 2.5f; // Adjust the distance to move as needed
    [SerializeField] private float delayBeforeMoveBack = 5f; // Expose the delayBeforeMoveBack as a serialized field
    private Vector3[] initialPositions;

    private bool isMovingDown = false;

    private void Start()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        initialPositions = new Vector3[turrets.Length];

        for (int i = 0; i < turrets.Length; i++)
        {
            initialPositions[i] = turrets[i].transform.position;
        }
    }

    private void Update()
    {
        if (isMovingDown)
        {
            MoveTurrets();
        }
    }

    public void MoveDownButtonPressed()
    {
        isMovingDown = true;
        StartCoroutine(MoveBackAfterDelay());
    }

    public void MoveDownButtonReleased()
    {
        isMovingDown = false;
    }

    private void MoveTurrets()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");

        for (int i = 0; i < turrets.Length; i++)
        {
            // Calculate the new position to move each turret down
            Vector3 newPosition = turrets[i].transform.position - new Vector3(0, moveDownSpeed * Time.deltaTime, 0);

            // Check if the turret has moved the desired distance
            if (Vector3.Distance(initialPositions[i], newPosition) >= distanceToMove)
            {
                newPosition = initialPositions[i] - new Vector3(0, distanceToMove, 0);
            }

            // Update the turret's position
            turrets[i].transform.position = newPosition;
        }
    }

    private IEnumerator MoveBackAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeMoveBack);

        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");

        float elapsedTime = 0f;
        Vector3[] currentPositions = new Vector3[turrets.Length];

        for (int i = 0; i < turrets.Length; i++)
        {
            currentPositions[i] = turrets[i].transform.position;
        }

        while (elapsedTime < 1f)
        {
            for (int i = 0; i < turrets.Length; i++)
            {
                // Calculate the new position to move each turret back to its original position
                Vector3 newPosition = Vector3.Lerp(currentPositions[i], initialPositions[i], elapsedTime);

                // Update the turret's position
                turrets[i].transform.position = newPosition;
            }

            elapsedTime += Time.deltaTime / (delayBeforeMoveBack / moveBackSpeed);
            yield return null;
        }

        // Reset the flag after moving back
        isMovingDown = false;
    }
}
