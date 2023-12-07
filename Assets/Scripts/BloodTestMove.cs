using UnityEngine;
using System.Collections;

public class BloodTestMoving : MonoBehaviour
{
    public float moveSpeed = 2.5f; // Adjust the speed as needed
    public float rightwardDistance = 5f; // Adjust the rightward movement distance
    public float moveDuration = 1f; // Adjust the duration of the initial movement
    public float pauseDuration = 2f; // Adjust the duration to pause at the new position
    public float returnDuration = 2f; // Adjust the duration for the return movement
    private bool isMoving = false;
    private float elapsedTime = 0f;
    private Vector3[] originalPositions;

    void Start()
    {
        // Store the original positions of blood tests
        GameObject[] bloodTests = GameObject.FindGameObjectsWithTag("BloodTest");
        originalPositions = new Vector3[bloodTests.Length];
        for (int i = 0; i < bloodTests.Length; i++)
        {
            originalPositions[i] = bloodTests[i].transform.position;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MoveBloodTestsRight();
        }
    }

    // Function called when the button is clicked
    public void StartMovingBloodTests()
    {
        isMoving = true;
        StartCoroutine(MoveBackAfterDelay());
        elapsedTime = 0f; // Reset the elapsed time when starting movement
    }

    void MoveBloodTestsRight()
    {
        GameObject[] bloodTests = GameObject.FindGameObjectsWithTag("BloodTest");

        foreach (GameObject bloodTest in bloodTests)
        {
            // Calculate the target position for rightward movement
            Vector3 targetPosition = bloodTest.transform.position + Vector3.right * rightwardDistance;

            // Move towards the target position at a constant speed
            bloodTest.transform.position = Vector3.MoveTowards(bloodTest.transform.position, targetPosition, moveSpeed * Time.deltaTime);

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

    private IEnumerator MoveBackAfterDelay()
    {
        yield return new WaitForSeconds(moveDuration + pauseDuration); // Wait for moveDuration + pauseDuration before moving back

        GameObject[] bloodTests = GameObject.FindGameObjectsWithTag("BloodTest");

        float elapsedTime = 0f;
        Vector3[] currentPositions = new Vector3[bloodTests.Length];

        for (int i = 0; i < bloodTests.Length; i++)
        {
            currentPositions[i] = bloodTests[i].transform.position;
        }

        while (elapsedTime < 1f)
        {
            for (int i = 0; i < bloodTests.Length; i++)
            {
                // Calculate the new position to move each blood test back to its original position
                Vector3 newPosition = Vector3.Lerp(currentPositions[i], originalPositions[i], elapsedTime);

                // Update the blood test's position
                bloodTests[i].transform.position = newPosition;
            }

            elapsedTime += Time.deltaTime / returnDuration;
            yield return null;
        }
    }
}
