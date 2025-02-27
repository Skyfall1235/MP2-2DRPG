using UnityEngine.Events;
public interface IControlMode
{
    // Direction Actions
    protected event UnityAction OnUp;
    protected event UnityAction OnDown;
    protected event UnityAction OnLeft;
    protected event UnityAction OnRight;

    // Method to set the IsHeldDown state
    void SetIsHeldDown(bool value);
    void LinkToActions();
    void DelinkToActions();
}