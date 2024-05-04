namespace BuberDinner.Api.Common.Http;

// Static class to hold keys for items stored in HttpContext.
// This helps in maintaining consistent key names across the application and avoids hard-coded strings.
public static class HttpContextItemKeys
{
    // Constant for the key used to store error details in HttpContext.Items.
    // This key is used to retrieve error information elsewhere in the application.
    public const string Errors = "Errors";
}
