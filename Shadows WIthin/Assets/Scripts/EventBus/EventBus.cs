using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }

    public event Action<ItemData> onPickupItem;

    public event Action<ItemData> onItemUsed;

    private void Awake()
    {
        Instance = this;
    }

    public void PickUpItem(ItemData _itemData)
    {
        onPickupItem?.Invoke(_itemData);
        Debug.Log(_itemData + "has been picked up");
    }

    public void UseItem(ItemData item)
    {
        onItemUsed?.Invoke(item);
    }
}
