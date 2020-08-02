using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tooltip;
    [SerializeField]
    private GameObject basicAttackSkillTree;

    public static UIManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    //Tooltip
    public void ShowTooltip()
    {
        tooltip.SetActive(true);
    }
    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }
    public void MoveTooltip(Vector3 position)
    {
        tooltip.transform.position = position;
    }
    public void SetTooltipText(string text)
    {
        tooltip.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
    }
    public void SetTooltipText(string name, string description)
    {
        SetTooltipText(name + "\n" + description);
    }
    public GameObject GetBasicAttackSkillTree()
    {
        return basicAttackSkillTree;
    }
}
