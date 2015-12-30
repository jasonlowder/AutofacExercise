using AutofacExercise.Business.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutofacExercise.UnitTests.Messages
{
    [TestClass]
    public class MessageServiceTests
    {
        [TestMethod]
		public void MessageIsReturnedByGetMessage() {
			var messageService = new MessageService();
			var message = messageService.GetMessage();
			Assert.IsFalse(string.IsNullOrEmpty(message));
		}
    }
}
