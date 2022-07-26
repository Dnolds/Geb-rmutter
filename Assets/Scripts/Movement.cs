using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Movement : InputManager
{
    Rigidbody rb;
    
    private void Awake()
    {
      
        rb = GetComponent<Rigidbody>();
        buttons = SendButtons();
    }
    public void MoveObject(float speed)
    {
        
       
        
            transform.Translate(Vector3.forward * speed * axes[1]*Time.deltaTime);
            transform.Translate(Vector3.right * speed * axes[0] * Time.deltaTime);

    }
    public void Jump(float jumpForce)
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * Time.deltaTime * jumpForce * 10, ForceMode.Impulse);
        }
    }
    
}
