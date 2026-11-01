using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cauldron
{
    public class CreatePotion : MonoBehaviour
    {
        public IngredientType ingredientOne;
        public IngredientType ingredientTwo;
        [SerializeField] private List<PotionSO> potionList;
        private List<Dictionary<IngredientType, IngredientType>> _potionRecipes;
        public int count = 0;

        private void Start()
        {
            _potionRecipes = new List<Dictionary<IngredientType, IngredientType>>();
            
            
            for (int i = 0; i < potionList.Count; i++)
            {
                Dictionary<IngredientType, IngredientType> recipe = new Dictionary<IngredientType, IngredientType>();
                
                recipe.Add(potionList[i].ingredientOne, potionList[i].ingredientTwo);
                
                _potionRecipes.Add(recipe);
            }

            // for (int i = 0; i < _potionRecipes.Count; i++)
            // {
            //     var first = _potionRecipes[i].First();
            //     
            //     Debug.Log($"First: {first.Key}, {first.Value}");
            // }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.TryGetComponent(out IngredientPrefabStats stats))
            {
                if (ingredientOne == IngredientType.None)
                {
                    ingredientOne = stats.ingredientObject.ingredientType;
                }
                else
                {
                    ingredientTwo = stats.ingredientObject.ingredientType;
                }
            }
            
            if (ingredientOne != IngredientType.None && ingredientTwo != IngredientType.None)
            {
                Debug.Log(ingredientOne);
                Debug.Log(ingredientTwo);

                DispensePotion();
                
                ingredientOne = IngredientType.None;
                ingredientTwo = IngredientType.None;
            }
        }

        private void DispensePotion()
        {
            bool bFoundPotionRecipe = false;
            for (int i = 0; i < potionList.Count; i++)
            {
                if ((ingredientOne == potionList[i].ingredientOne && ingredientTwo == potionList[i].ingredientTwo) 
                    || (ingredientOne == potionList[i].ingredientTwo && ingredientTwo == potionList[i].ingredientOne))
                {
                    bFoundPotionRecipe = true;
                    potionList[i].StatePotionName();
                    Debug.Log("Yay!");
                    count++;
                }
            }

            if (!bFoundPotionRecipe)
            {
                Debug.Log("Recipe was not found");
            }
        }
    }
}
