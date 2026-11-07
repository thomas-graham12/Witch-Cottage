using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<OrderSO> orderTextLove;
    [SerializeField] private List<OrderSO> orderTextStrength;
    [SerializeField] private List<OrderSO> orderTextHealth;
    [SerializeField] private List<OrderSO> orderTextPoison;

    [SerializeField] private List<PotionType> potionType;

    private int _randomPotion;
    
    // Start is called before the first frame update
    void Start()
    {
        _randomPotion = Random.Range(0, potionType.Count);

        if (potionType[_randomPotion] == PotionType.Love)
        {
            ChooseLine(orderTextLove);
        }
        else if (potionType[_randomPotion] == PotionType.Strength)
        {
            ChooseLine(orderTextStrength);
        }
        else if (potionType[_randomPotion] == PotionType.Health)
        {
            ChooseLine(orderTextHealth);
        }
        else if (potionType[_randomPotion] == PotionType.Poison)
        {
            ChooseLine(orderTextPoison);
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
        Debug.Log(orderScriptableObject[randomLine].orderText);
    }
}
