namespace Adrien_mertens;

/// <summary>
/// Interface représentant un compte bancaire complet,
/// avec numéro, propriétaire, solde, opérations et application des intérêts.
/// </summary>
public interface IBankAccount : IAccount
{
    /// <summary>
    /// Numéro unique du compte bancaire.
    /// </summary>
    string Number { get; }
    
    /// <summary>
    /// Propriétaire du compte bancaire.
    /// </summary>
    Person Owner { get; }
    
    /// <summary>
    /// Applique les intérêts sur le compte, en utilisant la logique propre au type de compte.
    /// </summary>
    void ApplyInterest();
}