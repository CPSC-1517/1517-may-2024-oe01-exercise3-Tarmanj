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
        private Reviewer _Reviewer;
        private string _comment;

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

        public Reviewer Reviewer 
        {
            get { return _Reviewer; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentException("Reviewer is required");
                }
                _Reviewer = value;
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

        public Review(string isbn, Reviewer reviewer, 
                         RatingType rating, string comment)
        {
            ISBN = isbn;
            Reviewer = reviewer;
            Rating = rating;
            Comment = comment;
        }

        public override string ToString() 
        {
            return $"{ISBN},{Reviewer},{Rating},{Comment}";
        }
    }
}
