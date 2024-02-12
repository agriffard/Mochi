namespace Mochi.Core.Extensions;
public static class StatusExtensions
{
    public static string ToCssClass(this Status status)
    {
        var result = string.Empty;
        switch (status)
        {
            case Status.None:
                break;
            case Status.Regular:
                result = "success";
                break;
            case Status.Warning:
                result = "warning";
                break;
            case Status.Error:
                result = "danger";
                break;
            case Status.Critical:
                result = "dark";
                break;
            default:
                break;
        }

        return result;
    }
}
