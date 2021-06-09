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
            string submittedLogin;
            string submittedPass;

            Application.Init();
            var top = Application.Top;

            // Creates the top-level window to show
            var win = new Window("MyApp")
            {
                X = 0,
                Y = 0, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            top.Add(win);

            //// Creates a menubar, the item "New" has a help menu.
            //var menu = new MenuBar(new MenuBarItem[] {
            //    new MenuBarItem ("_File", new MenuItem [] {
            //        new MenuItem ("_New", "Creates new file", null),
            //        new MenuItem ("_Close", "",null),
            //        new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; })
            //    }),
            //    new MenuBarItem ("_Edit", new MenuItem [] {
            //        new MenuItem ("_Copy", "", null),
            //        new MenuItem ("C_ut", "", null),
            //        new MenuItem ("_Paste", "", null)
            //    })
            //});
            //top.Add(menu);

            static bool Quit()
            {
                var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
                return n == 0;
            }

            var title1 = new Label("        _______ __  __ ")       {X = Pos.Center() - 12, Y = Pos.Center() - 8};
            var title2 = new Label("     /\\|__   __|  \\/  |")     {X = Pos.Left(title1), Y = Pos.Top(title1) + 1};
            var title3 = new Label("    /  \\  | |  | \\  / |")     {X = Pos.Left(title2), Y = Pos.Top(title2) + 1};
            var title4 = new Label("   / /\\ \\ | |  | |\\/| |")    {X = Pos.Left(title3), Y = Pos.Top(title3) + 1};
            var title5 = new Label("  / ____ \\| |  | |  | |")      {X = Pos.Left(title4), Y = Pos.Top(title4) + 1};
            var title6 = new Label(" /_/    \\_\\_|  |_|  |_|")     {X = Pos.Left(title5), Y = Pos.Top(title5) + 1};
            
            var login = new Label("Login: ") { X = Pos.Left(title6) - 4, Y = Pos.Top(title6) + 3};
            var password = new Label("Password: ")
            {
                X = Pos.Left(login),
                Y = Pos.Top(login) + 2
            };
            var loginText = new TextField("")
            {
                X = Pos.Right(password),
                Y = Pos.Top(login),
                Width = 20
            };
            var passText = new TextField("")
            {
                Secret = true,
                X = Pos.Left(loginText),
                Y = Pos.Top(password),
                Width = Dim.Width(loginText)
            };

            static bool loginDialog(string login_name, string acct, string login_pass, string pass)
            {
                
                if (login_name == acct && login_pass == pass)
                {
                    var a = MessageBox.Query(50, 7, "Success", "You successfully logged in", "OK");
                    return a == 0;
                }
                else
                {
                    var n = MessageBox.Query(50, 7, "Login Error", "Your account number or password was incorret.", "OK");
                    return n == 1;
                }
            }
            var submitLogin = new Button(55, 20, "_Submit");
            submitLogin.Clicked += () => { 
                submittedLogin = loginText.Text.ToString(); 
                submittedPass = passText.Text.ToString();  
                loginDialog(login_name, submittedLogin, login_pass, submittedPass); 
            };
            // Add some controls, 
            win.Add(
                // The ones with my favorite layout system, Computed
                title1, title2, title3, title4, title5, title6, 
                login, password, loginText, passText,
                submitLogin
            );

            Application.Run();
        }
    }
}
