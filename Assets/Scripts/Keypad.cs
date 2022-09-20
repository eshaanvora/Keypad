using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public KeypadBackground Background;

    private Combination combination;
    private List<int> buttonsEntered;

    // Start is called before the first frame update
    void Start()
    {
        combination = new Combination();
        ResetButtonEntries();
    }

    private void ResetButtonEntries()
    {
        buttonsEntered = new List<int>();
    }

    public void RegisterButtonClick(int buttonNumber)
    {
        //Remember which button was clicked
        //print("Keypad recieved:" + buttonNumber);
        buttonsEntered.Add(buttonNumber);
        print(string.Join(", ", buttonsEntered));

    }

    public void TryToUnlock()
    {
        if (IsCorrectCombination())
            Unlock();
        else
            FailToUnlock();

        //Reset button entered by clearing list
        ResetButtonEntries();
    }

    private bool IsCorrectCombination()
    {
        //things to do
        if (HaveNoButtonsBeenClicked())
            return false;

        if (HaveWrongNumberOfButtonsBeenClicked())
            return false;


        //if we clicked the wrong number of buttons
            //false

        return CheckCombination();
    }

    private bool HaveNoButtonsBeenClicked()
    {
        if (buttonsEntered.Count == 0)
            return true;
        return false;
    }

    private bool HaveWrongNumberOfButtonsBeenClicked()
    {
        if (buttonsEntered.Count == combination.GetCombinationLength())
            return false;
        return true;
    }

    private bool CheckCombination()
    {
        for (int buttonIndex = 0; buttonIndex < buttonsEntered.Count; buttonIndex++)
        {
            if (IsCorrectButton(buttonIndex) == false)
                return false;
        }

        return true;
    }

    private bool IsCorrectButton(int buttonIndex)
    {
        if (IsWrongEntry(buttonIndex))
            return false;
        return true;
    }

    private bool IsWrongEntry(int buttonIndex)
    {
        if (buttonsEntered[buttonIndex] == combination.GetCombinationDigit(buttonIndex))
            return false;
        return true;
    }

    private void Unlock()
    {
        
        //Make button disapperar
        Background.HideUnlockButton();

        //Change background color to green
        Background.ChangeToSuccessColor();
    }

    private void FailToUnlock()
    {
        Background.ChangeToFailedColor();
        StartCoroutine(ResetBackgroundColor());
    }

    private IEnumerator ResetBackgroundColor()
    {
        yield return new WaitForSeconds(0.5f);

        Background.ChangeToDefaultColor();

    }
}
