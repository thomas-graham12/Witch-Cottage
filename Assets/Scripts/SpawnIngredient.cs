using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private IngredientsSO ingredientObject;
    [SerializeField] private GameObject baseInregientPrefab;

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
        baseInregientPrefab.GetComponent<IngredientPrefabStats>().ingredientObject = ingredientObject;
        Instantiate(baseInregientPrefab);
    }
}
