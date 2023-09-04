using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }

    public event Action<ItemData> onPickupItem;

    private void Awake()
    {
        Instance = this;
    }

    public void PickUpItem(ItemData _itemData)
    {
        onPickupItem?.Invoke(_itemData);
    }
}
