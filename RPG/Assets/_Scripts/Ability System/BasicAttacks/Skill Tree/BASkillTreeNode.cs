using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BASkillTreeNode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private List<BASkillTreeNode> adjList;
    [SerializeField]
    private bool locked = true;
    //public bool Locked { get { return locked; } }
    public BasicAttackAbility ability;
    private Image fill;
    [SerializeField]
    private GameObject insideFrame;
    private Color insideFrameBaseColor;
    private static BASkillTreeNode inUse = null;
    [SerializeField]
    private GameObject shade;
    [SerializeField]
    private Image iconHolder;
    private RectTransform rectTransform;
    public bool Acquired { get; private set; }
    private BASkillTree tree;

    // Start is called before the first frame update
    void Start()
    {
        tree = transform.parent.parent.GetComponent<BASkillTree>();
        tree.RegisterNode(this);
        rectTransform = GetComponent<RectTransform>();
        FailCheck();
        fill = GetComponent<Image>();
        if(!locked)
        {
            shade.SetActive(false);
        }
        if(ability != null)
        {
            iconHolder.sprite = ability.icon;
        }
        SetupTileColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void ChangeColorToUnlocked()
    {
        float H, S, V;
        Color.RGBToHSV(fill.color, out H, out S, out V);
        fill.color = Color.HSVToRGB(H, S, V + 0.3f);
    }
    */

    private void Acquire()
    {
        insideFrame.SetActive(true);
        insideFrameBaseColor = insideFrame.GetComponent<Image>().color;
        if(inUse != null)
        {
            inUse.insideFrame.GetComponent<Image>().color = insideFrameBaseColor;
        }
        inUse = this;
        inUse.insideFrame.GetComponent<Image>().color = Color.yellow;
        if(!Acquired)
        {
            Acquired = true;
            Player.Instance.abilityPoints.SpendBP(); 
        }
    }

    private void FailCheck()
    {
        foreach(BASkillTreeNode node in adjList)
        {
            if(node == null)
            {
                Debug.LogError("Gameobject " + gameObject.name + " in Basic Attack Skill Tree has badly set up adjList from inspector!");
            }
        }
    }

    public void GetClicked()
    {
        if(!locked)
        {
            //UnlockAdj();
            //aquire this ability
            Acquire();
            Player.Instance.basicAttack = ability;
        }
    }

    public void UnlockAdj()
    {
        foreach(BASkillTreeNode node in adjList)
        {
            node.Unlock();
        }
    }

    public void LockAdjNotAcq()
    {
        foreach (BASkillTreeNode node in adjList)
        {
            if(!node.Acquired)
            {
                node.Lock();
            }
        }
    }

    private void Unlock()
    {
        if(locked)
        {
            locked = false;
            //ChangeColorToUnlocked();
            shade.SetActive(false);
        }
    }

    private void Lock()
    {
        if (!locked)
        {
            locked = true;
            //ChangeColorToUnlocked();
            shade.SetActive(true);
        }
    }

    private void SetupTileColor()
    {
        switch(ability.elementType)
        {
            case ElementType.Fire:
                fill.color = Palette.RedGreenBlack32.GetColorByIndex(8);
                break;
            case ElementType.Nature:
                fill.color = Palette.RedGreenBlack32.GetColorByIndex(31);
                break;
            case ElementType.Physical:
                fill.color = Palette.RedGreenBlack32.GetColorByIndex(3);
                break;
            case ElementType.Water:
                fill.color = Palette.RedGreenBlack32.GetColorByIndex(26);
                break;
            case ElementType.Wind:
                fill.color = Palette.RedGreenBlack32.GetColorByIndex(16);
                break;
        }
        
        /*
        float H, S, V;
        Color.RGBToHSV(fill.color, out H, out S, out V);
        fill.color = Color.HSVToRGB(H, S, 0.7f);
        */
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        UIManager.Instance.MoveTooltip(corners[1]);
        UIManager.Instance.SetTooltipText(ability.entityName, ability.description);
        UIManager.Instance.ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.HideTooltip();
    }
}
