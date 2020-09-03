using LibraryProgram;
using Xunit;

namespace LibraryTests
{
    public class UnitTest1
    {
        [Fact]
        public void Library_starts_empty()
        {
            Library<string> library = new Library<string>();

            Assert.Empty(library);
        }

        [Fact]
        public void Library_can_store()
        {
            Library<string> storeLibrary = new Library<string>();

            storeLibrary.Add("book");
            storeLibrary.Add("GoT");

            Assert.Equal(new[] { "book", "GoT" }, storeLibrary);
        }

        [Fact]
        public void Library_can_remove()
        {
            // Arange
            Library<string> removeLibrary = new Library<string>();

            removeLibrary.Add("book");
            removeLibrary.Add("Harry Potter");
            removeLibrary.Add("GoT");

            // Act
            bool result = removeLibrary.Remove(1);

            // Assert
            Assert.True(result);
            Assert.Equal(new[] { "book", "GoT" }, removeLibrary);
        }
    }
}