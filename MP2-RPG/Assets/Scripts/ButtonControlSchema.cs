using System;
using System.Buffers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonControlSchema : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        ModeInUse.SetIsHeldDown(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ModeInUse.SetIsHeldDown(true);
    }

    //list all the buttons, and different events that we plan to listen to

    public ControlMode ModeInUse;

    public IControlMode[] ControlModes = new IControlMode[1]; // 0 is movement, 1 is interaction
    //public method to toggle modes, and swap them out as needed
    public void SwitchControlMode(int mode)
    {
        //reset the button config requiring a release, and then switch over
        if(ModeInUse != null)
        {
            ModeInUse?.SetIsHeldDown(false);
            ModeInUse?.DelinkToActions();
        }
        ModeInUse = (ControlMode)ControlModes[mode];
        ModeInUse.LinkToActions();
        ModeInUse.GO_Owner = transform.gameObject;
    }
}

//have 2 modes to toggle between for input, movement and interaction.
public class ControlMode : IControlMode
{
    public GameObject GO_Owner;
    protected UnityAction OnUp;
    protected UnityAction OnDown;
    protected UnityAction OnLeft;
    protected UnityAction OnRight;
    private bool m_isHeldDown;

    #region unity action links
    event UnityAction IControlMode.OnUp
    {
        add { OnUp += value; }
        remove {OnUp -= value; }
    }

    event UnityAction IControlMode.OnDown
    {
        add { OnDown += value; }
        remove { OnDown -= value; }
    }

    event UnityAction IControlMode.OnLeft
    {
        add { OnLeft += value; }
        remove { OnLeft -= value; }
    }

    event UnityAction IControlMode.OnRight
    {
        add { OnRight += value; }
        remove { OnRight -= value; }
    }
    #endregion 

    // Bool to track if the button is held down
    /// <summary>
    /// Gets the current state of whether the button is held down.
    /// </summary>
    /// <returns>True if held down, false otherwise.</returns>
    public bool GetIsHeldDown()
    {
        return m_isHeldDown;
    }

    /// <summary>
    /// Sets the state of whether the button is held down.
    /// </summary>
    /// <param name="value">The new state.</param>
    public void SetIsHeldDown(bool value)
    {
        m_isHeldDown = value;
        if (!value)
        {
            OnButtonReleased.Invoke();
        }
    }

    #region for error handling when using a new control node type
    /// <summary>
    /// Links the control mode's actions to the appropriate methods.
    /// </summary>
    public virtual void LinkToActions()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Delinks the control mode's actions from the appropriate methods.
    /// </summary>
    public virtual void DelinkToActions()
    {
        OnUp = null;
        OnDown = null;
        OnLeft = null;
        OnRight = null;
    }
    #endregion

    /// <summary>
    /// Event invoked when the button is released.
    /// </summary>
    public UnityEvent OnButtonReleased = new UnityEvent();

    /// <summary>
    /// Initializes a new instance of the <see cref="ControlMode"/> class.
    /// </summary>
    /// <param name="owner">The GameObject that owns this control mode.</param>
    /// <param name="onUp">Action to be invoked when the "Up" direction is activated.</param>
    /// <param name="onDown">Action to be invoked when the "Down" direction is activated.</param>
    /// <param name="onLeft">Action to be invoked when the "Left" direction is activated.</param>
    /// <param name="onRight">Action to be invoked when the "Right" direction is activated.</param>
    /// <param name="onButtonReleased">Event invoked when the button is released.</param>
    public ControlMode(GameObject owner, UnityAction onUp, UnityAction onDown, UnityAction onLeft, UnityAction onRight, UnityEvent onButtonReleased)
    {
        GO_Owner = owner;
        OnUp = onUp;
        OnDown = onDown;
        OnLeft = onLeft;
        OnRight = onRight;
        OnButtonReleased = onButtonReleased;
    }
}
public class MovementControl : ControlMode
{
    ImprovedCharacterController charController;

    /// <summary>
    /// Initializes a new instance of the <see cref="MovementControl"/> class.
    /// </summary>
    /// <param name="owner">The GameObject that owns this control mode.</param>
    /// <param name="onUp">Action to be invoked when the "Up" direction is activated.</param>
    /// <param name="onDown">Action to be invoked when the "Down" direction is activated.</param>
    /// <param name="onLeft">Action to be invoked when the "Left" direction is activated.</param>
    /// <param name="onRight">Action to be invoked when the "Right" direction is activated.</param>
    /// <param name="onButtonReleased">Event invoked when the button is released.</param>
    public MovementControl(GameObject owner, UnityAction onUp, UnityAction onDown, UnityAction onLeft, UnityAction onRight, UnityEvent onButtonReleased) : base(owner, onUp, onDown, onLeft, onRight, onButtonReleased)
    {
        charController = GO_Owner.GetComponent<ImprovedCharacterController>();
    }

    /// <summary>
    /// Links the movement control's actions to the ImprovedCharacterController methods.
    /// </summary>
    public override void LinkToActions()
    {
        OnUp = charController.MoveUp;
        OnDown = charController.MoveDown;
        OnLeft = charController.MoveLeft;
        OnRight = charController.MoveRight;
    }
}
public class InteractionControl : ControlMode
{
    //the dialog system will interface here through the player as well
    //dialog comp
    public InteractionControl(GameObject owner, UnityAction onUp, UnityAction onDown, UnityAction onLeft, UnityAction onRight, UnityEvent onButtonReleased) : base(owner, onUp, onDown, onLeft, onRight, onButtonReleased)
    {
        // Comp = GO_Owner.GetComponent< DIALOG COMP >();
    }
    public override void LinkToActions()
    {
        //OnUp =
        //OnDown =
        //OnLeft =
        //OnRight =
    }
}
