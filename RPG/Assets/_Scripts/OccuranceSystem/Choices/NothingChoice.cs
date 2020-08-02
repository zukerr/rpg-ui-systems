using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Choice/Nothing")]
public class NothingChoice : Choice
{
    public override void Consequences()
    {
        Debug.Log("I did nothing...");
    }
}
