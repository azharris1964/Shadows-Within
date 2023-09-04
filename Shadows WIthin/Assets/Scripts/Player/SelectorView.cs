using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectorView : MonoBehaviour
{

    [SerializeField] private float _speed = 25f;

    private List<Button> itemSlots = new();

    private RectTransform _rectTransform;

    private GameObject _selected;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {

        foreach (Transform child in transform)
        {
            itemSlots.Add(child.GetComponent<Button>());
        }
        foreach (Button btn in itemSlots)
        {
            btn.onClick.AddListener(PlaceHolder);
        }

    }

    public void PlaceHolder()
    {
        Debug.Log("This works");
    }



    private void Update()
    {
        var selectedGameObject = EventSystem.current.currentSelectedGameObject;
        _selected = (selectedGameObject == null) ? _selected : selectedGameObject;
        if (_selected == null) return;
        transform.position = Vector3.Lerp(transform.position, _selected.transform.position, _speed * Time.unscaledDeltaTime);

        var otherRect = _selected.GetComponent<RectTransform>();

        var horizontalLerp = Mathf.Lerp(_rectTransform.rect.size.x, otherRect.rect.size.x, _speed * Time.unscaledDeltaTime);
        var verticalLerp = Mathf.Lerp(_rectTransform.rect.size.y, otherRect.rect.size.y, _speed * Time.unscaledDeltaTime);

        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, horizontalLerp);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, verticalLerp);
    }
}
