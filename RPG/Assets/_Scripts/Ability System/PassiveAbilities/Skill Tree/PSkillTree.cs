using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSkillTree : MonoBehaviour
{
    [SerializeField]
    private PSkillTreeRow[] rows;

    private int treePotency;

    // Start is called before the first frame update
    void Start()
    {
        StartPassiveTree();
        ReadTree();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseTreePotency()
    {
        treePotency++;
        UnlockRowAccordingly();
    }

    public void ResetTree()
    {
        treePotency = 0;
        foreach(PSkillTreeRow r in rows)
        {
            r.ResetRow();
        }
        StartPassiveTree();
    }

    public void ReadTree()
    {
        treePotency = 0;
        foreach (PSkillTreeRow r in rows)
        {
            r.ReadRow();
            Debug.Log("Row potency: " + r.RowPotency);
            for(int i = 0; i < r.RowPotency; i++)
            {
                IncreaseTreePotency();
            }
        }
        Debug.Log("Tree potency: " + treePotency);
    }

    public void StartPassiveTree()
    {
        rows[0].UnlockRow();
    }

    private void UnlockRowAccordingly()
    {
        if (treePotency <= 25)
        {
            if (treePotency % 5 == 0)
            {
                int rowIndex = treePotency / 5;
                rows[rowIndex].UnlockRow();
            }
        }
    }
}
