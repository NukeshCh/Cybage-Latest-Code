using System.ComponentModel.DataAnnotations;

public class Customer
{
    public string Id { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone Number is required")]
    public string phone_Number { get; set; }

    [Required(ErrorMessage = "Country Code is required")]
    public string country_code { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Balance is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Balance must be a positive number")]
    public decimal Balance { get; set; }

    public string Salutation { get; set; } = null;
        public string Initials { get; set; } = null;

    public string FirstNameAscii { get; set; } = null;

    public string FirstNameCountryRank { get; set; } = null;
    public string FirstNameCountryFrequency { get; set; } = null;
    public string LastNameAscii { get; set; } = null;
    public string LastNameCountryRank { get; set; } = null;
    public string LastNameCountryFrequency { get; set; } = null;

    public string Password { get; set; } = null;

    public string CountryCodeAlpha { get; set; } = null;
    public string CountryName { get; set; } = null;
    public string PrimaryLanguageCode { get; set; } = null;
    public string PrimaryLanguage { get; set; } = null;

    public string Currency { get; set; } = null;

}
