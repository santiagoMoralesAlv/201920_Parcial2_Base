using UnityEngine;

public class HumanController : PlayerController
{
    [SerializeField]
    private LayerMask walkable;

    private void Update()
    {
        GoToLocation(GetLocation());
    }

    protected override Vector3 GetLocation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit, walkable) ? hit.point : transform.position;
    }
}