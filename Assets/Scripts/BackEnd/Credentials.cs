/// <summary>
///  This class contains credential information of a user that needs to be provided to the
///  backend with certain actions for authentication.
/// </summary>
public class Credentials
{
    public string refresh { get; set; }
    public string access { get; set; }

    public Credentials(string refresh, string access)
    {
        self.refresh = refresh;
        self.access = access;
    }
}