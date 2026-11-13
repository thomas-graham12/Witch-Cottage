using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Ingredient Amounts

    public void DecreaseIngredient(IngredientsSO ingredientsSO)
    {
        if (ingredientsSO.amount > 0)
        {
            ingredientsSO.amount--;
        }
    }
}
