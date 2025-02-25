using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Altar : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> runes;
    [SerializeField] public float lerpSpeed = 3f;
    [SerializeField] string KeyTag;

    public UnityEvent<bool> StateOfActivation = new UnityEvent<bool>();

    private Color curColor;
    private Color targetColor;

    private void Awake()
    {
        targetColor = runes[0].color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckIfKeyIsColliding(other))
        {
            targetColor.a = 1.0f;
            StateOfActivation.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        targetColor.a = 0.0f;
        StateOfActivation.Invoke(false);
    }

    private void Update()
    {
        curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

        foreach (var r in runes)
        {
            r.color = curColor;
        }
    }

    private bool CheckIfKeyIsColliding(Collider2D collider)
    {
        if (collider != null && collider.gameObject != null)
        {
            return collider.gameObject.tag == KeyTag;
        }
        return false;
    }
}
