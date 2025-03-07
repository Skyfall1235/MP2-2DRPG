using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonControlSchema : MonoBehaviour
{

    public Transform[] inputButtons = new Transform[4];
    public ImprovedCharacterController charController;
    public DialogManager dialogMgr;

    private void Awake()
    {
        AddMovementListeners();
        dialogMgr = GetComponent<DialogManager>();
    }

    public void StopMovement()
    {
        charController.StopMovement();
    }


    //i refactored this last minute, this is what works to il have to do it
    public void AddMovementListeners()
    {
        inputButtons[0].GetComponent<Button>().onClick.AddListener(charController.MoveUp);
        inputButtons[1].GetComponent<Button>().onClick.AddListener(charController.MoveDown);
        inputButtons[2].GetComponent<Button>().onClick.AddListener(charController.MoveLeft);
        inputButtons[3].GetComponent<Button>().onClick.AddListener(charController.MoveRight);
        inputButtons[4].GetComponent<Button>().onClick.AddListener(charController.StopMovement);
    }

    public void RemoveMovementListeners()
    {
        inputButtons[0].GetComponent<Button>().onClick.RemoveListener(charController.MoveUp);
        inputButtons[1].GetComponent<Button>().onClick.RemoveListener(charController.MoveDown);
        inputButtons[2].GetComponent<Button>().onClick.RemoveListener(charController.MoveLeft);
        inputButtons[3].GetComponent<Button>().onClick.RemoveListener(charController.MoveRight);
        inputButtons[4].GetComponent<Button>().onClick.RemoveListener(charController.StopMovement);
    }

    public void AddInteractionListeners()
    {
        inputButtons[0].GetComponent<Button>().onClick.AddListener(Response1);
        inputButtons[1].GetComponent<Button>().onClick.AddListener(Response2);
    }
    public void RemoveInteractionListeners()
    {
        inputButtons[0].GetComponent<Button>().onClick.RemoveListener(Response1);
        inputButtons[1].GetComponent<Button>().onClick.RemoveListener(Response2);
    }
    public void Response1()
    {
        dialogMgr.ProgessToChosenResponse(0);
    }
    public void Response2()
    {
        dialogMgr.ProgessToChosenResponse(1);
    }
}





//not in use at this time
//[Serializable]
//public class MovementControl : ControlMode
//{
//    private void Debuggg()
//    {
//        Debug.Log("button call made to control node");
//    }
//    readonly ImprovedCharacterController charController;

//    /// <summary>
//    /// Initializes a new instance of the <see cref="MovementControl"/> class.
//    /// </summary>
//    /// <param name="owner">The GameObject that owns this control mode.</param>
//    /// <param name="onUp">Action to be invoked when the "Up" direction is activated.</param>
//    /// <param name="onDown">Action to be invoked when the "Down" direction is activated.</param>
//    /// <param name="onLeft">Action to be invoked when the "Left" direction is activated.</param>
//    /// <param name="onRight">Action to be invoked when the "Right" direction is activated.</param>
//    /// <param name="onButtonReleased">Event invoked when the button is released.</param>
//    public MovementControl(GameObject owner, Button up, Button Down, Button Left, Button right)
//    {
//        charController = GO_Owner.GetComponent<ImprovedCharacterController>();
//    }

//}

//[Serializable]
//public class InteractionControl : ControlMode
//{
//    //the dialog system will interface here through the player as well
//    //dialog comp


//}
