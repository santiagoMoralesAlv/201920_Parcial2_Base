using AI;
using UnityEngine;

public class IsTaggedActorNear : SelectWithOption
{
    [SerializeField]
    private float distance;

    public override bool Check()
    {
        try
        {
            return Vector3.Magnitude(this.transform.position - this.GetComponent<AIController>().Target.transform.position) < distance;
        }
        catch (System.NullReferenceException e) {
            Debug.LogWarning("No hay target");
            return false;
        }



    }
}