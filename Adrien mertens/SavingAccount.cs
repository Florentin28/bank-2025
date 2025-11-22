using System;
namespace Adrien_mertens;

/// <summary>
/// Classe représentant un compte d'épargne (livret d'épargne).
/// </summary>
public class SavingAccount : Account
{
    /// <summary>
    /// Date du dernier retrait effectué sur le compte d'épargne.
    /// </summary>
    public DateTime DateLastWithdraw { get; private set; }

    /// <summary>
    /// Constructeur d'un compte d'épargne.
    /// </summary>
    /// <param name="number">Numéro du compte.</param>
    /// <param name="owner">Propriétaire du compte.</param>
    /// <param name="dateLastWithdraw">Date du dernier retrait.</param>
    public SavingAccount(string number, Person owner, DateTime dateLastWithdraw) 
        : base(number, owner)
    {
        DateLastWithdraw = dateLastWithdraw;
    }

    /// <summary>
    /// Effectue un retrait et met à jour la date du dernier retrait.
    /// </summary>
    /// <param name="amount">Montant à retirer.</param>
    public override void WithDraw(double amount)
    {
        base.WithDraw(amount);
        DateLastWithdraw = DateTime.Now;
    }

    /// <summary>
    /// Effectue un dépôt et met à jour la date du dernier retrait (ou mouvement).
    /// </summary>
    /// <param name="amount">Montant à déposer.</param>
    public override void Deposit(double amount)
    {
        base.Deposit(amount);
        DateLastWithdraw = DateTime.Now;
    }

    /// <summary>
    /// Calcule les intérêts pour un livret d'épargne.
    /// Le taux est toujours de 4,5 % du solde.
    /// </summary>
    /// <returns>Montant des intérêts calculés.</returns>
    protected override double CalculInterets()
    {
        const double taux = 0.045; // 4,5 %
        // Intérêts = solde * taux
        return Balance * taux;
    }
}