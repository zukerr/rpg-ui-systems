using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceChamber : MonoBehaviour
{
    public ChoiceSlot[] choiceSlots;
    public Animator anim;
    private Choice[] choicesToLoad;
    public void LoadChoices(Choice[] choices)
    {
        choicesToLoad = choices;
        anim.SetTrigger("Hide");
    }
    public void Load()
    {
         for (int i = 0; i < choicesToLoad.Length; i++)
         {
            choiceSlots[i].gameObject.SetActive(true);
            choiceSlots[i].SetChoice(choicesToLoad[i]);
         }
         for (int i = choicesToLoad.Length; i < choiceSlots.Length; i++)
         {
            choiceSlots[i].SetChoice(null);
            choiceSlots[i].gameObject.SetActive(false);
         }
    }

}
