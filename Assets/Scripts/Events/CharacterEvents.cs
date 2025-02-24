using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEvents
{
    //Damaged
    public static UnityAction<GameObject, int> characterDamage;
    
    //Healed
    public static UnityAction<GameObject, int> characterHeal;
}
