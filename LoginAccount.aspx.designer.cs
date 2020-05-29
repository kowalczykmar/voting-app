//------------------------------------------------------------------------------
// <generowany automatycznie>
//     Ten kod został wygenerowany przez narzędzie.
//
//     Modyfikacje tego pliku mogą spowodować niewłaściwe zachowanie i zostaną utracone
//     w przypadku ponownego wygenerowania kodu. 
// </generowany automatycznie>
//------------------------------------------------------------------------------

namespace VotingApp
{


    public partial class WebForm1
    {

        /// <summary>
        /// Kontrolka FailureMessage.
        /// </summary>
        /// <remarks>
        /// Wyświetla komunikat błędu w przypadku błędy przy logowaniu.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal FailureMessage;

        /// <summary>
        /// Kontrolka ErrorMessage.
        /// </summary>
        /// <remarks>
        /// Wyświetla komunikat błędu w przypadku błędy przy logowaniu.
        /// </remarks>
        protected global::System.Web.UI.WebControls.PlaceHolder ErrorMessage;

        /// <summary>
        /// Kontrolka FailureText.
        /// </summary>
        /// <remarks>
        /// Wyświetla komunikat błędu w przypadku błędy przy logowaniu.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal FailureText;

        /// <summary>
        /// Kontrolka EmailLabel.
        /// </summary>
        /// <remarks>
        /// Etykieta do pola do wpisania adresu e-mail.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label EmailLabel;

        /// <summary>
        /// Kontrolka EmailTxt.
        /// </summary>
        /// <remarks>
        /// Pole do wpisania adresu e-mail.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox EmailTxt;

        /// <summary>
        /// Kontrolka EmailValidator.
        /// </summary>
        /// <remarks>
        /// Walidator zapewniający, że pole adresu e-mail nie jest puste przy logowaniu.
        /// </remarks>
        protected global::System.Web.UI.WebControls.RequiredFieldValidator EmailValidator;

        /// <summary>
        /// Kontrolka PasswordLabel.
        /// </summary>
        /// <remarks>
        /// Etykieta do pola do wpisania hasła.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label PasswordLabel;

        /// <summary>
        /// Kontrolka PasswordTxt.
        /// </summary>
        /// <remarks>
        /// Pole do wpisania hasła.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox PasswordTxt;

        /// <summary>
        /// Kontrolka PassValidator.
        /// </summary>
        /// <remarks>
        /// Walidator zapewniający, że pole hasła nie jest puste przy logowaniu.
        /// </remarks>
        protected global::System.Web.UI.WebControls.RequiredFieldValidator PassValidator;

        /// <summary>
        /// Kontrolka LoginButton.
        /// </summary>
        /// <remarks>
        /// Przysik logowania. Uruchamia funkcję sprawdzającą, czy podane dane logowania są poprawne.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Button LoginButton;

        /// <summary>
        /// Kontrolka LoggedInText.
        /// </summary>
        /// <remarks>
        /// Pole wyświetlające tekst o wyniku logowaniu lub o tym, że użytkownik jest już zalogowany, kiedy zalogowany użytkownik przejdzie na stronę logowania.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label LoggedInText;
    }
}
