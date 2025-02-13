using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : MonoBehaviour
{
    private void Awake()
    {

    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    [Serializable]
    public class InputDatum
    {
        [SerializeField]
        private bool active;
        public bool ActiveState
        {
            get { return active; }
            set { active = value; }
        }

        [SerializeField]
        private Vector2 direction;
        public Vector2 DirectionOfTap
        {
            get
            {
                if (ActiveState)
                {
                    return direction;
                }
                return Vector2.zero;
            }
            set { direction = value; }
        }
    }

    public class NewInputEvent : UnityEvent<InputDatum> { }
    public NewInputEvent inputEvent = new NewInputEvent();

    Vector2 CalculateDirectionOfTapFromCenterPoint(Vector2 centerPoint, Vector2 tapLocation)
    {
        Vector2 direction = tapLocation - centerPoint;

        if (direction == Vector2.zero)
        {
            return Vector2.zero;
        }

        return direction.normalized;
    }

}
