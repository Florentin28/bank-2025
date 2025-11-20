public class Person
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime BirthDate { get; private set; }

    // Construct Person
    public Person(string firstname, string lastname, DateTime birthdate)
    {
        FirstName = firstname;
        LastName = lastname;
        BirthDate = birthdate;
    }
    public void DisplayInfoPerson()
    {
        Console.WriteLine($"Welcome {FirstName} {LastName}, born on {BirthDate.ToShortDateString()}");
    }
}