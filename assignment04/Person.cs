using assignment04.Account;
using assignment04.Transaction;

namespace assignment04;

public class Person
{
    private readonly string password;

    public Person(string Name, string Sin)
    {
        this.Name = Name;
        this.Sin = Sin;

        password = Sin.Substring(0, 3);
    }

    public string Sin { get; }
    public string Name { get; }
    public bool IsAuthenticated { get; private set; }
    public event EventHandler OnLogin;

    public void Login(string password)
    {
        if (this.password != password)
        {
            IsAuthenticated = false;

            OnLogin.Invoke(this, new EventArgs());

            //TODO: Fix eventArgs
            var loginEventArgs = new LoginEventArgs(Name, false);

            //todo: implement exception
            /*
             * AccountException(ExceptionEnum)
             * you trying to pass AccountEnum
             * explain me it
             */
            throw new AccountException(AccountEnum.PasswordIncorrect);
        }

        if (this.password == password)
        {
            IsAuthenticated = true;

            OnLogin.Invoke(this, EventArgs.Empty);
            //TODO: Fix eventArgs

            var loginEventArgs = new LoginEventArgs(Name, true);
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