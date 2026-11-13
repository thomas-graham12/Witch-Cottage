using System.Collections;
using System.Collections.Generic;
using Cauldron;
using UnityEngine.UI;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private IngredientsSO ingredientObject;
    [SerializeField] private GameObject baseInregientPrefab;
    [SerializeField] CreatePotion createPotion;

    [SerializeField] private InventoryManager inventoryManager;

    // Update is called once per frame
    public void TaskOnClick()
    {
        if (createPotion.ingredientList.Count < 3)
        {
            if (ingredientObject.amount > 0)
            {
                inventoryManager.DecreaseIngredient(ingredientObject);
                baseInregientPrefab.GetComponent<IngredientPrefabStats>().ingredientObject = ingredientObject;
                Instantiate(baseInregientPrefab);
            }
        }
    }
}
