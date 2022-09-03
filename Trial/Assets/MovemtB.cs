using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemtB : MonoBehaviour

{


    private Animator animator;
    Vector2 move;
    Vector2 dirt = Vector2.zero;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal1");
        move.y = Input.GetAxis("Vertical1");

        /* if (move.x != 0)
         {
             Debug.Log("Horizontal");
         }
         if (move.y != 0)
         {
             Debug.Log("Vertical");
         }*/

        Vector2 dirt = new Vector2(move.x, move.y) * Time.deltaTime * speed;
        transform.Translate(dirt);

        GetComponent<Rigidbody2D>().velocity = speed * dirt;

        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Speed", move.sqrMagnitude);


    }
}

