using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<OrderSO> orderTextLove;
    [SerializeField] private List<OrderSO> orderTextStrength;
    [SerializeField] private List<OrderSO> orderTextHealth;
    [SerializeField] private List<OrderSO> orderTextPoison;

    [SerializeField] private List<PotionType> potionType;

    [SerializeField] private List<string> customerNames;

    [SerializeField] private TextMeshProUGUI nameTextBox;
    [SerializeField] private TextMeshProUGUI orderTextBox;

    private int _randomPotion;
    
    // Start is called before the first frame update
    void Start()
    {
        _randomPotion = Random.Range(0, potionType.Count);

        if (potionType[_randomPotion] == PotionType.Love)
        {
            ChooseLine(orderTextLove);
            RandomName();
        }
        else if (potionType[_randomPotion] == PotionType.Strength)
        {
            ChooseLine(orderTextStrength);
            RandomName();
        }
        else if (potionType[_randomPotion] == PotionType.Health)
        {
            ChooseLine(orderTextHealth);
            RandomName();
        }
        else if (potionType[_randomPotion] == PotionType.Poison)
        {
            ChooseLine(orderTextPoison);
            RandomName();
        }
        else
        {
            Debug.Log("Potion type is outside of range somehow");
        }
    }

    void ChooseLine(List<OrderSO> orderScriptableObject)
    {
        int randomLine;
        randomLine = Random.Range(0, orderScriptableObject.Count);
        //Debug.Log(orderScriptableObject[randomLine].orderText);
        orderTextBox.text = orderScriptableObject[randomLine].orderText;
    }

    void RandomName()
    {
        int index;
        index = Random.Range(0, customerNames.Count);
        nameTextBox.text = customerNames[index];
    }
}
