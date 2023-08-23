using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectorView : MonoBehaviour
{
    private void Update()
    {
        var selected = EventSystem.current.currentSelectedGameObject;

        if (selected == null) return;

        transform.position = selected.transform.position;
    }
}
