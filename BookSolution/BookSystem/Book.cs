using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Book
    {
        #region Data Members
        private string _ISBN;
        private string _Title;
        private int _PublishYear;
        private Author _Author;
        #endregion

        #region properties
        public string ISBN 
        {
            get { return _ISBN; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ISBN is required");
                }
                _ISBN = value.Trim();
            }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required");
                }
                _Title = value.Trim();
            }
        }

        public int PublishYear
        {
            get { return _PublishYear; }
            set
            {
                if (value.ToString().Length != 4)
                {
                    throw new FormatException($"Publish year format of {value} is invalid. Use yyyy format.");
                }
                if (value < 0) 
                {
                    throw new FormatException($"Publish year format of {value} is invalid. Use yyyy format.");
                }
                _PublishYear = value;
            }
        }

        public Author Author
        {
            get { return _Author; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Author is required");
                }
                _Author = value;
            }
        }

        public GenreType Genre { get; set; }

        public List<Review> Reviews { get; set; } = [];
        public int TotalReviews => Reviews.Count;
        #endregion

        #region Constructor
        public Book(string isbn, string title, int publishYear, Author author, GenreType genre, List<Review> reviews)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Genre = genre;
            PublishYear = publishYear;
            if (reviews != null) 
            {
                Reviews = reviews;
            }
        }
        #endregion

        #region Methods
        public void AddReview(string isbn, Review review)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentNullException("ISBN required");
            }
            if (review == null)
            {
                throw new ArgumentNullException("Review required");
            }
            if (isbn != review.ISBN)
            {
                throw new ArgumentException($"The book ISBN provide does not match with the Review ISBN provided: {review.ISBN}");
            }
            if(Reviews.Any(x => x.Reviewer.Equals(review.Reviewer)))
            {
                throw new ArgumentException($"{review.Reviewer} already has review this book and cannot add another review.");
            }
            Reviews.Add(review);
        }
        #endregion
    }
}
