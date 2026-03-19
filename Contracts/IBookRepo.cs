using BookRecommendationsSystem.Domain;

namespace BookRecommendationsSystem.Contracts;

public interface IBookRepo
{
    /// <summary>
    /// Internal repository method to add a new book to the repository
    /// </summary>
    /// <param name="book">The book object to be added to the repository</param>
    void Add(Book book);
    
    /// <summary>
    /// Internal repository method to update an existing book
    /// </summary>
    /// <param name="book">The new book object to replace the one with the same isbn</param>
    void Update(Book book);
    
    /// <summary>
    /// Internal repository method to delete a book object given the isbn
    /// </summary>
    /// <param name="isbn">The isbn of the book to delete</param>
    void Delete(int isbn);
    
    /// <summary>
    /// Internal repository method to retrieve a book given the isbn
    /// </summary>
    /// <param name="isbn">The isbn of the book to return</param>
    /// <returns>The book object matching the inputted isbn</returns>
    Book Get(int isbn);
}