using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level_?",menuName ="Game/LevelData")]
public class LevelData : ScriptableObject
{
    [Header("Floor Hero")]
    [SerializeField] private FloorData floorHero;
    public FloorData FloorHero => floorHero;
    [Space]
    [Header("Floor Enemy")]
    [SerializeField] private List<FloorData> lstFloorData;
    public IEnumerable<FloorData> LstFloorData => lstFloorData;
}

[System.Serializable]
public class FloorData
{
    [SerializeField] private List<CharData> lstCharData;
    public IEnumerable<CharData> LstCharData => lstCharData;
}

[System.Serializable]
public class CharData
{
    [SerializeField] private CharID charID;
    [SerializeField] private int power;
    public CharID CharID => charID;
    public int Power => power;
}
