using System;
using System.Net;

namespace Genius
{
	public class Core
	{
		private static string _stateGuid { get; }

		static Core()
		{
			Guid state = new Guid();
			Core._stateGuid = state.ToString().Replace("{", "").Replace("}", "");
		}

		internal const string BaseUrl = "api.genius.com";

		internal string Token { get; private set; }

		public async void Auth(string token)
		{
			// 1. Acquire code from user -> user signs in with genius, grants permission, and returns the code
			//    :: https://api.genius.com/oauth/authorize?client_id=bGrew3sPIRgzj8AMqIl5B4bydML6cQnBSt7DTJLE78ufRG5pXMFDZgmB5B7PeZgv&redirect_uri=https://github.com/lordofkhaos/Genius.NET&scope=me&state=8DEC003A-6744-4D66-ABBE-2EEC3A8C4813&response_type=code
			//    :: https://github.com/lordofkhaos/Genius.NET?code=DPS1o3mYq6Ed3nOwCl26QdSDiivmSZzZkRCh6sTixf3IDOoK4d4ILrKRT0--ya90&state=%7B8DEC003A-6744-4D66-ABBE-2EEC3A8C4813%7D
			//     ==> code: DPS1o3mYq6Ed3nOwCl26QdSDiivmSZzZkRCh6sTixf3IDOoK4d4ILrKRT0--ya90 :: this will be unique per user
			// 2. Build the request with the acquired information
			//    {
			//      "code": "DPS1o3mYq6Ed3nOwCl26QdSDiivmSZzZkRCh6sTixf3IDOoK4d4ILrKRT0--ya90",
			//      "client_id": "bGrew3sPIRgzj8AMqIl5B4bydML6cQnBSt7DTJLE78ufRG5pXMFDZgmB5B7PeZgv",
			//      "client_secret": "5h57klpfTynKYkPmPXJjF1T4GDwBivqBNDcoBNuqAqddBJSd6C6wYu3XycSspmCAnxKNzPh1p-WYmv5n2qfU5w",
			//      "redirect_uri": "https://github.com/lordofkhaos/Genius.NET",
			//      "response_type": "code",
			//      "grant_type": "authorization_code"
			//     }
			// 3. Send user's code to /oauth/token to acquire token
			//    ==> response:
			//    {
			//      "access_token": "ACCESS_TOKEN"
			//    }
		}
	}
}