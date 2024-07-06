using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Reviewer
    {
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Organization;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First Name is required");
                }
                _FirstName = value.Trim();
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last Name is required");
                }
                _LastName = value.Trim();
            }
        }

        public string Email
        {
            get { return _Email; }
            set
            {
                string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
                Regex regex = new Regex(pattern);
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email is required");
                }
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Email is not an acceptable email address pattern");
                }
                _Email = value.Trim();
            }
        }

        public string Organization 
        {
            get { return _Organization; }
            set 
            {
                _Organization = value?.Trim();
            
            }
        }

        public string ReviewerName
        {
            get { return $"{LastName}, {FirstName}"; }
        }

        public Reviewer (string firstName, string lastName, string email, string organization)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Organization = organization;
        }

        public override string ToString()
        {
            return $"{FirstName},{LastName},{Email},{Organization}";
        }
    }
}
