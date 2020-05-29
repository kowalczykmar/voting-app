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


    public partial class WebForm2
    {

        /// <summary>
        /// Kontrolka ErrorMessage.
        /// </summary>
        /// <remarks>
        /// Wyświetla błąd przy ieudanej rejestracji.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal ErrorMessage;

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
        /// Walidator zapewniający, że pole do wpisania adresu e-mail nie jest puste.
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
        /// Walidator zapewniający, że pole do wpisania hasła nie jest puste.
        /// </remarks>
        protected global::System.Web.UI.WebControls.RequiredFieldValidator PassValidator;

        /// <summary>
        /// Kontrolka ConfirmPasswordLabel.
        /// </summary>
        /// <remarks>
        /// Etykieta do pola do wpisania powtórzonego hasła.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label ConfirmPasswordLabel;

        /// <summary>
        /// Kontrolka ConfirmPasswordTxt.
        /// </summary>
        /// <remarks>
        /// Pole do wpisania powtórzonego hasła.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox ConfirmPasswordTxt;

        /// <summary>
        /// Kontrolka ConfPassValidator.
        /// </summary>
        /// <remarks>
        /// Walidator zapewniający, że pole do wpisania powtórzonego hasła nie jest puste.
        /// </remarks>
        protected global::System.Web.UI.WebControls.RequiredFieldValidator ConfPassValidator;

        /// <summary>
        /// Kontrolka YearText.
        /// </summary>
        /// <remarks>
        /// Etykieta do listy wyboru rocznika.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label YearText;

        /// <summary>
        /// Kontrolka Year.
        /// </summary>
        /// <remarks>
        /// Lista do wyboru rocznika.
        /// </remarks>
        protected global::System.Web.UI.WebControls.DropDownList Year;

        /// <summary>
        /// Kontrolka GroupText.
        /// </summary>
        /// <remarks>
        /// Etykieta do listy wyboru grupy.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label GroupText;

        /// <summary>
        /// Kontrolka Group.
        /// </summary>
        /// <remarks>
        /// Lista do wyboru grupy.
        /// </remarks>
        protected global::System.Web.UI.WebControls.DropDownList Group;

        /// <summary>
        /// Kontrolka RegisterButton.
        /// </summary>
        /// <remarks>
        /// Przycisk rejestracji. Wywołuje metodę odpowiadającą za rejestrację użytkownika i ewentualne wpisanie go do bazy przy sukcesie.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Button RegisterButton;

        /// <summary>
        /// Kontrolka LoggedInText.
        /// </summary>
        /// <remarks>
        /// Pole wyświetlające komunikat o tym, że użytkownik jest już zalogowany. Widoczne, jeśli zalogowany użytkownik przejdzie na stronę rejestracji.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label LoggedInText;
    }
}
