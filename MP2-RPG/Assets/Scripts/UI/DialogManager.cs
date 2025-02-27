using UnityEngine;

public class DialogManager : MonoBehaviour
{
    //search the area around thep layer, if he hits an object that is a char info, put it on screen and wait
    //2 options for the player, using standard buttons see through (ttogle on and off when chatting, maybe use a nuified script to control buttons and reuse movement?) 
    //drive dialog through the buttons
    public Transform textbox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check for the character script, if found, load the camera and change the input managemr
    }
    private void RetrieveTextBoxInfoFromCharacter(CharacterInfo info)
    {

    }
    void SwapModeOfControl()
    {

    }
    private void DisplayTextBoxWithInfo(CharacterInfo info)
    {
        textbox.gameObject.SetActive(true);
        info.DialogTextBox.PopulateTextBoxPrefab(textbox.gameObject);
    }
}
