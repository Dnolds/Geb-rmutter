using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WalkingMovement : Movement
{
    public float speed;
    public float jumpForce;
    public Transform groundCheckPos;
    Button[] buttona;
    void Start()
    {
        buttons = SendButtons();
    }


    void Update()
    {
        
        MoveObject(speed);
        if (buttons.FirstOrDefault(e => e.buttonName == "space") != null)
        {
           
            if (buttons.FirstOrDefault(e => e.buttonName == "space").pressed && CheckForGround())
            {
                Debug.Log("Space wurde gedrückt");
                Jump(jumpForce);
            }
        }
    }
    bool CheckForGround()
    {
        if (Physics.OverlapSphere(groundCheckPos.position, 0.3f).FirstOrDefault(e => e.gameObject.tag == "Ground") != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
