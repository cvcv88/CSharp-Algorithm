namespace _034._StackQueue_Practice
{
	internal class Program
	{
		static void Main1(string[] args)
		{
			Console.WriteLine("텍스트를 입력하세요");
			Console.Write("> ");
			string text = Console.ReadLine();
			if (IsOk(text))
			{
				Console.WriteLine("괄호가 유효합니다.");
			}
			else
			{
				Console.WriteLine("괄호가 유효하지 않습니다.");
			}
		}

		static bool IsOk(string text)
		{
			Stack<char> stack = new Stack<char>();
			char temp;
			foreach (char s in text)
			{
				if (s == '(' || s == '[' || s == '{')
				{
					stack.Push(s);
				}
				else
				{
					temp = stack.Peek();
					if (temp == '(' && s == ')') stack.Pop();
					else if (temp == '{' && s == '}') stack.Pop();
					else if (temp == '[' && s == ']') stack.Pop();
				}
			}
			if(stack.Count == 0)
			{
				return true;
			}
			else
				return false;
			
		}
	}
}
