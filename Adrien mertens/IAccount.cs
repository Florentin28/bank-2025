namespace Adrien_mertens;

/// <summary>
/// Interface de base pour un compte, permettant
/// de consulter le solde et d'effectuer des dépôts/retraits.
/// </summary>
public interface IAccount
{
    /// <summary>
    /// Solde actuel du compte (lecture seule via l'interface).
    /// </summary>
    double Balance { get; }

    /// <summary>
    /// Effectue un dépôt sur le compte.
    /// </summary>
    /// <param name="amount">Montant à déposer.</param>
    void Deposit(double amount);

    /// <summary>
    /// Effectue un retrait sur le compte.
    /// </summary>
    /// <param name="amount">Montant à retirer.</param>
    void WithDraw(double amount);
}