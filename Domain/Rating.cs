namespace BookRecommendationsSystem.Domain;

public record Rating
{
    public int Isbn { get; init; }
    public int RatingVal { get; init; }

    public Rating(int isbn, int ratingVal)
    {
        if (ratingVal != -5 && ratingVal != -3 && ratingVal != 0 && ratingVal != 1 && ratingVal != 3 && ratingVal != 5)
            throw new ArgumentException("Rating must be one of the following: -5, -3, 0, 1, 3, or 5.");

        Isbn = isbn;
        RatingVal = ratingVal;
    }
}