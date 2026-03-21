namespace MChat.Domain.Entities.TeamChatting
{
    /// <summary>
    /// Base class to manage role permissions for team chat.
    /// </summary>
    /// <remarks>
    /// You can get any instance of this class using static properties.
    /// </remarks>
    public sealed class TeamRolePermission
    {
        public readonly string PermissionName;
        public const char SEPARATOR = '.';

        private TeamRolePermission(string permissionName)
        {
            PermissionName = permissionName;
        }

        /// <summary>
        /// Try to parse the <paramref name="permissionName"/> to the associate <c>TeamRolePermission</c>.
        /// </summary>
        /// <remarks>
        /// A role permission is divided in two parts (resource and action), where the first letter of each part is in uppercase.
        /// <br/>
        /// <example>
        /// Example : To get the permission to invite a member
        /// <c>TryParse("User.Invite");</c>
        /// </example>
        /// </remarks>
        /// <param name="permissionName">The string representaion of a <c>TeamRolePermission</c>.</param>
        /// <returns>The role permission</returns>
        /// <exception cref="InvalidOperationException">If the <paramref name="permissionName"/> can not be parsed to a valid role permission because the resource and/or action are invalid.</exception>
        public static TeamRolePermission TryParse(string permissionName)
        {
            if (permissionName.Equals(AllPermissions.PermissionName))
                return AllPermissions;

            string[] permParts = permissionName.Split(SEPARATOR);

            switch (permParts[0])
            {
                case "User": return TryParseToUser(permParts[1]);
                //case "Role": return TryParseToRole(permParts[1]);
                case "Message": return TryParseToMessage(permParts[1]);
                case "Channel": return TryParseToChannel(permParts[1]);

                default: throw new InvalidOperationException($"{permParts[0]} does not match with any permission Resource.");
            }
        }

        private static TeamRolePermission TryParseToUser(string userAction)
        {
            switch (userAction)
            {
                case "Invite": return InviteUser;
                //case "Kick": return KickUser;
                case "AssignRole": return AssignRole;

                default: throw new InvalidOperationException($"{userAction} does not match with any user Action.");
            }
        }

        //private static TeamRolePermission TryParseToRole(string roleAction)
        //{

        //    switch (roleAction)
        //    {
        //        case "Create": return CreateRole;
        //        case "Update": return UpdateRole;
        //        case "Delete": return DeleteRole;

        //        default: throw new InvalidOperationException($"{roleAction} does not match with any role Action.");
        //    }
        //}

        private static TeamRolePermission TryParseToMessage(string messageAction)
        {
            switch (messageAction)
            {
                case "Send": return SendMessage;
                case "DeleteOwn": return DeleteOwnMessage;
                case "DeleteAny": return DeleteAnyMessage;
                case "ReadAll": return ReadAllMessage;

                default: throw new InvalidOperationException($"{messageAction} does not match with any message Action.");
            }
        }

        private static TeamRolePermission TryParseToChannel(string channelAction)
        {
            switch (channelAction)
            {
                case "Create": return CreateChannel;
                case "Update": return UpdateChannel;
                case "Delete": return DeleteChannel;

                default: throw new InvalidOperationException($"{channelAction} does not match with any channel Action.");
            }
        }

        #region Allow all permissions

        /// <summary>
        /// All permissions is granted.
        /// </summary>
        /// <remarks>
        /// <b>Be careful when use it !</b>
        /// </remarks>
        public readonly static TeamRolePermission AllPermissions = new TeamRolePermission("All" + SEPARATOR + "All");

        #endregion


        #region User in team chat

        /// <summary>
        /// Permission to invite another user to join the team chat.
        /// </summary>
        public readonly static TeamRolePermission InviteUser = new TeamRolePermission("User" + SEPARATOR + "Invite");
        /// <summary>
        /// Permission to kick another user in the team chat.
        /// </summary>
        //public static TeamRolePermission KickUser { get; } = new TeamRolePermission("User" + SEPARATOR + "Kick");
        /// <summary>
        /// Permission to assign/replace the role for another user.
        /// </summary>
        public readonly static TeamRolePermission AssignRole = new TeamRolePermission("User" + SEPARATOR + "AssignRole");

        #endregion


        #region created role in team chat (not used because only the creator can perform these actions)

        /// <summary>
        /// Permission to create a new role in the team chat.
        /// </summary>
        //public static TeamRolePermission CreateRole { get; } = new TeamRolePermission("Role" + SEPARATOR + "Create");
        /// <summary>
        /// Permission to update any existing role in the team chat.
        /// </summary>
        //public static TeamRolePermission UpdateRole { get; } = new TeamRolePermission("Role" + SEPARATOR + "Update");
        /// <summary>
        /// Permission to delete any existing role in the team chat.
        /// </summary>
        //public static TeamRolePermission DeleteRole { get; } = new TeamRolePermission("Role" + SEPARATOR + "Delete");

        #endregion


        #region Message in team channel

        /// <summary>
        /// Permission to send a message to a team channel.
        /// </summary>
        public readonly static TeamRolePermission SendMessage = new TeamRolePermission("Message" + SEPARATOR + "Send");
        /// <summary>
        /// Permission to delete its own message from a team channel.
        /// </summary>
        public readonly static TeamRolePermission DeleteOwnMessage = new TeamRolePermission("Message" + SEPARATOR + "DeleteOwn");
        /// <summary>
        /// Permission to delete any published message in team channel.
        /// </summary>
        public readonly static TeamRolePermission DeleteAnyMessage = new TeamRolePermission("Message" + SEPARATOR + "DeleteAny");
        /// <summary>
        /// Permission to read all messages from any team channel.
        /// </summary>
        public readonly static TeamRolePermission ReadAllMessage = new TeamRolePermission("Message" + SEPARATOR + "ReadAll");

        #endregion


        #region Channel in team chat

        /// <summary>
        /// Permission to create a new channel in the team chat.
        /// </summary>
        public readonly static TeamRolePermission CreateChannel = new TeamRolePermission("Channel" + SEPARATOR + "Create");
        /// <summary>
        /// Permission to update any channel in the team chat.
        /// </summary>
        public readonly static TeamRolePermission UpdateChannel = new TeamRolePermission("Channel" + SEPARATOR + "Update");
        /// <summary>
        /// Permission to delete any channel in the team chat.
        /// </summary>
        public readonly static TeamRolePermission DeleteChannel = new TeamRolePermission("Channel" + SEPARATOR + "Delete");

        #endregion
    }
}
