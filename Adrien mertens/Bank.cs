namespace Adrien_mertens;

/// <summary>
/// Classe représentant une banque gérant un ensemble de comptes bancaires.
/// </summary>
public class Bank
{
    /// <summary>
    /// Dictionnaire des comptes bancaires gérés par la banque,
    /// indexés par leur numéro de compte.
    /// </summary>
    private Dictionary<string, IBankAccount> _accounts = new Dictionary<string, IBankAccount>();

    /// <summary>
    /// Ajoute un compte à la banque si le numéro n'est pas déjà utilisé.
    /// </summary>
    /// <param name="account">Compte à ajouter.</param>
    public void AddAccount(IBankAccount account)
    {
        if (_accounts.ContainsKey(account.Number))
        {
            Console.WriteLine("Erreur : Un compte avec ce numéro existe déjà.");
            return;
        }
        
        _accounts.Add(account.Number, account);
        Console.WriteLine($"Compte {account.Number} ajouté avec succès.");
        
        // Si c'est un Account (CurrentAccount, SavingAccount, ...),
        // on s'abonne à l'événement NegativeBalanceEvent
        if (account is Account bankAccount)
        {
            bankAccount.NegativeBalanceEvent += NegativeBalanceAction;
        }
    }

    /// <summary>
    /// Supprime un compte de la banque en fonction de son numéro.
    /// </summary>
    /// <param name="number">Numéro du compte à supprimer.</param>
    public void DeleteAccount(string number)
    {
        if (!_accounts.ContainsKey(number))
        {
            Console.WriteLine("Erreur : Aucun compte trouvé avec ce numéro.");
            return;
        }

        _accounts.Remove(number);
        Console.WriteLine($"Compte {number} supprimé avec succès.");
    }

    /// <summary>
    /// Retourne le solde du compte courant correspondant au numéro fourni.
    /// </summary>
    /// <param name="number">Numéro du compte.</param>
    /// <returns>
    /// Le solde du compte si celui-ci existe, sinon 0 et un message d'erreur est affiché.
    /// </returns>
    public double ReturnSoldeCurrentAccount(string number)
    {
        if (!_accounts.TryGetValue(number, out var account))
        {
            Console.WriteLine("Erreur : Aucun compte trouvé avec ce numéro.");
            return 0;
        }

        return account.Balance;
    }

    /// <summary>
    /// Affiche la liste de tous les comptes gérés par la banque avec leur solde.
    /// </summary>
    public void ShowAllCurrentAccounts()
    {
        Console.WriteLine("Liste des comptes :");
        foreach (var account in _accounts.Values)
        {
            Console.WriteLine(
                $"N°: {account.Number}, " +
                $"Solde: {account.Balance}");
        }
    }
    
    /// <summary>
    /// Méthode appelée lorsque le solde d'un compte vient de passer en négatif.
    /// </summary>
    /// <param name="account">Compte concerné.</param>
    private void NegativeBalanceAction(Account account)
    {
        Console.WriteLine($"Le numéro de compte {account.Number} vient de passer en négatif");
    }
}