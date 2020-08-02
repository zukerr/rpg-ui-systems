using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BASkillTree : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textHolder;

    private List<BASkillTreeNode> nodes;

    // Start is called before the first frame update
    void Awake()
    {
        nodes = new List<BASkillTreeNode>();
        
    }

    private void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterNode(BASkillTreeNode node)
    {
        nodes.Add(node);
    }
    public void UpdateText()
    {
        textHolder.text = "Points left: " + Player.Instance.abilityPoints.BP.ToString();
    }
    public void UnlockAllAdjToAcq()
    {
        foreach (BASkillTreeNode node in nodes)
        {
            if(node.Acquired)
            {
                node.UnlockAdj();
            }
        }
    }
    public void LockAllAdjToAcq()
    {
        foreach (BASkillTreeNode node in nodes)
        {
            if (node.Acquired)
            {
                node.LockAdjNotAcq();
            }
        }
    }
    public void OnClickGainBP()
    {
        Player.Instance.abilityPoints.GainBP();
    }
}
