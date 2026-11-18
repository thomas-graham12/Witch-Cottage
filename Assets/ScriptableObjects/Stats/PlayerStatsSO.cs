using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Stats", menuName = "Stats/PlayerStats")]
public class PlayerStatsSO : ScriptableObject
{
    public int moneyAmount;
    
    public int allCorrectOrders;
    public int allIncorrectOrders;
    
    public int dayCorrectOrders;
    public int dayIncorrectOrders;
}
