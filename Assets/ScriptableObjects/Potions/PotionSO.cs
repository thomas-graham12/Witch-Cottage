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
}
