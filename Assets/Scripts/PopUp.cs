using UnityEngine;
using System.Collections;

public class BloodPopup : MonoBehaviour
{
    public float moveUpSpeed = 3f; // Adjust the speed as needed for moving up
    public float moveBackSpeed = 5f; // Adjust the speed as needed for moving back
    public float distanceToMove = 8.5f; // Adjust the distance to move as needed
    [SerializeField] private float delayBeforeMoveBack = 5f; // Expose the delayBeforeMoveBack as a serialized field
    private Vector3[] initialPositions;

    private bool isMovingUp = false;

    private void Start()
    {
        GameObject[] bloodPopups = GameObject.FindGameObjectsWithTag("BloodPopup");
        initialPositions = new Vector3[bloodPopups.Length];

        for (int i = 0; i < bloodPopups.Length; i++)
        {
            initialPositions[i] = bloodPopups[i].transform.position;
        }
    }

    private void Update()
    {
        if (isMovingUp)
        {
            MoveBloodPopups();
        }
    }

    public void MoveUpButtonPressed()
    {
        isMovingUp = true;
        StartCoroutine(MoveBackAfterDelay());
    }

    public void MoveUpButtonReleased()
    {
        isMovingUp = false;
    }

    private void MoveBloodPopups()
    {
        GameObject[] bloodPopups = GameObject.FindGameObjectsWithTag("BloodPopup");

        for (int i = 0; i < bloodPopups.Length; i++)
        {
            // Calculate the new position to move each blood popup up
            Vector3 newPosition = bloodPopups[i].transform.position + new Vector3(0, moveUpSpeed * Time.deltaTime, 0);

            // Check if the blood popup has moved the desired distance
            if (Vector3.Distance(initialPositions[i], newPosition) >= distanceToMove)
            {
                newPosition = initialPositions[i] + new Vector3(0, distanceToMove, 0);
            }

            // Update the blood popup's position
            bloodPopups[i].transform.position = newPosition;
        }
    }

    private IEnumerator MoveBackAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeMoveBack);

        GameObject[] bloodPopups = GameObject.FindGameObjectsWithTag("BloodPopup");

        float elapsedTime = 0f;
        Vector3[] currentPositions = new Vector3[bloodPopups.Length];

        for (int i = 0; i < bloodPopups.Length; i++)
        {
            currentPositions[i] = bloodPopups[i].transform.position;
        }

        while (elapsedTime < 1f)
        {
            for (int i = 0; i < bloodPopups.Length; i++)
            {
                // Calculate the new position to move each blood popup back to its original position
                Vector3 newPosition = Vector3.Lerp(currentPositions[i], initialPositions[i], elapsedTime);

                // Update the blood popup's position
                bloodPopups[i].transform.position = newPosition;
            }

            elapsedTime += Time.deltaTime / (delayBeforeMoveBack / moveBackSpeed);
            yield return null;
        }

        // Reset the flag after moving back
        isMovingUp = false;
    }
}