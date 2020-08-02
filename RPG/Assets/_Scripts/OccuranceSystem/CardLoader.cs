using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardLoader : MonoBehaviour
{
    public Card card;
    public Image art;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI description;
    public bool loadOnStart;
    // Start is called before the first frame update
    void Start()
    {
        if(card != null && loadOnStart)
        {

        art.sprite = card.icon;
        cardName.text = card.cardName;
        description.text = card.description;
        }
    }

    public void LoadCard(Card card)
    {
        art.sprite = card.icon;
        cardName.text = card.cardName;
        description.text = card.description;
    }

   
}
