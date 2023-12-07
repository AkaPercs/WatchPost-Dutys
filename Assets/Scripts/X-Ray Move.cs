using UnityEngine;
using System.Collections;

public class XRayMoving : MonoBehaviour
{
    public float moveSpeed = 2.5f; // Adjust the speed as needed
    public float rightwardDistance = 5f; // Adjust the rightward movement distance
    public float moveDuration = 1f; // Adjust the duration after which movement stops
    public float pauseDuration = 2f; // Adjust the duration to pause at the new position
    public float returnDuration = 2f; // Adjust the duration for the return movement
    private bool isMoving = false;
    private float elapsedTime = 0f;
    private Vector3[] originalPositions;

    void Start()
    {
        // Store the original positions of XRay objects
        GameObject[] xRayObjects = GameObject.FindGameObjectsWithTag("XRay");
        originalPositions = new Vector3[xRayObjects.Length];
        for (int i = 0; i < xRayObjects.Length; i++)
        {
            originalPositions[i] = xRayObjects[i].transform.position;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MoveObjectsRight("XRay");
        }
    }

    // Function called when the button is clicked
    public void StartMovingXRayObjects()
    {
        isMoving = true;
        StartCoroutine(MoveBackAfterDelay("XRay"));
        elapsedTime = 0f; // Reset the elapsed time when starting movement
    }

    private void MoveObjectsRight(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objects)
        {
            // Calculate the target position for rightward movement
            Vector3 targetPosition = obj.transform.position + Vector3.right * rightwardDistance;

            // Move towards the target position at a constant speed
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Check if the elapsed time has exceeded the moveDuration
            if (elapsedTime >= moveDuration)
            {
                // Stop moving once the moveDuration is reached
                isMoving = false;
            }
        }
    }

    private IEnumerator MoveBackAfterDelay(string tag)
    {
        yield return new WaitForSeconds(moveDuration + pauseDuration); // Wait for moveDuration + pauseDuration before moving back

        GameObject[] objectsToMoveBack = GameObject.FindGameObjectsWithTag(tag);

        float elapsedTime = 0f;
        Vector3[] currentPositions = new Vector3[objectsToMoveBack.Length];

        for (int i = 0; i < objectsToMoveBack.Length; i++)
        {
            currentPositions[i] = objectsToMoveBack[i].transform.position;
        }

        while (elapsedTime < 1f)
        {
            for (int i = 0; i < objectsToMoveBack.Length; i++)
            {
                // Calculate the new position to move each object back to its original position
                Vector3 newPosition = Vector3.Lerp(currentPositions[i], originalPositions[i], elapsedTime);

                // Update the object's position
                objectsToMoveBack[i].transform.position = newPosition;
            }

            elapsedTime += Time.deltaTime / returnDuration;
            yield return null;
        }

        // Reset the flag after moving back
        isMoving = false;
    }
}
