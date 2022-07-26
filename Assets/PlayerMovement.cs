using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public bool disabled = false;
    public CharacterController controller;
    public MouseLook ms;
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public float jumpheight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speedMulti;
    public bool grounded;

    public bool canTeleport = true;
    void Start()
    {
        cam = ms.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled)
        {
            if (Input.GetMouseButton(0) && !grounded && canTeleport)
            {
                DownSmash();
            }
            CheckIfGrounded();
            UpdatePlayerMovement();
            UpdateGravity();
            ms.UpdateMouseLook();
            if (Input.GetButtonDown("Jump") && grounded)
            {
                Jump();
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedMulti = 2f;
            }
            else
            {
                speedMulti = 1f;
            }
        }
    }

    void CheckIfGrounded()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    void UpdatePlayerMovement()
    {
       
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime * speedMulti);
    }
    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
    }
    void UpdateGravity()
    {
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void DownSmash()
    {
        RaycastHit hit;
        Ray ray = ms.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, LayerMask.NameToLayer("Ground")))
        {
            StartCoroutine(Teleport(hit));
        }
    }
    IEnumerator Teleport(RaycastHit hit)
    {
        canTeleport = false;
        disabled = true;
        yield return new WaitForSeconds(0.025f);
        gameObject.transform.position = new Vector3((float)hit.point.x, 0.5549998f, (float)hit.point.z);
        yield return new WaitForSeconds(0.025f);
        disabled = false;
        grounded = true;
        
        StartCoroutine(ResetTeleportTimer());
    }
    IEnumerator ResetTeleportTimer()
    {
        
        yield return new WaitForSeconds(1);
        canTeleport = true;
    }
}
