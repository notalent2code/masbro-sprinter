using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    private int desiredLane = 1; // 0: Left, 1: Middle, 2: Right
    public float forwardSpeed = 2;
    public float maxSpeed = 15;
    public float laneDistance = 4; // The distance between two lanes
    public float jumpForce = 10;
    public float gravity = -20;
    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        animator.SetBool("isGameStarted", true);

        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }

        direction.z = forwardSpeed;
        direction.y += gravity * Time.deltaTime;

        animator.SetBool("isGrounded", controller.isGrounded);

        if (controller.isGrounded)
        {
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeDown)
        {
            StartCoroutine(Slide());
        }

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        // Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position == targetPosition)
        {
            return;
        }

        // Calculate the move delta
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        if (controller.isGrounded)
        {
            direction.y = jumpForce;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.isGameOver = true;
        }
    }

    private IEnumerator Slide()
    {
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, 0.5f, 0);
        controller.height = 1;
        animator.transform.position = new Vector3(animator.transform.position.x, animator.transform.position.y - 0.8f, animator.transform.position.z);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("isSliding", false);
        controller.center = new Vector3(0, 1, 0);
        controller.height = 2;
        animator.transform.position = new Vector3(animator.transform.position.x, animator.transform.position.y + 0.8f, animator.transform.position.z);   
    }
}
