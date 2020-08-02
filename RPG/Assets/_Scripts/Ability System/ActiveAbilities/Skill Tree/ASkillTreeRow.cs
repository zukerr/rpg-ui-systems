using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASkillTreeRow : MonoBehaviour
{
    [SerializeField]
    private int levelValue;
    [SerializeField]
    private List<ASkillTreeNode> nodes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockRow()
    {
        foreach(ASkillTreeNode node in nodes)
        {
            node.UnlockBecauseLevel();
        }
    }

    public void ResetRow()
    {
        foreach (ASkillTreeNode node in nodes)
        {
            node.ResetNode();
        }
    }

    public void ShadeOutLocked()
    {
        foreach(ASkillTreeNode node in nodes)
        {
            if(node.Locked)
            {
                node.ShadeOut();
                node.levelLocked = true;
            }
        }
    }
}
