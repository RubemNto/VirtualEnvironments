using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public CharacterController characterController;
    //public Transform target;
    public List<Vector3> patrolPositions = new List<Vector3>();
    private Vector3 startPosition = Vector3.zero;
    public Vector3 VectorToTarget = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private int targetPosition = 0;
    private int currentStartPosition;

    public bool go = true;
    public float speed = 0.45f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        for (int i = 0; i < patrolPositions.Count; i++)
        {
            patrolPositions[i] = new Vector3(patrolPositions[i].x, transform.position.y, patrolPositions[i].z);
        }
        if (go == true)
        {
            startPosition = patrolPositions[0];
            currentStartPosition = 0;
            targetPosition = 1;
        }
        else
        {
            startPosition = patrolPositions[patrolPositions.Count];
            currentStartPosition = patrolPositions.Count;
            targetPosition = patrolPositions.Count - 1;
        }
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        VectorToTarget = patrolPositions[targetPosition] - transform.position;
        velocity = patrolPositions[targetPosition] - patrolPositions[currentStartPosition];
        Debug.Log(VectorToTarget.magnitude);
        if (VectorToTarget.magnitude <= 1)
        {
            currentStartPosition = targetPosition;
            if (targetPosition >= patrolPositions.Count - 1) go = false; else if (targetPosition <= 0) go = true;
            if (go == true) targetPosition += 1; else if (go == false) targetPosition -= 1;
        }
        //Debug.Log(velocity.ToString() + "Maginitude: " + velocity.magnitude.ToString());
        velocity.Normalize();
        transform.forward = velocity;
        characterController.Move(velocity * speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        foreach (Vector3 vector in patrolPositions)
        {
            if (vector == patrolPositions[0]) Gizmos.color = Color.green;
            else if (vector == patrolPositions[patrolPositions.Count - 1]) Gizmos.color = Color.red;
            else if (vector == patrolPositions[targetPosition]) Gizmos.color = Color.yellow;
            else Gizmos.color = Color.gray;
            Gizmos.DrawSphere(vector, 0.1f);
        }
    }
}
