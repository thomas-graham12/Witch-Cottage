using UnityEngine;

namespace Cauldron
{
    public class CreatePotion : MonoBehaviour
    {
        public IngredientType ingredientOne;
        public IngredientType ingredientTwo;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.TryGetComponent(out IngredientPrefabStats stats))
            {
                Debug.Log("Tapped");
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

                ingredientOne = IngredientType.None;
                ingredientTwo = IngredientType.None;
            }
        }
    }
}
