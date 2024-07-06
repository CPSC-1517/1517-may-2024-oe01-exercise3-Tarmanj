using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Review
    {
        private string _ISBN;
        private string _Reviewer;
        private string _comment;
        private string _Title;
        private string _Author;

        public string ISBN 
        {
            get { return _ISBN; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ISBN is required");
                }
                _ISBN = value.Trim();
            }
        }

        public string Reviewer 
        {
            get { return _Reviewer; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Reviewer is required");
                }
                _Reviewer = value.Trim();
            }
        }

        public RatingType Rating { get; set; }

        public string Comment 
        {
            get { return _comment; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Comment is required");
                }
                _comment = value.Trim();
            }
        }
        public string Author
        {
            get { return _Author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value.Trim()))
                {
                    throw new ArgumentException("Author is required.");
                }

                _Author = value;
            }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title is required");
                }
                _Title = value.Trim();
            }
        }

        public Review(string isbn, string title, string author, string reviewer, 
                         RatingType rating, string comment)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Reviewer = reviewer;
            Rating = rating;
            Comment = comment;
        }

        public override string ToString() 
        {
            return $"{ISBN},{Title},{Author},{Reviewer},{Rating},{Comment}";
        }

        public static Review Parse(string text) 
        {
            string[] parts = text.Split(',');

            if (parts.Length != 6) 
            {
                throw new FormatException($"Invalid format.");
            }

            string isbn = parts[0];
            string title = parts[1];
            string author = parts[2];
            string reviewer = parts[3];
            RatingType rating = (RatingType)Enum.Parse(typeof(RatingType),parts[4]);
            string comment = parts[5];

            return new Review(isbn, title, author, reviewer, rating, comment);

        }
    }
}
