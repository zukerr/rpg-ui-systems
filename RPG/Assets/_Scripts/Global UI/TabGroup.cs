using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    private List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;
    public void Subscribe(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons= new List<TabButton>();
        }

        tabButtons.Add(button);
    }
    
    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }
    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
        {
            button.background.sprite=tabHover;  
        }
    }
    public void OnTabSelected(TabButton button)
    {
        if(selectedTab != null)
        {
            selectedTab.Deselect();
        }
        selectedTab = button;
        selectedTab.Select();
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if(i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }
    public void ResetTabs()
    {
        foreach (var item in tabButtons)
        {
            if(selectedTab!=null && item == selectedTab){continue; }
            item.background.sprite = tabIdle;
        }
    }
    
}
