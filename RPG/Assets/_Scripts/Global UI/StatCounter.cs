using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Kryz.CharacterStats;

public class StatCounter : MonoBehaviour
{
    TextMeshProUGUI text;
    public StatAtribute statAribute;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        CharacterStat stat = Player.Instance.character.GetStat(statAribute);
        stat.OnStatChanged+=UpdateCounter;
        UpdateCounter(stat.Value);
    }

    public void UpdateCounter(float newVal)
    {
        text.text = newVal.ToString();
    }

    
}
