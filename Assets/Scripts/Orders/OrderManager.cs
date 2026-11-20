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
    [SerializeField] private PotionType currentPotion;

    [SerializeField] private List<string> customerNames;

    [SerializeField] private TextMeshProUGUI nameTextBox;
    [SerializeField] private TextMeshProUGUI orderTextBox;
    [SerializeField] private TextMeshProUGUI requiredPotionTextBox;
    [SerializeField] private TextMeshProUGUI isCorrectTextBox;
    [SerializeField] private TextMeshProUGUI moneyTextBox;

    [SerializeField] private PlayerStatsSO playerStats;
    
    // Sounds
    [SerializeField] private AudioSource moneySound;

    private int _randomPotion;
    
    // Start is called before the first frame update
    void Start()
    {
        RandomPotion();
        moneyTextBox.text = playerStats.moneyAmount.ToString();
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

    public void RandomPotion()
    {
        _randomPotion = Random.Range(0, potionType.Count);
        currentPotion = potionType[_randomPotion];
        Debug.Log(currentPotion);

        if (potionType[_randomPotion] == PotionType.Love)
        {
            ChooseLine(orderTextLove);
            requiredPotionTextBox.text = "Make a Love Potion";
            RandomName();
        }
        else if (potionType[_randomPotion] == PotionType.Strength)
        {
            ChooseLine(orderTextStrength);
            requiredPotionTextBox.text = "Make a Strength Potion";
            RandomName();
        }
        else if (potionType[_randomPotion] == PotionType.Health)
        {
            ChooseLine(orderTextHealth);
            requiredPotionTextBox.text = "Make a Health Potion";
            RandomName();
        }
        else if (potionType[_randomPotion] == PotionType.Poison)
        {
            ChooseLine(orderTextPoison);
            requiredPotionTextBox.text = "Make a Poison Potion";
            RandomName();
        }
        else
        {
            Debug.Log("Potion type is outside of range somehow");
        }
    }

    public void IsPotionCorrect(PotionSO potionSO)
    {
        bool bPotionCorrect = false;
        if (potionSO.potionType == currentPotion)
        {
            bPotionCorrect = true;
            MoneyGain(bPotionCorrect);
        }
        else if (potionSO.potionType != currentPotion)
        {
            bPotionCorrect = false;
            MoneyGain(bPotionCorrect);
        }
        else
        {
            bPotionCorrect = false;
            MoneyGain(bPotionCorrect);
        }
    }

    public IEnumerator IIsPotionCorrect(PotionSO potionSO)
    {
        IsPotionCorrect(potionSO);
        yield return new WaitForSeconds(3.0f);
        isCorrectTextBox.text = "";
        RandomPotion();
    }

    private void MoneyGain(bool bPotionCorrect)
    {
        int randomMoneyAmount = Random.Range(15, 28);

        playerStats.moneyAmount = Mathf.Clamp(playerStats.moneyAmount, 0, 999999);
        if (bPotionCorrect)
        {
            isCorrectTextBox.text = "Thank you for the potion!";
            playerStats.moneyAmount += randomMoneyAmount;
            moneyTextBox.text = playerStats.moneyAmount.ToString();
            moneySound.Play();
        }
        else
        {
            isCorrectTextBox.text = "This isn't what I asked for!";
            playerStats.moneyAmount -= randomMoneyAmount;
            moneyTextBox.text = playerStats.moneyAmount.ToString();
        }

    }
}
