namespace Strings.Tests
{
	public class KeyIndexedCountingTests
	{
		[Fact]
		public void Test1()
		{
			var sample = new KeyIndexedCounting();

			sample.Sort();
			sample.Print();
		}
	}
}