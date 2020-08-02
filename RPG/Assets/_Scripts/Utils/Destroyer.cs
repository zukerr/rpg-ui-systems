using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destroyTime=0f;
    // Start is called before the first frame update
    void Start()
    {
        if(destroyTime>0)Destroy(gameObject,destroyTime);
    }

    public void DestroyNow()
    {
        Destroy(gameObject);
    }
}
