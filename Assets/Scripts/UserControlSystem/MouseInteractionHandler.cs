using Core;
using System.Linq;
using UnityEngine;

public class MouseInteractionHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public void Update()
    {
        if (!Input.GetMouseButtonUp(0)) return;
        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (hits.Length == 0) return;
        var mainBuilding = hits
            .Select(hit => hit.collider.GetComponentInParent<MainBuilding>())
            .Where(hit => hit != null)
            .FirstOrDefault();
        if (mainBuilding == default) return;
        mainBuilding.ProduceUnit();
    }
}