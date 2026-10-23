using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientPrefabStats : MonoBehaviour
{
    public IngredientsSO ingredientObject;
    
    // Start is called before the first frame update
    void Start()
    {
        name = ingredientObject.ingredientName;
        GetComponentInChildren<SpriteRenderer>().sprite = ingredientObject.ingredientSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
