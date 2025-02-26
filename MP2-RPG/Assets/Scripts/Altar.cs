using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Altar : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> m_runes;
    [SerializeField] float m_lerpSpeed = 3f;
    [SerializeField] string m_keyTag;

    public UnityEvent<bool> StateOfActivation = new UnityEvent<bool>();

    private Color m_curColor;
    private Color m_targetColor;

    private void Awake()
    {
        m_targetColor = m_runes[0].color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckIfKeyIsColliding(other))
        {
            m_targetColor.a = 1.0f;
            StateOfActivation.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        m_targetColor.a = 0.0f;
        StateOfActivation.Invoke(false);
    }

    private void Update()
    {
        m_curColor = Color.Lerp(m_curColor, m_targetColor, m_lerpSpeed * Time.deltaTime);

        foreach (var r in m_runes)
        {
            r.color = m_curColor;
        }
    }

    /// <summary>
    /// Checks if the colliding object has the specified key tag.
    /// </summary>
    /// <param name="collider">The Collider2D to check.</param>
    /// <returns>True if the collider's GameObject has the key tag, false otherwise.</returns>
    private bool CheckIfKeyIsColliding(Collider2D collider)
    {
        //compare object to confirm tag recognition
        if (collider != null && collider.gameObject != null)
        {
            return collider.gameObject.tag == m_keyTag;
        }
        return false;
    }
}
