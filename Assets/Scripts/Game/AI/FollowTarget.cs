using AI;

public class FollowTarget : Node
{
    public override void Execute()
    {
        this.GetComponent<AIController>().GoToLocation(this.GetComponent<AIController>().Target.transform.position);
    }
}