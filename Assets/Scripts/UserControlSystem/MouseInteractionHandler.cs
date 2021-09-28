using Abstractions;
using System.Linq;
using UnityEngine;

public class MouseInteractionHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;

    public void Update()
    {
        if (!Input.GetMouseButtonUp(0)) return;
        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (hits.Length == 0) return;
        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(hit => hit != null)
            .FirstOrDefault();
        _selectedObject.SetValue(selectable);
    }
}