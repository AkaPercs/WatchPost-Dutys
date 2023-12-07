using UnityEngine;

public class CollapseButtonScript : MonoBehaviour
{
    public GameObject targetObject; // Assign the same object as in ExpandButtonScript
    private RectTransform targetRectTransform;

    private void Start()
    {
        targetRectTransform = targetObject.GetComponent<RectTransform>();
    }

    public void Collapse()
    {
        // Collapse or destroy the object
        targetRectTransform.sizeDelta = Vector2.zero;
    }
}
