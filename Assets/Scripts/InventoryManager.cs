using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Ingredient Amounts

    private List<IngredientsSO> _spawnedIngredients = new List<IngredientsSO>();

    public void DecreaseIngredient(IngredientsSO ingredientsSO)
    {
        if (ingredientsSO.amount > 0)
        {
            ingredientsSO.amount--;
        }
    }

    public List<IngredientsSO> GetSpawnedIngredients()
    {
        return _spawnedIngredients;
    }

    public void AddSpawnedIngredient(IngredientsSO spawnedIngredient)
    {
        _spawnedIngredients.Add(spawnedIngredient);
    }
}
