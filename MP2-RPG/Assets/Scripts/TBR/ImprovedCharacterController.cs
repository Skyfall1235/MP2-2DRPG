using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedCharacterController : MonoBehaviour
{
    bool isMoving;
    Vector2 DirectionOfTravel = Vector2.zero;
    public float speed;
    Rigidbody2D rb;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void MoveCharacter(Vector2 direction)
    {
        int directionToInt = ConvertDirectionToInt(direction);
        
        switch(directionToInt)
        {
            case 0:
                DirectionOfTravel.x = -1;
                animator.SetInteger("Direction", 3);
                break;
            case 1:
                DirectionOfTravel.x = 1;
                animator.SetInteger("Direction", 2);
                break;
            case 2:
                DirectionOfTravel.y = 1;
                animator.SetInteger("Direction", 1);
                break;
            case 3:
                DirectionOfTravel.y = -1;
                animator.SetInteger("Direction", 0);
                break;
            case 4:
                //no movement
                break;
            case 5:
                //throw error
                break;
        }
            

        DirectionOfTravel.Normalize();
        animator.SetBool("IsMoving", DirectionOfTravel.magnitude > 0);

        rb.velocity = speed * DirectionOfTravel;
    }

    private int ConvertDirectionToInt(Vector2 originalVector)
    {
        //this has got to be done
        if (originalVector == Vector2.left)
        {

        }
        else if (originalVector == Vector2.right)
        {

        }
        else if(originalVector == Vector2.up)
        {

        }
        else if (originalVector == Vector2.down)
        {

        }
        return 0;
    }
}
