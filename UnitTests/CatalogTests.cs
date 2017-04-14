using Xunit;
using CourseCatalog;

public class CatalogShould
{
    [Fact]
    public void CreateANewCatalogObject()
    {
        // Arrange
        Catalog catalog = new Catalog();
        Assert.NotNull(catalog.CourseList);
    }


}
