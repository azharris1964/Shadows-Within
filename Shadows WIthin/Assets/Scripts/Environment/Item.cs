using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName = "Items/New Item", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField] GameObject _prefab;
    [SerializeField] string _itemName;
    //[SerializeField] DescriptionText _descriptionText;
    [SerializeField] float _menuScaleFactor = 1;

   // public List<string> GetDescription()
   // {
       // return _descriptionText.text;
   // }

    public GameObject GetPrefab()
    {
        return _prefab;
    }

    public string GetItemName()
    {
        return _itemName;
    }

    public Vector3 GetMenuScaleFactor()
    {
        return new Vector3 (_menuScaleFactor, _menuScaleFactor, _menuScaleFactor);
    }

}
