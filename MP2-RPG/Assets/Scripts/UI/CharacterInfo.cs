
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private TextBox m_textBox;
    public bool allowDialog = false;
    public void AllowDialog()
    {
        allowDialog = true;
    }
    

    public TextBox DialogTextBox { get => m_textBox; }
}
