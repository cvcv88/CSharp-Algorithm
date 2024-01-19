using System.Security.Cryptography.X509Certificates;

namespace _07._HashTable_Practice
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CheatKey cheatKey = new CheatKey();
			while (true)
			{
				Console.Write(">");
				string temp = Console.ReadLine();
				cheatKey.Run(temp);
			}
			/*cheatKey.Run("1");
			cheatKey.Run("2");
			cheatKey.Run("3");*/
		}
	}

	public class CheatKey
	{
		private Dictionary<string, Action> cheatDic;

		public CheatKey()
		{
			cheatDic = new Dictionary<string, Action>();
			cheatDic.Add("1", ShowMeTheMoney);
			cheatDic.Add("2", ThereIsnoCowLevel);
		}
		
		public void Run(string cheatKey)
		{
			try
			{
				cheatDic.TryGetValue(cheatKey, out Action action);
				action.Invoke();
			}
			catch (Exception ex)
			{
				Console.WriteLine("지정된 치트키가 아닙니다.");
			}
		}

		public static void ShowMeTheMoney()
		{
			Console.WriteLine("골드를 늘려주는 치트키 발동!");
		}

		public static void ThereIsnoCowLevel()
		{
			Console.WriteLine("바로 승리합니다 치트키 발동!");
		}
	}
}
