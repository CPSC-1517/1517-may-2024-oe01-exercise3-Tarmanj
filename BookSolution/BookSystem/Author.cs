using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Author
    {
        #region Data Members
        private string _FirstName;
        private string _LastName;
        private string _ContactUrl;
        private string _ResidentCity;
        private string _ResidentCountry;
        #endregion

        #region Properties

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

        public string ContactUrl 
        { 
            get { return _ContactUrl; }
            set
            {
                string pattern = @"(https?://www\.)?([a-zA-Z0-9]+\.)+[a-zA-Z]{2,}(\.[a-zA-Z]{2,})?$";
                Regex regex = new Regex(pattern);
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException("Contact Url is required");
                }
                if (!regex.IsMatch(value)) 
                {
                    throw new ArgumentException("Contact Url is not an acceptable url pattern");
                }
                _ContactUrl = value.Trim();
            }
        }

        public string ResidentCity
        {
            get { return _ResidentCity; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Resident City is required");
                }
                _ResidentCity = value.Trim();
            }
        }

        public string ResidentCountry
        {
            get { return _ResidentCountry; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Resident Country is required");
                }
                _ResidentCountry = value.Trim();
            }
        }

        public string AuthorName
        {
            get { return $"{LastName}, {FirstName}"; }
        }
        #endregion

        #region Constructor
        public Author(string firstName, string lastName, string contactUrl, string city, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactUrl = contactUrl;
            ResidentCity = city;
            ResidentCountry = country;
        }
        #endregion

        #region Methods
        public override string ToString() => $"{FirstName},{LastName},{ContactUrl},{ResidentCity},{ResidentCountry}";
        #endregion
    }
}