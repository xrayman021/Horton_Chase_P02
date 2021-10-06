using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenu(fileName = "New Rogue Data", menuName = "Character Data/Rogue")]
public class RogueData : CharacterData
{
    public RogueWpnType wpnType;
    public RogueStrategyType strategyType;
}
