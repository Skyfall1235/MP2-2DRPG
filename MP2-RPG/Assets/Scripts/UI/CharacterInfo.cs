
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private TextBox m_textBox;

    public TextBox DialogTextBox { get => m_textBox; }
}
