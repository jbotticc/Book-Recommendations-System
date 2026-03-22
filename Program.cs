using BookRecommendationsSystem.Repositories;
using BookRecommendationsSystem.Services;


namespace BookRecommendationsSystem;

class Program
{
    static void Main(string[] args)
    {
        var bookRepository = new BookRepo();
        var ratingRepository = new RatingRepo();
        var memberRepository = new MemberRepo();
        var loginService = new LoginService(memberRepository);
        var ratingService = new RatingService(loginService, memberRepository, ratingRepository, bookRepository);
        var memberService = new MemberService(memberRepository, ratingService);
        var bookService = new BookService(bookRepository, ratingService);

        var recommendationService = new RecommendationService(ratingService, memberService, bookService, loginService);
        var seedBooksService = new SeedBooksService(bookService);
        var seedMembersRatingsService = new SeedMembersRatingsService(ratingService, memberService);

        Console.WriteLine("Welcome to the Book Recommendations System!");
        while (true)
        {
            Console.Write("Please enter the absolute path to the book data file: ");
            string bookPath = Console.ReadLine();
            try
            {
                seedBooksService.SeedData(bookPath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Books file not found. Please try again.");
                continue;
            }
            Console.Write("Please enter the absolute path to the ratings data file: ");
            string ratingPath = Console.ReadLine();
            try
            {seedMembersRatingsService.SeedData(ratingPath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ratings file not found. Please try again.");
                continue;
            }
            break;
        }
        Console.WriteLine("Number of books: " + bookService.GetBookCount());
        Console.WriteLine("Number of members: " + memberService.GetMemberCount());

        bool running = true;
        while (running )
        {
            if (loginService.GetLoggedIn() != 0)
            {
                var account = loginService.GetLoggedIn();
                Console.WriteLine();
                Console.WriteLine("************** MENU **************");
                Console.WriteLine("* 1. Add a new member            *");
                Console.WriteLine("* 2. Add a new book              *");
                Console.WriteLine("* 3. Rate book                   *");
                Console.WriteLine("* 4. View ratings                *");
                Console.WriteLine("* 5. See recommendations         *");
                Console.WriteLine("* 6. Logout                      *");
                Console.WriteLine("**********************************");
                Console.Write("Enter a menu option: ");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Invalid input. Please enter a non-empty value for name.");
                            break;
                        }
                        memberService.AddMember(name);
                        Console.WriteLine("Member added successfully. Member account number: " + memberService.GetMemberCount());
                        break;
                    case "2":
                        Console.Write("Enter author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter year (or range of years): ");
                        string year = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(year))
                        {
                            Console.WriteLine("Invalid input. Please enter a non-empty value for all fields.");
                            break;
                        }
                        bookService.AddBook(author, title, year);
                        break;
                    case "3":
                        Console.Write("Enter ISBN: ");
                        string isbnStr = Console.ReadLine();
                        if (!int.TryParse(isbnStr, out int isbn))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            break;
                        }
                        int currentRating;
                        try
                        {
                            currentRating = ratingService.GetRating(account, isbn);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid book ISBN.");
                            break;
                        }
                        if (currentRating != 0)
                        {
                            Console.WriteLine("You have already rated this book, current rating: " + currentRating);
                            Console.Write("Do you want to update your rating? (y/n): ");
                            string update = Console.ReadLine();
                            if (update.ToLower() != "y")
                            {
                                break;
                            }
                        }
                        Console.Write("Enter rating: ");
                        string ratingStr = Console.ReadLine();
                        if (!int.TryParse(ratingStr, out int rating))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            break;
                        }
                        try
                        {
                            ratingService.UpdateRating(account, isbn, rating);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid rating.");
                            break;
                        }
                        var book = bookService.GetBook(isbn);
                        Console.WriteLine("Your new rating for " + book.Isbn + ", " + book.Author + ", " + book.Title + ", " + book.Year + " => rating: " + rating);
                        break;
                    case "4":
                        var member = memberService.GetMember(account);
                        Console.WriteLine(member.Name + "'s ratings:");
                        var ratings = ratingService.GetLoggedInUsersRatings();
                        for (int i = 0; i < ratings.Count; i++)
                        {
                            var ratedBook = bookService.GetBook(ratings[i].Isbn);
                            Console.WriteLine(ratedBook.Isbn + ", " + ratedBook.Author + ", " + ratedBook.Title + ", " + ratedBook.Year + " => rating: " + ratings[i].RatingVal);
                        }
                        break;
                    case "5":
                        recommendationService.PrintRecommendations();
                        break;
                    case "6":
                        loginService.LogOutUser();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("************** MENU **************");
                Console.WriteLine("* 1. Add a new member            *");
                Console.WriteLine("* 2. Add a new book              *");
                Console.WriteLine("* 3. Login                       *");
                Console.WriteLine("* 4. Exit                        *");
                Console.WriteLine("**********************************");
                Console.Write("Enter a menu option: ");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Invalid input. Please enter a non-empty value for name.");
                            break;
                        }
                        memberService.AddMember(name);
                        Console.WriteLine("Member added successfully. Member account number: " + memberService.GetMemberCount());
                        break;
                    case "2":
                        Console.Write("Enter author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter year (or range of years): ");
                        string year = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(year))
                        {
                            Console.WriteLine("Invalid input. Please enter a non-empty value for all fields.");
                            break;
                        }
                        bookService.AddBook(author, title, year);
                        Console.WriteLine("Book added successfully. Book ISBN: " + bookService.GetBookCount());
                        break;
                    case "3":
                        Console.Write("Enter member account number: ");
                        string accountStr = Console.ReadLine();
                        if (!int.TryParse(accountStr, out int account))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            break;
                        }
                        try
                        {
                            loginService.LogInUser(account);
                            Console.WriteLine("Login successful. Welcome " + memberService.GetMember(account).Name);
                        }
                        catch (KeyNotFoundException)
                        {
                            Console.WriteLine("Invalid account number.");
                        }
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Thank you for using the Book Recommendations System!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}