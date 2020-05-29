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


    public partial class TeacherLogin
    {

        /// <summary>
        /// Kontrolka FailureMessage.
        /// </summary>
        /// <remarks>
        /// Wyświetla tekst o błędzie w przypadku niepowodzenia logowania.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal FailureMessage;

        /// <summary>
        /// Kontrolka ErrorMessage.
        /// </summary>
        /// <remarks>
        /// Wyświetla tekst o błędzie w przypadku niepowodzenia logowania.
        /// </remarks>
        protected global::System.Web.UI.WebControls.PlaceHolder ErrorMessage;

        /// <summary>
        /// Kontrolka FailureText.
        /// </summary>
        /// <remarks>
        /// Wyświetla tekst o błędzie w przypadku niepowodzenia logowania.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal FailureText;

        /// <summary>
        /// Kontrolka EmailLabel.
        /// </summary>
        /// <remarks>
        /// Etykieta do pola do wpisania loginu prowadzącego.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label EmailLabel;

        /// <summary>
        /// Kontrolka EmailTxt.
        /// </summary>
        /// <remarks>
        /// Pole do wpisania loginu prowadzącego.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox EmailTxt;

        /// <summary>
        /// Kontrolka EmailValidator.
        /// </summary>
        /// <remarks>
        /// Walidator służący upewnieniu się, że pole loginu nie będzie puste przy logowaniu.
        /// </remarks>
        protected global::System.Web.UI.WebControls.RequiredFieldValidator EmailValidator;

        /// <summary>
        /// Kontrolka PasswordLabel.
        /// </summary>
        /// <remarks>
        /// Etykieta do pola do wpisania hasła prowadzącego.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label PasswordLabel;

        /// <summary>
        /// Kontrolka PasswordTxt.
        /// </summary>
        /// <remarks>
        /// Pole do wpisania hasła prowadzącego.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox PasswordTxt;

        /// <summary>
        /// Kontrolka PassValidator.
        /// </summary>
        /// <remarks>
        /// Walidator służący upewnieniu się, że pole hasła nie będzie puste przy logowaniu.
        /// </remarks>
        protected global::System.Web.UI.WebControls.RequiredFieldValidator PassValidator;

        /// <summary>
        /// Kontrolka LoginButton.
        /// </summary>
        /// <remarks>
        /// Przycisk logowania. Wywołuje metodą odpowiedzialną za zalogowanie prowadzącego.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Button LoginButton;

        /// <summary>
        /// Kontrolka LoggedInText.
        /// </summary>
        /// <remarks>
        /// Pole wyświetlające komunikat, jeśli prowadzący jest już zalogowany.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label LoggedInText;
    }
}
