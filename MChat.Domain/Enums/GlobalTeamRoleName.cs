using MChat.Domain.Entities.TeamChatting;
namespace MChat.Domain.Enums
{
    /// <summary>
    /// The same global role names in all team chat.
    /// </summary>
    /// <remarks>
    /// This enumeration contains all roles than every <see cref="TeamChat"/> must have and can not be deleted.
    /// </remarks>
    public enum GlobalTeamRoleName
    {
        Owner = 0,
        Moderator = 1,
        Member = 2
    }
}
