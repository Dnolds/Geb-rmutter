using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected float[] axes = new float[2];
    public Button[] buttons; 
    void Awake()
    {
       
    }

    
    void LateUpdate()
    {
        axes[0] = Input.GetAxisRaw("Horizontal");
        axes[1] = Input.GetAxisRaw("Vertical");

        foreach(Button button in buttons)
        {
            if (Input.GetKeyDown(button.buttonName))
            {
                button.pressed = true;
            }
            else
            {
                button.pressed = false;
            }
        }
    }
    protected Button[] SendButtons()
    {
        return buttons;
    }
}
[System.Serializable]
public class Button
{

    public string buttonName;
    public bool pressed;

    public Button(string _buttonName, bool _pressed)
    {
        buttonName = _buttonName;
        pressed = _pressed;
    }
}
