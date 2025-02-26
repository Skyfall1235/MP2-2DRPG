using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Character", menuName = "Dialog/Character")]
[System.Serializable]
public class DialogCharacter : ScriptableObject
{
    [SerializeField] private string m_characterName;
    [SerializeField] private Sprite m_boxSprite; // Sprite for the background of the text box
    [SerializeField] private Font m_font; // is optional, but a font change per character?

    public DialogCharacter(string characterName, Sprite boxSprite, Font font)
    {
        m_characterName = characterName;
        m_boxSprite = boxSprite;
        if (font != null)
        {
            m_font = font;
        }
    }

    public Sprite BoxSprite { get => m_boxSprite; }
    public Font Font { get => m_font; }
    public string CharacterName { get => m_characterName; }
}

[System.Serializable]
public struct DialogOption
{
    [SerializeField] private string m_responseText;
    [SerializeField] private TextBox m_nextOption;
    [SerializeField] private UnityEvent m_activateNextTextBox;

    public string ResponseText { get => m_responseText; }
    public TextBox NextOption { get => m_nextOption; }
    public UnityEvent ActivateNextTextBox { get => m_activateNextTextBox; }


    /// <summary>
    /// Initializes a new instance of the <see cref="DialogOption"/> struct.
    /// </summary>
    /// <param name="dialogText">The text displayed for the dialog option</param>
    /// <param name="nextOption">The next TextBox to display if this option is chosen</param>
    /// <param name="activateNextTextBox">A UnityEvent to invoke when this option is selected</param>
    public DialogOption(string dialogText, TextBox nextOption, UnityEvent activateNextTextBox)
    {
        m_responseText = dialogText;
        m_nextOption = nextOption;
        m_activateNextTextBox = activateNextTextBox;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogOption"/> struct without a UnityEvent
    /// </summary>
    /// <param name="dialogText">The text displayed for the dialog option</param>
    /// <param name="nextOption">The next TextBox to display if this option is chosen</param>
    public DialogOption(string dialogText, TextBox nextOption)
    {
        m_responseText = dialogText;
        m_nextOption = nextOption;
        m_activateNextTextBox = new UnityEvent();
    }
}