using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Cauldron
{
    public class CreatePotion : MonoBehaviour
    {
        public IngredientType ingredientOne;
        public IngredientType ingredientTwo;
        public List<IngredientType> ingredientList;
        [SerializeField] private List<PotionSO> potionList;
        [SerializeField] private PotionSO currentPotion;
        [SerializeField] private OrderManager orderManager;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.TryGetComponent(out IngredientPrefabStats stats))
            {
                ingredientList.Add(stats.ingredientObject.ingredientType);
            }
        }

        public void BrewPotion()
        {
            bool bFoundPotion = false;
            currentPotion = null;
            
            List<IngredientType> includedIngredients = new List<IngredientType>();
            for (int i = 0; i < potionList.Count; i++)
            {
                includedIngredients.Clear();
                for (int j = 0; j < potionList[i].recipe.Count; j++)
                {
                    includedIngredients.Add(potionList[i].recipe[j]);
                }

                if (ingredientList.Count == includedIngredients.Count)
                {
                    if (ingredientList.OrderBy(x => x).SequenceEqual(includedIngredients.OrderBy(x => x)))
                    {
                        currentPotion = potionList[i];
                        bFoundPotion = true;
                        break;
                    }
                }
            }

            if (bFoundPotion)
            {
                StartCoroutine(orderManager.IIsPotionCorrect(currentPotion));
            }
            else
            {
                currentPotion = potionList[potionList.Count - 1];
                StartCoroutine(orderManager.IIsPotionCorrect(currentPotion));
            }
            
            ingredientList.Clear();
        }
    }
}
