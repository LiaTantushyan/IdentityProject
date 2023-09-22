namespace IdentityProj.Common.CustomExceptions;

public static class ErrorMessages
{
    public static string InvalidPassword = "Invalid password";

    public static string InvalidPhoneNumber = "Wrong format for phone number";

    public static string InvalidFullName = "FullName must contain only letters";

    public static string UserNotFound = "User with given parameters not found";

    public static string WrongIncomingParameter = "Wrong incoming parameter";

    public static string CompanyNotFound = "Company not found";

    public static string RefreshTokenNotFound = "Refresh token not found";

    public static string InvalidToken = "Token is invalid";

    public static string UsedRefreshedToken = "Refresh token is already used";

    public static string TokenNotExpired = "Token is not expired";

    public static string WrongPassword = "Wrong password";

    public static string UnknownError = "Unknown error";
}