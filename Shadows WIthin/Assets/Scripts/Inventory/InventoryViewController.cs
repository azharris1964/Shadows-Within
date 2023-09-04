using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryViewController : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemDescriptionText;

    public void OnSlotSelected(ItemSlot selectedSlot)
    {
        if(selectedSlot._itemData == null)
        {
            _itemNameText.ClearMesh();
            _itemDescriptionText.ClearMesh();
            return;
        }

        _itemNameText.SetText(selectedSlot._itemData.Name);
        _itemDescriptionText.SetText(selectedSlot._itemData.Description[0]);
    }
}
