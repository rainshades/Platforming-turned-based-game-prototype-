public enum Phase { Start, Draw, Battle, End }
static class PhaseMethods
{
    public static Phase NextPhase(this Phase p)
    {
        switch (p)
        {
            case Phase.Start:
                p = Phase.Draw;
                return p;
            case Phase.Draw:
                p = Phase.Battle;
                return p;
            case Phase.Battle:
                p = Phase.End;
                return p;
            case Phase.End:
                p = Phase.Start;
                return p;
            default:
                p = Phase.End;
                return p;
        }
    }

    public static Phase GetPhase(this Phase p)
    {
        switch (p)
        {
            case Phase.Start:
                return Phase.Start;
            case Phase.Draw:
                return Phase.Draw;
            case Phase.Battle:
                return Phase.Battle;
            case Phase.End:
                return Phase.End;
            default:
                return Phase.End;
        }
    }

}