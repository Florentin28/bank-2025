class Person
{
    private string FirstName { get ; set; }
    private string LastName { get; set; }
    private DateTime BirthDate { get; set; }

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Born on: {BirthDate.ToShortDateString()}";
    }
}