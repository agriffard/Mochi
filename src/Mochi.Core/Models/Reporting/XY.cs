namespace Mochi.Core.Models.Reporting;

public class XY<TX, TY>
{
    public XY(TX x, TY y)
    {
        X = x;
        Y = y;
    }

    public TX X { get; set; }
    public TY Y { get; set; }
}
