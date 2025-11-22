namespace Adrien_mertens;

/// <summary>
/// Classe abstraite représentant un compte bancaire générique.
/// </summary>
public abstract class Account : IBankAccount
{
    /// <summary>
    /// Numéro unique du compte.
    /// </summary>
    public string Number { get; private set; }

    /// <summary>
    /// Solde actuel du compte.
    /// </summary>
    public double Balance { get; private set; }

    /// <summary>
    /// Propriétaire du compte.
    /// </summary>
    public Person Owner { get; private set; }

    /// <summary>
    /// Constructeur de base d'un compte bancaire.
    /// </summary>
    /// <param name="number">Numéro du compte.</param>
    /// <param name="owner">Propriétaire du compte.</param>
    public Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
    }

    public Account(string number, Person owner , double balance ) : this(number, owner)
    {
        Balance = balance;
    }
    
    /// <summary>
    /// Méthode pour le retrait de fonds.
    /// Diminue le solde du montant demandé.
    /// </summary>
    /// <param name="amount">Montant à retirer.</param>
    public virtual void WithDraw(double amount)
    {
        
        if (amount < 0 )
        {
            throw new InsufficientBalanceException("Le solde du compte est insuffisant.");
        }
        Balance -= amount;
    }
    
    /// <summary>
    /// Méthode pour déposer des fonds.
    /// Augmente le solde du montant déposé.
    /// </summary>
    /// <param name="amount">Montant à déposer.</param>
    public virtual void Deposit(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Le montant déposé est négatif.");
        }
        Balance += amount;
        
    }

    /// <summary>
    /// Calcule les intérêts à appliquer au solde du compte.
    /// Cette méthode doit être implémentée dans chaque type de compte spécifique.
    /// </summary>
    /// <returns>Montant des intérêts calculés.</returns>
    protected abstract double CalculInterets();

    /// <summary>
    /// Applique les intérêts au solde du compte.
    /// Le solde est augmenté du montant retourné par CalculInterets().
    /// </summary>
    public void ApplyInterest()
    {
        // On ajoute au solde le montant des intérêts calculés.
        Balance += CalculInterets();
    }
    
    public event Action<Account>? NegativeBalanceEvent;

    protected virtual void OnNegativeBalanceEvent()
    {
        NegativeBalanceEvent?.Invoke(this);
    }
}

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
        Console.WriteLine(message);
    }
}

