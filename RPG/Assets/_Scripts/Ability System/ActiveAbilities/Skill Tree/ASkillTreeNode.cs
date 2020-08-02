using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ASkillTreeNode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ASkillTreeRow parentRow;
    [SerializeField]
    private ActiveAbility ability;
    [SerializeField]
    private Image iconHolder;
    [SerializeField]
    private Image fillImage;
    [SerializeField]
    private Sprite unlockedSprite;
    [SerializeField]
    private Sprite activatedSprite;
    private Sprite normalSprite;
    [SerializeField]
    private GameObject shade;
    private RectTransform rectTransform;

    public bool Locked { get; private set; } = true;
    private bool activated = false;
    public bool levelLocked = true;

    private static ASkillTreeNode inUse = null;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRow = transform.parent.GetComponent<ASkillTreeRow>();
        if (ability != null)
        {
            iconHolder.sprite = ability.icon;
        }
        normalSprite = fillImage.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetClicked()
    {
        if(!levelLocked)
        {
            if (Locked)
            {
                Unlock();
            }
            else if (!Locked)
            {
                Activate();
            }
        }
    }

    private void Unlock()
    {
        Locked = false;
        fillImage.sprite = unlockedSprite;
        parentRow.ShadeOutLocked();
    }

    private void Activate()
    {
        if (inUse != null)
        {
            //shitty line
            inUse.fillImage.sprite = unlockedSprite;
            inUse.activated = false;
        }
        inUse = this;
        activated = true;
        Player.Instance.activeAbility = ability;
        fillImage.sprite = activatedSprite;
    }

    public void UnlockBecauseLevel()
    {
        levelLocked = false;
        shade.SetActive(false);
    }
    public void ResetNode()
    {
        levelLocked = true;
        Locked = true;
        if(activated)
        {
            inUse = null;
            activated = false;
            Player.Instance.activeAbility = null;
        }
        shade.SetActive(true);
        fillImage.sprite = normalSprite;
    }

    public void ShadeOut()
    {
        shade.SetActive(true);
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
