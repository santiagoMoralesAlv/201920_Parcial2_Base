using AI;
using UnityEngine;

public class FleeFromTaggedActor : Node
{
    public override void Execute()
    {

        this.GetComponent<AIController>().GoToLocation(
            this.transform.position-(-this.transform.position + this.GetComponent<AIController>().Target.transform.position).normalized
            );
    }
}