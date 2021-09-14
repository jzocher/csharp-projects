using System;
using Terminal.Gui;
using NStack;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            var login_name = "test";
            var login_pass = "1234";
            var currentBalance = "1337.69";
            string submittedLogin;
            string submittedPass;

            Application.Init();
            var top = Application.Top;

            //Login Screen UI
            var viewLoginScreen = new Window("") { X = 0, Y = 0, Width = Dim.Fill(), Height = Dim.Fill() };
            //Splash
            var title1 = new Label("        _______ __  __ ")       { X = Pos.Center() - 12, Y = Pos.Center() - 8};
            var title2 = new Label("     /\\|__   __|  \\/  |")     { X = Pos.Left(title1),  Y = Pos.Top(title1) + 1};
            var title3 = new Label("    /  \\  | |  | \\  / |")     { X = Pos.Left(title2),  Y = Pos.Top(title2) + 1};
            var title4 = new Label("   / /\\ \\ | |  | |\\/| |")    { X = Pos.Left(title3),  Y = Pos.Top(title3) + 1};
            var title5 = new Label("  / ____ \\| |  | |  | |")      { X = Pos.Left(title4),  Y = Pos.Top(title4) + 1};
            var title6 = new Label(" /_/    \\_\\_|  |_|  |_|")     { X = Pos.Left(title5),  Y = Pos.Top(title5) + 1};
            //Login
            var login = new Label("Account #: ")    { X = Pos.Left(title6) - 4, Y = Pos.Top(title6) + 3 };
            var password = new Label("Pin: ")       { X = Pos.Left(login),      Y = Pos.Top(login) + 2 };
            var loginText = new TextField("")       { X = Pos.Right(login),     Y = Pos.Top(login),     Width = 20 };
            var passText = new TextField("")        { X = Pos.Left(loginText),  Y = Pos.Top(password),  Width = Dim.Width(loginText), Secret = true };
            var submitLogin = new Button("_Submit") { X = Pos.Center() - 5,     Y = Pos.Top(password) + 2 };

            //Welcom message
            var viewWelcomeScreen = new Window("Current User") { X = 0, Y = 0, Width = Dim.Fill(), Height = 3 };
            var welcomeMessage = new Label($"Welcome {login_name}!") { X = 2, Y = 0 };

            //Main Menu UI
            var viewMenuScreen = new Window("Main Menu") { X = 0, Y = 3, Width = Dim.Fill(), Height = Dim.Fill() };
            //Menu
            var btnCheckBalance = new Button("Check Balance")   { X = Pos.Left(welcomeMessage),         Y= Pos.Percent(50f) };
            var btnWithdraw = new Button("Withdraw")            { X = Pos.Left(welcomeMessage),         Y = Pos.Top(btnCheckBalance) + 2 };
            var btnDeposite = new Button("Deposite")            { X = Pos.Right(btnCheckBalance) + 1,   Y = Pos.Top(btnCheckBalance) };
            var btnChangePin = new Button("Change Pin")         { X = Pos.Right(btnCheckBalance) + 1,   Y = Pos.Top(btnCheckBalance) + 2 };
            var btnLogout = new Button("Logout")                { X = Pos.Left(welcomeMessage) + 1,     Y = Pos.Percent(90f) };

            //Check Balance UI
            var viewCheckBalanace = new Window("")                          { X = 0, Y = 3, Width = Dim.Fill(), Height = Dim.Fill() };
            var balance = new Label($"Current Balance: ${currentBalance}")  { X= Pos.Center()};
            var btnBack = new Button("Back")                                { X = Pos.Center(), Y = Pos.Top(balance) + 1};


            bool loginDialog(string login_name, string acct, string login_pass, string pass)
            {
                
                if (login_name == acct && login_pass == pass)
                {
                    top.Remove(viewLoginScreen);
                    top.Add(viewWelcomeScreen, viewMenuScreen);
                    Application.Run();
                    var a = MessageBox.Query(50, 7, "Success", "You successfully logged in", "OK");
                    return a == 0;
                }
                else
                {
                    var n = MessageBox.Query(50, 7, "Login Error", "Your account number or password was incorret.", "OK");
                    return n == 0;
                }
            }

            //Login Screen functions
            submitLogin.Clicked += () =>
            {
                submittedLogin = loginText.Text.ToString();
                submittedPass = passText.Text.ToString();
                loginDialog(login_name, submittedLogin, login_pass, submittedPass);
            };

            //Main Menu Functions
            btnCheckBalance.Clicked += () =>
            {
                //top.Remove(viewMenuScreen);
                top.Add(viewCheckBalanace);
                Application.Run();
            };
            btnDeposite.Clicked += () =>
            {
                top.Remove(viewMenuScreen);
                Application.Run();
            };
            btnWithdraw.Clicked += () =>
            {
                top.Remove(viewMenuScreen);
                Application.Run();
            };
            btnChangePin.Clicked += () =>
            {
                top.Remove(viewMenuScreen);
                Application.Run();
            };
            btnLogout.Clicked += () =>
            {
                top.Remove(viewMenuScreen);
                Application.Run();
            };
            btnBack.Clicked += () =>
            {
                
            };

            //General Functions
            static bool Quit()
            {
                var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
                return n == 0;
            }

            // Add stuff to views here
            viewLoginScreen.Add(
                title1, title2, title3, title4, title5, title6
                ,login, password, loginText, passText
                ,submitLogin
            );

            viewMenuScreen.Add(
                btnCheckBalance, btnWithdraw
                ,btnDeposite, btnChangePin
                ,btnLogout
            );

            viewWelcomeScreen.Add(
                welcomeMessage
            );

            viewCheckBalanace.Add(
                balance
                , btnBack
            );

            Application.Run(viewLoginScreen);
        }
    }
}
