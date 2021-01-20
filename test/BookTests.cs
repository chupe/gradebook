using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {

        [Fact]
        public void ConvertsAvgToLetterGrade()
        {
            var book = new InMemoryBook("The TestBook");
            book.AddGrade(30);
            book.AddGrade(60);
            book.AddGrade(90);

            // Act
            var result = book.GetStats();

            // Assert
            Assert.Equal('D', result.Letter);
        }

        [Fact]
        public void BookAcceptsNumericalGrades()
        {
            //Given
            var book = new InMemoryBook("The TestBook");
            var testGrades = new List<double>() { 0, 100, 45 };

            //When
            foreach (var grade in testGrades)
            {
                book.AddGrade(grade);

                //Then
                Assert.Contains(grade, book.Grades);
            }
        }

        [Fact]
        public void BookAcceptsLetterGrades()
        {
            //Given
            var book = new InMemoryBook("The TestBook");
            var testGrades = Stats.ValidGrades;

            //When
            foreach (var grade in testGrades)
            {
                book.AddGrade(grade);
            }

            //Then
            Assert.Contains(90, book.Grades);
            Assert.Contains(80, book.Grades);
            Assert.Contains(70, book.Grades);
            Assert.Contains(60, book.Grades);
        }

        [Fact]
        public void BookRejectsInvalidValues()
        {
            //Given
            var book = new InMemoryBook("The TestBook");
            var testGrades = new List<double>() { -1, 101, -5 };

            //When
            foreach (var grade in testGrades)
            {
                try
                {
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Assert.Equal("Invalid grade", ex.Message);
                }
            }

        }

        [Fact]
        public void BookCalculatesStats()
        {
            // Arrange
            var book = new InMemoryBook("The Gradebook");
            book.AddGrade(3);
            book.AddGrade(6);
            book.AddGrade(9);

            // Act
            var result = book.GetStats();

            // Assert
            Assert.Equal(6, result.Average);
            Assert.Equal(9, result.High);
            Assert.Equal(3, result.Low);
        }
    }
}
