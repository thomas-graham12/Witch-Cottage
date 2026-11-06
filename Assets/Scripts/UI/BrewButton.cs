using System.Collections;
using System.Collections.Generic;
using Cauldron;
using UnityEngine;

public class BrewButton : MonoBehaviour
{
    [SerializeField] private CreatePotion cauldron;
    
    public void TaskOnClick()
    {
        cauldron.BrewPotion();
    }
}
