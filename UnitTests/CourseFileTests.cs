using System;
using System.IO;
using Xunit;
using CourseCatalog;

public class CourseFileShould
{

    [Fact]
    public void RaiseExceptionWhenNullPath()
    {
        // Arrange
        string filepath = "";
        CourseFile courseFile = new CourseFile(filepath);

        // Act
        Exception e = Assert.Throws<ArgumentException>(() => { courseFile.GetRecords(); });

        // Assert
        Assert.Equal("File Not Found!", e.Message);
    }

    [Fact]
    public void RaiseExceptionWhenFileNotFound()
    {
        //Arrange
        string path = "input.txt";
        CourseFile courseFile = new CourseFile(path);

        //Act
        Exception e = Assert.Throws<FileNotFoundException>(() => { courseFile.GetRecords(); });

        //Assert
        Assert.Equal("File Not Found!", e.Message);
    }

    [Fact]
    public void ReadAllLinesIntoInputFileInputArray()
    {
        //Arrange
        string[] expected = new string[3] { "Introduction to Paper Airplanes: ", "Advanced Throwing Techniques: Introduction to Paper Airplanes", "" };
        string path = "/Users/Jen/Documents/Code/Packsize/CollegeCoursePrerequisites/TestFiles/short-test.txt";
        CourseFile courseFile = new CourseFile(path);

        //Act
        courseFile.GetRecords();

        //Assert
        Assert.Equal(expected, courseFile.Courses);
    }

}
