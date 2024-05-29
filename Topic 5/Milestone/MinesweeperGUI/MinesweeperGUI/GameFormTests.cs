using NUnit.Framework;
using System.Reflection;
using Minesweeper;

namespace MinesweeperGUI
{
    [TestFixture]
    public class GameFormTests
    {
        [Test]
        public void GameForm_GridSizeInitialization()
        {
            // Arrange
            int expectedGridSize = 15;

            // Act
            GameForm gameForm = new GameForm(expectedGridSize);

            // Use reflection to access the private gridSize field
            FieldInfo? gridSizeField = typeof(GameForm).GetField("gridSize", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(gridSizeField, Is.Not.Null);
            int actualGridSize = (int)(gridSizeField!.GetValue(gameForm) ?? -1);

            // Assert
            Assert.That(actualGridSize, Is.EqualTo(expectedGridSize));
        }

        [Test]
        public void GameForm_CreateGrid_CreatesCorrectNumberOfButtons()
        {
            // Arrange
            int gridSize = 10;
            GameForm gameForm = new GameForm(gridSize);

            // Act
            MethodInfo? createGridMethod = typeof(GameForm).GetMethod("CreateGrid", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(createGridMethod, Is.Not.Null);
            createGridMethod!.Invoke(gameForm, null);

            // Assert
            int expectedButtonCount = gridSize * gridSize;
            int actualButtonCount = 0;
            foreach (Control control in gameForm.Controls)
            {
                if (control is Button)
                {
                    actualButtonCount++;
                }
            }
            Assert.That(actualButtonCount, Is.EqualTo(expectedButtonCount));
        }
    }
}
