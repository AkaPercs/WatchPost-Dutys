using UnityEngine;
using UnityEngine.UI;

public class ExpandButtonScript : MonoBehaviour
{
    public GameObject targetObject; // Assign the object you want to expand in the Inspector
    private RectTransform targetRectTransform;
    private Vector2 expandedSize = new Vector2(200, 200); // Set your desired expanded size

    private void Start()
    {
        targetRectTransform = targetObject.GetComponent<RectTransform>();
    }

    public void ExpandOrCollapse()
    {
        if (targetRectTransform.sizeDelta == Vector2.zero)
        {
            // Expand the object
            targetRectTransform.sizeDelta = expandedSize;
        }
        else
        {
            // Collapse or destroy the object
            targetRectTransform.sizeDelta = Vector2.zero;
        }
    }
}
