using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType
{
    Toad,
    Mushroom,
    Lavender,
    EyeOfNewt
}

[CreateAssetMenu(fileName = "Ingredient", menuName = "Inventory/Ingredient")]
public class IngredientsSO : ScriptableObject
{
    public string ingredientName;
    public Sprite ingredientSprite;
    public IngredientType ingredientType;
}
