using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Altar : RuneColorChanger
{
    [SerializeField] string m_keyTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckIfKeyIsColliding(other))
        {
            BeginColorChange(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EndColorChange(other);
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
