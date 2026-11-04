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

    private Button _button;
    
    // Start is called before the first frame update
    void Start()
    {
        // _button = GetComponent<Button>();
        // _button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    public void TaskOnClick()
    {
        if (createPotion.ingredientList.Count < 3)
        {
            baseInregientPrefab.GetComponent<IngredientPrefabStats>().ingredientObject = ingredientObject;
            Instantiate(baseInregientPrefab);
        }
    }
}
