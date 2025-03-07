using UnityEngine;

public class DialogManager : MonoBehaviour
{
    //search the area around thep layer, if he hits an object that is a char info, put it on screen and wait
    //drive dialog through the buttons?
    public Transform textbox;
    [SerializeField] ButtonControlSchema buttonControls;
    private TextBox currentTextBox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterInfo info = collision.GetComponent<CharacterInfo>();
        //check for the character script, if found, load the camera and change the input managemr
        if (info != null)
        {
            if(info.allowDialog != true)
            {
                return;
            }
            currentTextBox = info.DialogTextBox;
            //place it on screen
            DisplayTextBoxWithInfo(info);
            //turn off movement
            buttonControls.StopMovement();
            buttonControls.RemoveMovementListeners();
            buttonControls.AddInteractionListeners();
        }
    }

    private void DisplayTextBoxWithInfo(CharacterInfo info)
    {
        textbox.gameObject.SetActive(true);
        info.DialogTextBox.PopulateTextBoxPrefab(textbox.gameObject);
    }

    public void ProgessToChosenResponse(int chosenResponse)
    {
        if (currentTextBox.Options.Length == 0)
        {
            EndDialog();
        }
        //text box does not move correctly
        //currentTextBox = info.DialogTextBox;
        DialogOption optionToUse = currentTextBox.Options[chosenResponse];
        TextBox nextOption = optionToUse.NextOption;
        nextOption.PopulateTextBoxPrefab(textbox.gameObject);
    }

    public void EndDialog()
    {
        textbox.gameObject.SetActive(false);
        buttonControls.RemoveInteractionListeners();
        buttonControls.AddMovementListeners();
    }
}
