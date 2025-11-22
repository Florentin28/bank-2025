namespace Adrien_mertens;

/// <summary>
/// Représente une personne, propriétaire d'un ou plusieurs comptes bancaires.
/// </summary>
public class Person
{
    /// <summary>
    /// Prénom de la personne.
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Nom de famille de la personne.
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Date de naissance de la personne.
    /// </summary>
    public DateTime BirthDate { get; private set; }

    /// <summary>
    /// Constructeur permettant d'initialiser une personne avec ses informations principales.
    /// </summary>
    /// <param name="firstName">Prénom de la personne.</param>
    /// <param name="lastName">Nom de famille de la personne.</param>
    /// <param name="birthDate">Date de naissance de la personne.</param>
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}