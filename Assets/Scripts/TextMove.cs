using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BloodPopupText : MonoBehaviour
{
    public float moveUpSpeed = 50f; // Increase the speed as needed for faster movement
    public float moveBackSpeed = 5f; // Adjust the speed as needed for moving back
    public float distanceToMove = 200f; // Increase the distance to move as needed
    [SerializeField] private float delayBeforeMoveBack = 5f; // Expose the delayBeforeMoveBack as a serialized field
    private Vector2 initialTextPosition;

    private bool isMovingUp = false;

    private void Start()
    {
        GameObject[] bloodPopupTexts = GameObject.FindGameObjectsWithTag("BloodPopupText");
        initialTextPosition = bloodPopupTexts[0].GetComponent<RectTransform>().anchoredPosition;
    }

    private void Update()
    {
        if (isMovingUp)
        {
            MoveBloodPopupText();
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

    private void MoveBloodPopupText()
    {
        GameObject[] bloodPopupTexts = GameObject.FindGameObjectsWithTag("BloodPopupText");

        for (int i = 0; i < bloodPopupTexts.Length; i++)
        {
            RectTransform rectTransform = bloodPopupTexts[i].GetComponent<RectTransform>();

            // Calculate the new anchored position to move the UI Text up
            Vector2 newPosition = rectTransform.anchoredPosition + new Vector2(0, moveUpSpeed * Time.deltaTime);

            // Check if the UI Text has moved the desired distance
            if (Vector2.Distance(initialTextPosition, newPosition) >= distanceToMove)
            {
                newPosition = initialTextPosition + new Vector2(0, distanceToMove);
            }

            // Update the UI Text's anchored position
            rectTransform.anchoredPosition = newPosition;
        }
    }

    private IEnumerator MoveBackAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeMoveBack);

        GameObject[] bloodPopupTexts = GameObject.FindGameObjectsWithTag("BloodPopupText");

        float elapsedTime = 0f;
        Vector2 currentTextPosition = bloodPopupTexts[0].GetComponent<RectTransform>().anchoredPosition;

        while (elapsedTime < 1f)
        {
            for (int i = 0; i < bloodPopupTexts.Length; i++)
            {
                RectTransform rectTransform = bloodPopupTexts[i].GetComponent<RectTransform>();

                // Calculate the new anchored position to move the UI Text back to its original position
                Vector2 newPosition = Vector2.Lerp(currentTextPosition, initialTextPosition, elapsedTime);

                // Update the UI Text's anchored position
                rectTransform.anchoredPosition = newPosition;
            }

            elapsedTime += Time.deltaTime / (delayBeforeMoveBack / moveBackSpeed);
            yield return null;
        }

        // Reset the flag after moving back
        isMovingUp = false;
    }
}
