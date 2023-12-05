using UnityEngine;

public class BloodTestMoving : MonoBehaviour
{
    public float moveSpeed = 2.5f; // Adjust the speed as needed
    public float rightwardDistance = 5f; // Adjust the rightward movement distance
    private bool isMoving = false;

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

            // Check if the current x position has exceeded the target x position
            if (bloodTest.transform.position.x >= targetPosition.x)
            {
                // Stop moving once the target position is reached or exceeded
                isMoving = false;
            }
        }
    }
}
