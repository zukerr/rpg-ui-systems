using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum PNodeStatus
{
    Locked,
    Unlocked,
    Maxed
}

public class PSkillTreeNode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI potencyText;
    [SerializeField]
    private GameObject shade;
    [SerializeField]
    private Image iconHolder;
    private RectTransform rectTransform;

    [SerializeField]
    private PassiveTrait trait;
    public PassiveTrait Trait { get { return trait; } }
    [SerializeField]
    private bool unlockedByOther = false;
    public bool UnlockedByOther { get { return unlockedByOther; } }
    [SerializeField]
    private bool unlocksOther = false;
    [SerializeField]
    private PSkillTreeNode[] dependentNode;

    public PSkillTreeRow ParentRow { get; private set; }
    private bool dependencyMet = false;
    public bool DependencyMet { get { return dependencyMet; } }


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        SetupParentRow();
        UpdatePotencyText();
        if (unlocksOther)
        {
            if(dependentNode.Length == 0)
            {
                Debug.LogError("PSkillTreeNode does not have assigned dependent node, but it unlocks other!");
            }
        }
        iconHolder.sprite = trait.icon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetClicked()
    {
        if(trait.Status == PNodeStatus.Unlocked)
        {
            IncreasePotency();
        }
    }

    public void ResetNode()
    {
        trait.Status = PNodeStatus.Locked;
        shade.SetActive(true);
        trait.CurrentPotency = 0;
        trait.OnReset();
        UpdatePotencyText();
        if(unlocksOther)
        {
            dependentNode[0].dependencyMet = false;
            dependentNode[0].trait.Status = PNodeStatus.Locked;
            dependentNode[0].shade.SetActive(true);
        }
    }

    public void ReadNode()
    {
        if ((trait.Status == PNodeStatus.Maxed) || (trait.Status == PNodeStatus.Unlocked))
        {
            shade.SetActive(false);
        }
        if (trait.Status == PNodeStatus.Maxed)
        {
            UnlockDependentNode();
        }
    }

    public void Unlock()
    {
        trait.Status = PNodeStatus.Unlocked;
        shade.SetActive(false);
    }

    private void IncreasePotency()
    {
        if(trait.CurrentPotency < trait.maxPotency)
        {
            trait.CurrentPotency++;
            ParentRow.IncreaseRowPotency();
            UpdatePotencyText();
            trait.OnPotencyIncrease();
            if (trait.CurrentPotency == trait.maxPotency)
            {
                trait.Status = PNodeStatus.Maxed;
                UnlockDependentNode();
            }
        }
    }

    private void UnlockDependentNode()
    {
        if (unlocksOther)
        {
            dependentNode[0].dependencyMet = true;
            dependentNode[0].SetupParentRow();
            if (dependentNode[0].ParentRow.Locked == false)
            {
                dependentNode[0].Unlock();
            }
        }
    }

    private void SetupParentRow()
    {
        ParentRow = transform.parent.GetComponent<PSkillTreeRow>();
    }

    private void UpdatePotencyText()
    {
        if(trait != null)
        {
            potencyText.text = trait.CurrentPotency + "/" + trait.maxPotency;
        }
        else
        {
            potencyText.text = "TBD";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        UIManager.Instance.MoveTooltip(corners[1]);
        UIManager.Instance.SetTooltipText(trait.entityName, trait.description);
        UIManager.Instance.ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.HideTooltip();
    }
}
