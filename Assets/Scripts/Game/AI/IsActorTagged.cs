using AI;

public class IsActorTagged : SelectWithOption
{
    public override bool Check()
    {
        return this.GetComponent<AIController>().IsTagged;
    }
}