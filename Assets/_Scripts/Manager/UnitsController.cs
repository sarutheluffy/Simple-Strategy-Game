using UnityEngine;

public class UnitsController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private RaycastHit _hitInfo;

    private Unit _currentSelectedUnit;
    private void Update()
    {
        if (Input.GetMouseButton(0) && GameManager.Instance.currentState == GameState.Ready)
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out _hitInfo))
            {
                if (_hitInfo.collider.tag.Equals("Unit"))
                {
                    _currentSelectedUnit?.OnDeselectUnit();
                    _currentSelectedUnit = _hitInfo.transform.GetComponent<Unit>();
                    PanelHUD.Instance.SetUnitName(_currentSelectedUnit.GetUnitName);
                    _currentSelectedUnit.OnSelectUnit();
                }
                else
                {
                    _currentSelectedUnit?.Move(_hitInfo.point);
                    _currentSelectedUnit = null;
                }
            }
        }
    }
}
