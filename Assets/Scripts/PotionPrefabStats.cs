using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPrefabStats : MonoBehaviour
{
    public PotionSO potionObject;
    
    // Start is called before the first frame update
    void Start()
    {
        name = potionObject.potionName;
        GetComponentInChildren<SpriteRenderer>().sprite = potionObject.potionSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
