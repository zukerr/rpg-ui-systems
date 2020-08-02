using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSkillTreeRow : MonoBehaviour
{
    [SerializeField]
    private PSkillTreeNode[] nodes;

    private PSkillTree parentTree;

    public bool Locked { get; private set; } = true;

    private int rowPotency = 0;
    public int RowPotency { get { return rowPotency; } }

    // Start is called before the first frame update
    void Start()
    {
        parentTree = transform.parent.parent.GetComponent<PSkillTree>();
        //ReadRow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseRowPotency()
    {
        rowPotency++;
        parentTree.IncreaseTreePotency();
    }

    public void ResetRow()
    {
        rowPotency = 0;
        Locked = true;
        foreach(PSkillTreeNode n in nodes)
        {
            n.ResetNode();
        }
    }

    public void ReadRow()
    {
        rowPotency = 0;
        foreach(PSkillTreeNode n in nodes)
        {
            if(n.gameObject.activeInHierarchy)
            {
                n.ReadNode();
                Debug.Log("Node " + n.Trait.entityName + " has potency of " + n.Trait.CurrentPotency);
                rowPotency += n.Trait.CurrentPotency;
            }
        }
    }

    public void UnlockRow()
    {
        Locked = false;
        foreach(PSkillTreeNode n in nodes)
        {
            if(!n.UnlockedByOther)
            {
                n.Unlock();
            }
            else
            {
                if(n.DependencyMet)
                {
                    n.Unlock();
                }
            }
        }
    }
}
