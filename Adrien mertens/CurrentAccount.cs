namespace Adrien_mertens;

/// <summary>
/// Classe représentant un compte courant.
/// </summary>
public class CurrentAccount : Account
{
    /// <summary>
    /// Ligne de crédit autorisée (découvert maximum).
    /// </summary>
    private double _CreditLine;

    public double CreditLine
    {
        get { return _CreditLine; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("La ligne de crédit doit être positive.");
            }
            _CreditLine = value;
        }
    }
    /// <summary>
    /// Constructeur d'un compte courant.
    /// </summary>
    /// <param name="number">Numéro du compte.</param>
    /// <param name="owner">Propriétaire du compte.</param>
    /// <param name="creditLine">Montant de la ligne de crédit.</param>
    public CurrentAccount(string number, Person owner, double creditLine) 
        : base(number, owner)
    {
        CreditLine = creditLine;
        _CreditLine = creditLine;
    }
    
    /// <summary>
    /// Effectue un retrait sur le compte courant,
    /// en vérifiant que le montant est positif et que la ligne de crédit n'est pas dépassée.
    /// </summary>
    /// <param name="amount">Montant à retirer.</param>
    public override void WithDraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Erreur : Le montant doit être positif");
            return;
        }

        // On vérifie que le solde après retrait ne dépasse pas la ligne de crédit autorisée.
        if (Balance - amount < -CreditLine)
        {
            Console.WriteLine("Erreur : Le solde est insuffisant");
            return;
        }

        base.WithDraw(amount);
        Console.WriteLine($"Retrait de {amount} effectué avec succès.");
    }

    /// <summary>
    /// Effectue un dépôt sur le compte courant.
    /// </summary>
    /// <param name="amount">Montant à déposer.</param>
    public override void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Erreur : le montant doit être positif");
            return;
        }

        base.Deposit(amount);
        Console.WriteLine($"Dépôt de {amount} effectué avec succès.");
    }

    /// <summary>
    /// Calcule les intérêts pour un compte courant.
    /// - Si le solde est positif ou nul : taux de 3 %.
    /// - Si le solde est négatif : taux de 9,75 %.
    /// </summary>
    /// <returns>Montant des intérêts calculés.</returns>
    protected override double CalculInterets()
    {
        // Choix du taux en fonction du signe du solde.
        double taux = Balance >= 0 ? 0.03 : 0.0975;

        // Intérêts = solde * taux.
        return Balance * taux;
    }
}