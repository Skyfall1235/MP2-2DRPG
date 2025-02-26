using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TextBox", menuName = "Dialog/TextBox")]
[System.Serializable]
public class TextBox : ScriptableObject
{
    [SerializeField] private DialogCharacter m_characterInfo;

    [Header("Timing")]
    [SerializeField] private float m_displayDuration = 3f; // Duration the text box stays on screen

    [Header("Content")]
    [TextArea(3, 10)] // Allows for multi-line text in the inspector
    [SerializeField] private string m_dialogueText; // The text to display
    [SerializeField] private DialogOption[] options = new DialogOption[4];
    
    public float DisplayDuration { get => m_displayDuration;}
    public string DialogueText { get => m_dialogueText;}
    public DialogOption[] Options { get => options; set => options = value; }
    public DialogCharacter CharacterInfo { get => m_characterInfo; }


    /// <summary>
    /// Initializes a new instance of the <see cref="TextBox"/> class.
    /// </summary>
    /// <param name="boxSprite">The sprite to use as the background for the text box</param>
    /// <param name="displayDuration">The duration, in seconds, that the text box should be displayed</param>
    /// <param name="dialogueText">The text content to display within the text box</param>
    /// <param name="options">An array of DialogOptions representing possible choices for the player</param>
    /// <param name="font">A default font is used, but can be populated with a custom font</param>
    public TextBox(float displayDuration, string dialogueText, DialogOption[] options)
    {
        m_displayDuration = displayDuration;
        m_dialogueText = dialogueText;
        Options = options;      
    }

    public void PopulateTextBoxPrefab(GameObject textObjectRoot)
    {
        //this is just to set up the dialog box, not to pup
        Image characterSprite = textObjectRoot.GetComponentInChildren<Image>();
        Text DialogText = textObjectRoot.GetComponentInChildren<Text>();
        characterSprite.sprite = m_characterInfo.BoxSprite;
        DialogText.font = m_characterInfo.Font;
        DialogText.text = m_dialogueText;   
    }
}