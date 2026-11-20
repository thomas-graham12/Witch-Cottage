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
    [SerializeField] private AudioSource ingredientSound;
    [SerializeField] private float cooldownTime;

    private TextMeshProUGUI _textBox;
    
    [SerializeField] private InventoryManager inventoryManager;

    private int _maxSpawnedIngredients = 3;

    private bool _bCanSpawn = true;

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
        //if (createPotion.ingredientList.Count < 3)
        //{
            if (ingredientObject.amount > 0 
                && inventoryManager.GetSpawnedIngredients().Count < _maxSpawnedIngredients && _bCanSpawn)
            {
                inventoryManager.DecreaseIngredient(ingredientObject);
                inventoryManager.AddSpawnedIngredient(ingredientObject);
                ingredientSound.Play();
                baseInregientPrefab.GetComponent<IngredientPrefabStats>().ingredientObject = ingredientObject;
                _textBox.text = ingredientObject.name + ": " + ingredientObject.amount;
                Instantiate(baseInregientPrefab);
                StartCoroutine(StartSpawnCooldown());
            }
        //}
    }

    IEnumerator StartSpawnCooldown()
    {
        _bCanSpawn = false;
        yield return new WaitForSeconds(cooldownTime);
        _bCanSpawn = true;
    }
}
