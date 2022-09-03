using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class Playermov : MonoBehaviour
{
    Movement controls;
    private Animator animator;
    Vector2 move;
    Vector2 dir = Vector2.zero;

    public float speed = 1f;


    void Awake()
    {
        controls = new Movement();
        controls.Player.Up.performed += ctrl => Up();
        controls.Player.Down.performed += ctrl => Down();
        controls.Player.Left.performed += ctrl => Left();
        controls.Player.Right.performed += ctrl => Right();

        controls.Player.Up.canceled += ctrl => UpR();
        controls.Player.Down.canceled += ctrl => DownR();
        controls.Player.Left.canceled += ctrl => LeftR();
        controls.Player.Right.canceled += ctrl => RightR();
        /*controls.Player.Move.canceled += ctrl => move = Vector2.zero;
        controls.Player.Move.performed += ctrl =>move = ctrl.ReadValue<Vector2>();*/
    }
    private void Start()
    { 
        animator = GetComponent<Animator>();
    }
    
    public void Up()
    {
        dir.y = 1;
        animator.SetInteger("Direction", 1);
        GetComponent<Rigidbody2D>().velocity = speed * dir;
        Debug.Log("Up");

    }
    public void Down()
    {
        dir.y = -1;
        animator.SetInteger("Direction", 0);
        GetComponent<Rigidbody2D>().velocity = speed * dir;
        Debug.Log("Down");

    }
    
    public void Right()
    {
        dir.x = 1;
        animator.SetInteger("Direction", 2);
        GetComponent<Rigidbody2D>().velocity = speed * dir;
        Debug.Log("Right");

    }

    public void Left()
    {
        dir.x = -1;
        animator.SetInteger("Direction", 3);
        GetComponent<Rigidbody2D>().velocity = speed * dir;
        Debug.Log("Left");
    }




public void UpR()
{
    dir.y =0;
    
    GetComponent<Rigidbody2D>().velocity = speed * dir;
    Debug.Log("UpR");

}
public void DownR()
{
    dir.y = 0;
    
    GetComponent<Rigidbody2D>().velocity = speed * dir;
    Debug.Log("DownR");

}

public void RightR()
{
    dir.x = 0;
    
    GetComponent<Rigidbody2D>().velocity = speed * dir;
    Debug.Log("RightR");

}

public void LeftR()
{
    dir.x = 0;
    
    GetComponent<Rigidbody2D>().velocity = speed * dir;
    Debug.Log("LeftR");
}
void Update()
    {
       /* if (Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("Vertical");
            dir = Vector2.zero;
        }*/

        /*
         Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime*speed;
         transform.Translate(m);




          if (move.x <= -0.00)
          {
              dir = 3;
              //Debug.Log("Left");
              animator.SetInteger("Direction", dir);
          }
          else if (move.x >= 0.00)
          {
              dir = 2;
              //Debug.Log("Right");
              animator.SetInteger("Direction", dir);
          }

          else if (move.y >= 0.00)
          {
              dir = 1;
              //Debug.Log("Up");
              animator.SetInteger("Direction", dir);
          }
          else if (move.y <= -0.00)
          {
              dir = 0;
              //Debug.Log("Down");
              animator.SetInteger("Direction", dir);
          }

          
        move.Normalize();

       */

        animator.SetBool("IsMoving", move.magnitude > 0);

        

    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDIsable()
    {
        controls.Disable();
    }
}

/*switch (measurement)
{
    case < 0.0:
        Console.WriteLine($"Measured value is {measurement}; too low.");
        break;

    case > 15.0:
        Console.WriteLine($"Measured value is {measurement}; too high.");
        break;

    case double.NaN:
        Console.WriteLine("Failed measurement.");
        break;

    default:
        Console.WriteLine($"Measured value is {measurement}.");
        break;
}*/