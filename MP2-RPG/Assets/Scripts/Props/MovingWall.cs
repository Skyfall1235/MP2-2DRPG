using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public Vector3 targetPosition;
    public float moveSpeed = 5f;

    private Vector3 startPosition;
    private bool movingForward = true;
    private bool isMoving = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void ToggleMovement()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        Vector3 destination = movingForward ? targetPosition : startPosition;

        while (Vector3.Distance(transform.position, destination) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = destination;
        movingForward = !movingForward;
        isMoving = false;
    }
}
