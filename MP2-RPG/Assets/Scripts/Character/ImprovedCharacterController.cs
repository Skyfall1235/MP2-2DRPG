using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedCharacterController : MonoBehaviour
{
    public float Speed;

    Vector2 DirectionOfTravel = Vector2.zero;
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
                DirectionOfTravel.x = 0;
                DirectionOfTravel.y = 0;
                break;
            case 5:
                Debug.LogError("This should not be occuring, you are sending an error");
                break;
        }
            

        DirectionOfTravel.Normalize();
        animator.SetBool("IsMoving", DirectionOfTravel.magnitude > 0);

        rb.velocity = Speed * DirectionOfTravel;
    }

    //saving it here allows me to quickly access if wihout having to switch case bloc it
    private Dictionary<Vector2, int> directionMap = new Dictionary<Vector2, int>() { { Vector2.left, 0 }, { Vector2.right, 1 }, { Vector2.up, 2 }, { Vector2.down, 3 }, { Vector2.zero, 4 } };

    private int ConvertDirectionToInt(Vector2 originalVector)
    {
        if (directionMap.TryGetValue(originalVector, out int directionInt))
        {
            return directionInt;
        }
        return 5; // fail if not found. 5 was chosen to fit prior statement. (yes i know i should default to 0)
    }

    //honest to god i dont have time to refactor this, this is a wrapper for the IControl node calls
    public void MoveUp()
    {
        MoveCharacter(Vector2.up);
    }
    public void MoveDown()
    {
        MoveCharacter(Vector2.down);
    }
    public void MoveLeft()
    {
        MoveCharacter(Vector2.left);
    }
    public void MoveRight()
    {
        MoveCharacter(Vector2.right);
    }
}
