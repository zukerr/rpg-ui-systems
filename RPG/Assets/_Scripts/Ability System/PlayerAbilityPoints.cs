using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityPoints
{
    //Basic Ability Points
    public int BP { get; private set; }
    //Active Ability Points
    public int AP { get; private set; }
    //Passive Trait Points
    public int PP { get; private set; }

    public PlayerAbilityPoints()
    {
        BP = 1;
        AP = 0;
        PP = 0;
    }

    public void GainBP()
    {
        BP++;
        UIManager.Instance.GetBasicAttackSkillTree().GetComponent<BASkillTree>().UpdateText();
        UIManager.Instance.GetBasicAttackSkillTree().GetComponent<BASkillTree>().UnlockAllAdjToAcq();
    }
    public void SpendBP()
    {
        if(BP > 0)
        {
            BP--;
            UIManager.Instance.GetBasicAttackSkillTree().GetComponent<BASkillTree>().UpdateText();
            UIManager.Instance.GetBasicAttackSkillTree().GetComponent<BASkillTree>().LockAllAdjToAcq();
            if (BP > 0)
            {   
                UIManager.Instance.GetBasicAttackSkillTree().GetComponent<BASkillTree>().UnlockAllAdjToAcq();
            }
        }
    }
}
