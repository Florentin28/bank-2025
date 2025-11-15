interface IBankAccount: IAccount
{


    string _number;
    double _balance;
    Person _owner;
     string Number { get => _number; }
     double Balance { get => _balance;  }
     Person Owner { get => _owner; }   
    double ApplyInterest();
}