using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RuneColorChanger : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> m_runes;
    [SerializeField] float m_lerpSpeed = 3f;

    public UnityEvent<bool> StateOfActivation = new UnityEvent<bool>();

    private Color m_curColor;
    private Color m_targetColor;

    private void Awake()
    {
        m_targetColor = m_runes[0].color;
    }

    protected void BeginColorChange(Collider2D other)
    {
        m_targetColor.a = 1.0f;
        StateOfActivation.Invoke(true);
    }

    protected void EndColorChange(Collider2D other)
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
}
