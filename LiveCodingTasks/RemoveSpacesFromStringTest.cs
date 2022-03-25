using NUnit.Framework;

namespace LiveCodingTasks
{
    [TestFixture]
    public class RemoveSpacesFromStringTest
    {
    
        [TestCase(@"aba cda aba ", @"aba%20cda%20aba%20")]
        [TestCase(@" ", @"%20")]
        public void Test1(string input, string result)
        {
            var inputChars = input.ToCharArray();
            
            var changed = RemoveSpacesFromString.ReplaceFun(inputChars, inputChars.Length);
            
            CollectionAssert.AreEqual(changed, result.ToCharArray());
        }
    }
}