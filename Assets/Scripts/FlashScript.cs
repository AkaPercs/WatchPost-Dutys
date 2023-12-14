using System.Collections;
using UnityEngine;

public class FlashSequence : MonoBehaviour
{
    public GameObject[] flashes; // Assign the flashes in the order you want them to appear
    public float flashDuration = 0.5f;
    public float delayBetweenFlashes = 0.2f;

    void Start()
    {
        SetFlashesVisibility(false);
    }

    public void StartFlashSequence()
    {
        StartCoroutine(FlashSequenceCoroutine());
    }

    IEnumerator FlashSequenceCoroutine()
    {
        foreach (GameObject flash in flashes)
        {
            SetFlashVisibility(flash, true);

            yield return new WaitForSeconds(flashDuration);

            SetFlashVisibility(flash, false);

            yield return new WaitForSeconds(delayBetweenFlashes);
        }
    }

    void SetFlashVisibility(GameObject flash, bool visibility)
    {
        flash.SetActive(visibility);
    }

    void SetFlashesVisibility(bool visibility)
    {
        foreach (GameObject flash in flashes)
        {
            SetFlashVisibility(flash, visibility);
        }
    }
}
