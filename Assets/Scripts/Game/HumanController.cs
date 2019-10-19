using UnityEngine;

public class HumanController : PlayerController
{
    [SerializeField]
    private LayerMask walkable;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanMove){
            GoToLocation(GetLocation());
        }
    }

    private Vector3 GetLocation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit, walkable, LayerMask.GetMask("Floor"), QueryTriggerInteraction.Ignore) ? hit.point : transform.position;
    }


}