namespace GeorgesChat.Web.Helpers;

public static class HubConnections
{
	public static Dictionary<string, List<string>> Users = new();

	public static bool HasUserConnection(string userId, string connectionId)
	{
		try
		{
			if (Users.ContainsKey(userId))
			{
				return Users[userId].Any(p => p.Contains(connectionId));
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}

		return false;
	}

	public static void AddUserToConnection(string userId, string connectionId)
	{
		if (!string.IsNullOrWhiteSpace(userId) && !HasUserConnection(userId, connectionId))
		{
			if (Users.ContainsKey(userId))
			{
				Users[userId].Add(connectionId);
			}
			else
			{
				Users.Add(userId, new List<string> { connectionId });
			}
		}
	}

	public static List<string> OnlineUsers()
	{
		return Users.Keys.ToList();
	}
}
