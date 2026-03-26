using UnityEngine;

[CreateAssetMenu(fileName = "CupData", menuName = "ScriptableObjects/CupData", order = 1)]
public class CupData : ScriptableObject
{
    public string cupName;
    public string description;
    public Sprite cupIcon;
    public GameObject cupPrefab;
    public float waterCapacity;
    public float passiveLossMultiplier;
    public int unlockCost;
    public bool isUnlocked;
    public Sprite cupSprite; 
}