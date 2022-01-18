using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    public Animator anim;
    public float movementSpeed;
    private float movementIndexVertical;
    private float movementIndexHorizontal;
    private bool run;
    private Vector3 direction;
    private NavMeshAgent navMeshAgent;
    public Transform cameraPosition, cameralookAt;

    void Start()
    {
        direction = transform.eulerAngles;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        float playerSpeed = movementSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
            playerSpeed *= 2;
        }
        else
        {
            run = false;
        }
        movementIndexVertical = Input.GetAxisRaw("Vertical");
        movementIndexHorizontal = Input.GetAxisRaw("Horizontal");

        direction = (cameraPosition.forward * movementIndexVertical + cameraPosition.right * movementIndexHorizontal).normalized;//new Vector3(movementIndexHorizontal, 0, movementIndexVertical);
        Vector3 tempdirection = Vector3.Lerp(transform.forward, direction, 0.5f * Time.deltaTime);
        transform.forward = tempdirection.normalized;
        anim.SetBool("run", run);
        anim.SetFloat("speed", Mathf.Abs(movementIndexVertical));
        navMeshAgent.Move(transform.forward * Time.deltaTime * movementIndexVertical * playerSpeed);
    }
}
