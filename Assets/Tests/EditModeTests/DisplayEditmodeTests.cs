using NUnit.Framework;
using Display;

public class DisplayEditmodeTests
{
    [Test]
    public void DisplayModel_MethodSwapToScreen_ShouldAssignNewStringValue()
    {
        // Arrange
        DisplayModel displayModel = new();
        displayModel.activeCanvasString.Value = "Old Value";

        // Acts
        displayModel.SwapToScreen("New Value");

        //Assert
        Assert.AreEqual(displayModel.activeCanvasString.Value, "New Value");
    }
}
