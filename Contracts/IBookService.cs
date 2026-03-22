using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IBookService
{
    /// <summary>
    /// A method available to the user to add a book
    /// </summary>
    /// <param name="author">The author of the book to add</param>
    /// <param name="title">The title of the book to add</param>
    /// <param name="year">The year of the book to add</param>
    /// <exception cref="ArgumentException">Thrown when any of the string attributes are null</exception>
    void AddBook(string author, string title, string year);
    
    /// <summary>
    /// A method available to the user to update a book
    /// </summary>
    /// <param name="isbn">The isbn of the book to update</param>
    /// <param name="author">The author of the book to update</param>
    /// <param name="title">The title of the book to update</param>
    /// <param name="year">The year of the book to update</param>
    /// <exception cref="ArgumentException">Thrown when any of the string attributes are null</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - An book must already exist with the provided isbn
    ///
    /// Post-conditions:
    /// - The book with the provided isbn is replaced with a new book object
    /// </remarks>
    void UpdateBook(int isbn, string author, string title, string year);

    /// <summary>
    /// A method available to the user to delete a book
    /// </summary>
    /// <param name="isbn">The isbn of the book to delete</param>
    /// <remarks>
    /// Pre-conditions:
    /// - An book must already exist with the provided isbn
    ///
    /// Post-conditions:
    /// - The book with the provided isbn is deleted
    /// </remarks>
    void DeleteBook(int isbn);
    
    /// <summary>
    /// A method available to the user to retrieve a book
    /// </summary>
    /// <param name="isbn">The isbn of the book to retrieve</param>
    /// <returns>The book that contains the provided isbn</returns>
    /// <remarks>
    /// Pre-conditions:
    /// - An book must already exist with the provided isbn
    ///
    /// Post-conditions:
    /// - The book with the provided isbn is returned
    /// </remarks>
    Book GetBook(int isbn);
}