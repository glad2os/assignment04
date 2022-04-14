using assignment04.Account;
using assignment04.Transaction;
using assignment04.Exception;

namespace assignment04;

public class Person
{
    private readonly string password;

    public Person(string name, string sin)
    {
        Name = name;
        Sin = sin;

        password = sin[..3];
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

            OnLogin.Invoke(this, new LoginEventArgs(Name, false));

            throw new AccountException(ExceptionEnum.PASSWORD_INCORRECT);
        }

        if (this.password != password) return;
        IsAuthenticated = true;

        OnLogin.Invoke(this, new LoginEventArgs(Name, true));
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