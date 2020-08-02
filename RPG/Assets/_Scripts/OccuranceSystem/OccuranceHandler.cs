using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccuranceHandler : MonoBehaviour
{
     #region Singleton
    private static OccuranceHandler _instance;
    public static OccuranceHandler Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject o = new GameObject("OccuranceHandler");
                OccuranceHandler p = o.AddComponent<OccuranceHandler>();
                _instance = p;  
            }
             return _instance;
        }
    }
    
    #endregion


    [SerializeField]private GameObject cardPrefab;
    public Transform cardSpwanPoint;
    [SerializeField]private List<Occurance> occuranceList= new List<Occurance>();
    private CardLoader cardObject;
    public ChoiceChamber choiceChamber;
    private void Awake()
    {
        _instance=this;
    }
    private void Start()
    {
        LoadNextOccurance();
    }
    public void LoadNextOccurance()
    {
        RemoveOldCardFromScene();
        cardObject = Instantiate(cardPrefab,cardSpwanPoint.position,cardPrefab.transform.rotation).GetComponent<CardLoader>();
        Occurance newOccurance = TakeNextOccurance();
        cardObject.LoadCard(newOccurance.card);
        // LoadChoices
        choiceChamber.LoadChoices(newOccurance.choices);
    }

    private void RemoveOldCardFromScene()
    {
       if(cardObject!= null)
        {
            cardObject.gameObject.GetComponent<Animator>().SetTrigger("Exit");
        }
    }

    public void Choose(Choice choice)
    {
        choice.Consequences();
        if(choice.succesor != null)
        {
            occuranceList.Insert(0,choice.succesor);
        }
        LoadNextOccurance();
    }
    private Occurance TakeNextOccurance()
    {
        if(occuranceList.Count > 0)
        {
            Occurance newOccurance = occuranceList[0];
            occuranceList.RemoveAt(0);
            return newOccurance;
        }
        else
        {
            return null;
        }
    }
}
