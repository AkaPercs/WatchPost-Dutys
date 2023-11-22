using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            // Move the character forward
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
