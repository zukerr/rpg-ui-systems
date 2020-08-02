using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceSlot : MonoBehaviour
{
    Choice choice;
    TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void Choose()
    {
        OccuranceHandler.Instance.Choose(choice);
    }
    public void SetChoice(Choice choice)
    {
        this.choice = choice;
        text.text = choice == null ? "" :choice.text;
    }
}
