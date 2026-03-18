namespace MChat.Domain.Enums
{
    /// <summary>
    /// The same global role names in all team chat.
    /// </summary>
    /// <remarks>
    /// This enumeration contains all roles than every <c>TeamChat</c> must have and can not be deleted.
    /// </remarks>
    public enum GlobalTeamRoleName
    {
        Owner = 0,
        Moderator = 1,
        Member = 2
    }
}
