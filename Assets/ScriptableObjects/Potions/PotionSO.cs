using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotionType
{
    Love,
    Strength,
    Poison,
    Health
}

[CreateAssetMenu(fileName = "Potion", menuName = "Inventory/Potion")]
public class PotionSO : ScriptableObject
{
    public string potionName;
    public Sprite potionSprite;
    public PotionType potionType;

    public IngredientType ingredientOne;
    public IngredientType ingredientTwo;

    public void StatePotionName()
    {
        if (potionType == PotionType.Health)
        {
            Debug.Log("Health pot created");
        }
        else if (potionType == PotionType.Love)
        {
            Debug.Log("Love pot created");
        }
        else if (potionType == PotionType.Poison)
        {
            Debug.Log("Poison pot created");
        }
        else if (potionType == PotionType.Strength)
        {
            Debug.Log("Strength pot created");
        }
    }
}
