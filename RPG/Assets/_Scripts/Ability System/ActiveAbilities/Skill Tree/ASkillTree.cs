using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASkillTree : MonoBehaviour
{
    [SerializeField]
    private ASkillTreeRow[] rows;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockActiveAbilityRow(int level)
    {
        if(level % 5 == 0)
        {
            int rowIndex = (level / 5) - 1;
            rows[rowIndex].ResetRow();
            rows[rowIndex].UnlockRow();
        }
    }

    private int level = 5;
    public void TestFunction()
    {
        UnlockActiveAbilityRow(level);
        level += 5;
    }
}
