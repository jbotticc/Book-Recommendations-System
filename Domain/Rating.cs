namespace BookRecommendationsSystem.Domain;

public record Rating
{
    public int Isbn { get; init; }
    public int RatingVal { get; init; }

    public Rating(int isbn, int ratingVal)
    {
        if (ratingVal < 0 || ratingVal > 5)
            throw new ArgumentOutOfRangeException(nameof(ratingVal), "Rating must be between 0 and 5.");

        Isbn = isbn;
        RatingVal = ratingVal;
    }
}