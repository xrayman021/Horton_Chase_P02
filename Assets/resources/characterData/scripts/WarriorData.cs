using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;


[CreateAssetMenu(fileName = "New Warrior Data", menuName = "Character Data/Warrior")]
public class WarriorData : CharacterData
{
    public WarriorClassType clasType;
    public WarriorWpnType wpnType;
}
