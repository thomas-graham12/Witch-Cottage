using System;
using System.Collections;
using System.Collections.Generic;
using Cauldron;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private IngredientsSO ingredientObject;
    [SerializeField] private GameObject baseInregientPrefab;
    [SerializeField] CreatePotion createPotion;

    private TextMeshProUGUI _textBox;
    
    [SerializeField] private InventoryManager inventoryManager;

    private void Awake()
    {
        _textBox = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        _textBox.text = ingredientObject.name + ": " + ingredientObject.amount;
    }

    // Update is called once per frame
    public void TaskOnClick()
    {
        if (createPotion.ingredientList.Count < 3)
        {
            if (ingredientObject.amount > 0)
            {
                inventoryManager.DecreaseIngredient(ingredientObject);
                baseInregientPrefab.GetComponent<IngredientPrefabStats>().ingredientObject = ingredientObject;
                _textBox.text = ingredientObject.name + ": " + ingredientObject.amount;
                Instantiate(baseInregientPrefab);
            }
        }
    }
}
