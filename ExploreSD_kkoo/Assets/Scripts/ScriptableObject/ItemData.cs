using JetBrains.Annotations;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable,
    Useable
}

public enum ConsumableType
{
    Health
}

public enum UseableType
{
    Invincibility
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[System.Serializable]
public class ItemDataUseable
{
    public UseableType type;
    public float time;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Useable")]
    public ItemDataUseable[] useables;

    [Header("Equip")]
    public GameObject equipPrefab;
}