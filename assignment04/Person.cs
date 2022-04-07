using System.Collections;
using assignment04.Account;
using assignment04.Transaction;

namespace assignment04;

    public class Person
    {
    private string password;
    public event EventHandler OnLogin;

    public string Sin { get; }
    public string Name { get; }
    public bool IsAuthenticated { get; private set; }

    public Person(string Name, string Sin)
    {
        this.Name = Name;
        this.Sin = Sin;

        password = Sin.Substring(0, 3);
    }

    public void Login(string password)
    {
        if (this.password != password)
        {
            IsAuthenticated = false;

            OnLogin.Invoke(this, new EventArgs());

            //TODO: Fix eventArgs
            LoginEventArgs(this, false);

            throw new AccountException(AccountEnum.PasswordIncorrect);

        }
        else if (this.password == password)
        {
            IsAuthenticated = true;

            OnLogin.Invoke(this, EventArgs.Empty);
            //TODO: Fix eventArgs

            LoginEventArgs(this, true);
        }
    }

    public void Logout()
    {
        IsAuthenticated = false;
    }

    public override string ToString()
    {
        return $"{Name} is {(IsAuthenticated ? "" : "not")} Authenticated.";
    }
}
