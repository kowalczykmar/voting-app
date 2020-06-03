---
title: Dokumentacja projektu VotingApp
---

# VotingApp

<table>
<tbody>
<tr>
<td><a href="#_default">_Default</a></td>
<td><a href="#sitemaster">SiteMaster</a></td>
</tr>
<tr>
<td><a href="#teacherdefault">TeacherDefault</a></td>
<td><a href="#teacherlogin">TeacherLogin</a></td>
</tr>
<tr>
<td><a href="#webform1">WebForm1</a></td>
<td><a href="#webform2">WebForm2</a></td>
</tr>
</tbody>
</table>


## _Default

Strona główna aplikacji - służy do przesyłania opinii.

Klasy strony głównej z kontrolkami ASP.NET

### CheckboxList1

Kontrolka CheckboxList1.

#### Remarks

Lista pól wielokrotnego wyboru dla przedmiotu pierwszego.

### CheckboxList2

Kontrolka CheckboxList2.

#### Remarks

Lista pól wielokrotnego wyboru dla przedmiotu drugiego.

### CheckboxList3

Kontrolka CheckboxList3.

#### Remarks

Lista pól wielokrotnego wyboru dla przedmiotu trzeciego.

### CheckboxText1

Kontrolka CheckboxText1.

#### Remarks

Tekst do listy pól wielokrotnego wyboru dla przedmiotu pierwszego.

### CheckboxText2

Kontrolka CheckboxText2.

#### Remarks

Tekst do listy pól wielokrotnego wyboru dla przedmiotu drugiego.

### CheckboxText3

Kontrolka CheckboxText3.

#### Remarks

Tekst do listy pól wielokrotnego wyboru dla przedmiotu trzeciego.

### CheckClick1(sender, e)

Przycisk do sprawdzenia czy opinia do przedmiotu pierwszego została poprawnie zapisana w bazie

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Pobiera unikalny kod i sprawdza kody tworzone dla wszystkich opinii zapisanych w bazie.

W przypadku sukcesu pola do wpisywania kodu oraz przycisk nie są dłużej wyświetlane na stronie.


### CheckClick2(sender, e)

Przycisk do sprawdzenia czy opinia do przedmiotu drugiego została poprawnie zapisana w bazie

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Pobiera unikalny kod i sprawdza kody tworzone dla wszystkich opinii zapisanych w bazie.

W przypadku sukcesu pola do wpisywania kodu oraz przycisk nie są dłużej wyświetlane na stronie.


### CheckClick3(sender, e)

Przycisk do sprawdzenia czy opinia do przedmiotu trzeciego została poprawnie zapisana w bazie

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Pobiera unikalny kod i sprawdza kody tworzone dla wszystkich opinii zapisanych w bazie.

W przypadku sukcesu pola do wpisywania kodu oraz przycisk nie są dłużej wyświetlane na stronie.


### CheckOpinionBtn1

Kontrolka CheckOpinionBtn1.

#### Remarks

Przycisk do przesłania unikalnego kodu dla przedmiotu pierwszego.

### CheckOpinionBtn2

Kontrolka CheckOpinionBtn2.

#### Remarks

Przycisk do przesłania unikalnego kodu dla przedmiotu drugiego.

### CheckOpinionBtn3

Kontrolka CheckOpinionBtn3.

#### Remarks

Przycisk do przesłania unikalnego kodu dla przedmiotu trzeciego.

### Code1

Kontrolka Code1.

#### Remarks

Pole do wpisania unikalnego kodu do sprawdzania czy opinia dla przedmiotu pierwszego jest poprawnie zapisana w bazie.

### Code2

Kontrolka Code2.

#### Remarks

Pole do wpisania unikalnego kodu do sprawdzania czy opinia dla przedmiotu drugiego jest poprawnie zapisana w bazie.

### Code3

Kontrolka Code3.

#### Remarks

Pole do wpisania unikalnego kodu do sprawdzania czy opinia dla przedmiotu trzeciego jest poprawnie zapisana w bazie.

### ComputeSha256Hash(rawData)

Funkcja hashująca

| Name | Description |
| ---- | ----------- |
| rawData | *System.String*<br> |

#### Returns

Skrót wporwadzonego tekstu

#### Remarks

Służy do tworzenia skrótu unikalnego kodu po przesłaniu opinii.

### Decrypt(cipherText)

Funkcja do odszyfrowywania.

| Name | Description |
| ---- | ----------- |
| cipherText | *System.String*<br> |

#### Returns

Odszyfrowany tekst

#### Remarks

Jest funkcją odwrotną do Encrypt, używamy jej, aby sprawdzić czy opinia o podanym unikalnym kodzie jest zapisana poprawnie w bazie.

### Encrypt(clearText)

Funkcja do szyfrowania opinii

| Name | Description |
| ---- | ----------- |
| clearText | *System.String*<br> |

#### Returns

Zaszyfrowany tekst w formie tekstowej

#### Remarks

Funkcja szyfruje tekst w oparciu o algorytm AES oraz klucz, który znajduje się w niedostępnym dla administratora pliku zewnętrznym.

### GetIndexesforOpinion(nr)

Metoda zczytuje zaznaczone opcje wielokrotnego wyboru

| Name | Description |
| ---- | ----------- |
| nr | *System.Int32*<br> |

#### Returns

Indeksy w formie ciągu znaków

#### Remarks


Jeśli nie została zaznaczona żadna opcja, zwraca pusty ciąg.

Numer nr przekazywany metodzie decyduje o tym, opinie dla którego przedmiotu bierzemy pod uwagę.


### GetSubjects

Metoda pobierająca przedmioty z tabeli z użytkownikami i zapisująca je w zmiennych sesyjnych.

### InsertOpinion(opinion, nr)

Metoda służąca wprowadzaniu opinii do bazy

| Name | Description |
| ---- | ----------- |
| opinion | *System.String*<br> |
| nr | *System.Int32*<br> |

#### Remarks


Metoda ta pobiera tekst opinii oraz numer nr, czyli informację, do którego przedmiotu opinia ta się odnosi

Metoda zapisuje w tabeli z opiniami koemntarz słowny oraz zaznaczone opcje jednokrotnego i wielokrotnego wyboru w formie zaszyfrowanej wraz z informacją o roku, grupie, przedmiocie i prowadzącym zajęcia.

Metoda ta również zapisuje w tabeli użytkowników, którzy przesłali opinię nazwę użytkownika wraz z rokiem, grupą oraz przedmiotem i prowadzącym, którego opinia się tyczy.

Metoda ta korzysta z metod ReadUser oraz GetIndexesforOpinion


### NotLoggedIn1

Kontrolka NotLoggedIn1.

#### Remarks

Wyświetla tekst o konieczności zalogowania dla użytkownika niezalogowanego przy polu opinii do pierwszego przedmiotu.

### NotLoggedIn2

Kontrolka NotLoggedIn2.

#### Remarks

Wyświetla tekst o konieczności zalogowania dla użytkownika niezalogowanego przy polu opinii do drugiego przedmiotu.

### NotLoggedIn3

Kontrolka NotLoggedIn3.

#### Remarks

Wyświetla tekst o konieczności zalogowania dla użytkownika niezalogowanego przy polu opinii do trzeciego przedmiotu.

### Opinion1

Kontrolka Opinion1.

#### Remarks

Służy wpisywaniu opinii słownej do przedmiotu pierwszego.

### Opinion2

Kontrolka Opinion2.

#### Remarks

Służy wpisywaniu opinii słownej do przedmiotu drugiego.

### Opinion3

Kontrolka Opinion3.

#### Remarks

Służy wpisywaniu opinii słownej do przedmiotu trzeciego.

### OpinionCode(opinion)

Metoda tworząca unikalny kod na podstawie przesłanej opinii i nazwy użytkownika i hashuje go

| Name | Description |
| ---- | ----------- |
| opinion | *System.String*<br> |

#### Returns

Ciąg cyfrowo-znakowy

#### Remarks

Kod nie jest nigdzie zapisywany - użytkownik musi go przechować we własnym zakresie, jeśli chce z niego później skorzystać

### OpinionValidator1

Kontrolka OpinionValidator1.

#### Remarks

Walidator służący zapewnieniu, że pole z opinią do przedmiotu pierwszego nie będzie puste przy przesyłaniu opinii.

### OpinionValidator2

Kontrolka OpinionValidator2.

#### Remarks

Walidator służący zapewnieniu, że pole z opinią do przedmiotu drugiego nie będzie puste przy przesyłaniu opinii.

### OpinionValidator3

Kontrolka OpinionValidator3.

#### Remarks

Walidator służący zapewnieniu, że pole z opinią do przedmiotu trzeciego nie będzie puste przy przesyłaniu opinii.

### Page_Load(sender, e)

Przy wywołaniu strony Default sprawdzamy, czy użytkownik jest zalogowany i w zależności od tego wyświetlamy funkcjonalności, bądź nie.

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Jeśli zalogowany jest prowadzący, strona przekierowuje na stronę główną panelu dla prowadzących

Jeśli użytkownik nie jest zalogowany (rozponanie następuje po zczytaniu nazwy użytkownika z ciasteczka oraz zmiennej sesyjnej), nie są wyświetlane żadne pola do przesyłania opinii, jedynie komentarz, aby się zalogował. Jeśli jest zalogowany, dostępne są pola do przesyłania opinii (komentarz słowny, pola jednokrotnego oraz wielokrotnego wyboru). Wyświetlane są jedynie te, dla których nie została przesłana jeszcze opinia. Jeśli opinia dla któregoś przedmiotu została już przesłana, wyświetlane jest jedynie pole do wpisania unikalnego kodu umożliwiającego sprawdzenie, czy opinia jest poprawnie zapisana w bazie.

korzysta z metod ReadCookie, GetSubjects, UserOpinionCheck


### RadioButtonList1

Kontrolka RadioButtonList1.

#### Remarks

Lista pól jednokrotnego wyboru (ocena zajęć w skali 1-5) dla przemdiotu pierwszego.

### RadioButtonList2

Kontrolka RadioButtonList2.

#### Remarks

Lista pól jednokrotnego wyboru (ocena zajęć w skali 1-5) dla przemdiotu drugiego.

### RadioButtonList3

Kontrolka RadioButtonList3.

#### Remarks

Lista pól jednokrotnego wyboru (ocena zajęć w skali 1-5) dla przemdiotu trzeciego.

### RadioButtonText1

Kontrolka RadioButtonText1.

#### Remarks

Tekst do listy pól jednokrotnego wyboru (ocena zajęć w skali 1-5) dla przemdiotu pierwszego.

### RadioButtonText2

Kontrolka RadioButtonText2.

#### Remarks

Tekst do listy pól jednokrotnego wyboru (ocena zajęć w skali 1-5) dla przemdiotu drugiego.

### RadioButtonText3

Kontrolka RadioButtonText3.

#### Remarks

Tekst do listy pól jednokrotnego wyboru (ocena zajęć w skali 1-5) dla przemdiotu trzeciego.

### ReadCookie

Funkcja służy odczytywaniu informacji z ciasteczka po stronie użytkownika

#### Returns

Nazwę użytkownika

#### Remarks

Zwraca 1, jeśli ciasteczko nie istnieje lub jeśli użytkownik nie jest zalogowany, lub zaszyfrowaną nazwę użytkownika, jeśli jest zalogowany.

### ReadUser

Funkcja do odczytywania zaszyfrowanej nazwy użytkownika

#### Returns

Odszyfrowaną nazwę użytkownika

#### Remarks

Jeśli ciasteczko nie istnieje, zwraca 1. Używa do odszyfrowania klucza prywatnego zapisanego w ciasteczku oraz algorytmu RSA

### RequiredFieldValidator1

Kontrolka RequiredFieldValidator1.

#### Remarks

Walidator służący zapewnieniu, że pole jednokrotnego wyboru dla przedmiotu pierwszego nie będzie puste przy przesyłaniu opinii.

### RequiredFieldValidator2

Kontrolka RequiredFieldValidator2.

#### Remarks

Walidator służący zapewnieniu, że pole jednokrotnego wyboru dla przedmiotu drugiego nie będzie puste przy przesyłaniu opinii.

### RequiredFieldValidator3

Kontrolka RequiredFieldValidator3.

#### Remarks

Walidator służący zapewnieniu, że pole jednokrotnego wyboru dla przedmiotu trzeciego nie będzie puste przy przesyłaniu opinii.

### ShuffleOpinionsTable

Metoda zmieniająca losowo kolejność wpisów w tabeli z przesłanymi opiniami

#### Remarks

Przemieszanie wpisów służy zaciemnianiu obrazu danych przed administratorem oraz prowadzącym.

### ShuffleUsersWithOpinionsTable

Metoda zmieniająca losowo kolejność wpisów w tabeli z użytkownikami, którzy wysłali już opinię

#### Remarks

Przemieszanie wpisów służy zaciemnianiu obrazu danych przed administratorem oraz prowadzącym.

### Subject1

Kontrolka Subject1.

#### Remarks

Wyświetla nazwę przedmiotu pierwszego.

### Subject2

Kontrolka Subject2.

#### Remarks

Wyświetla nazwę przedmiotu drugiego.

### Subject3

Kontrolka Subject3.

#### Remarks

Wyświetla nazwę przedmiotu trzeciego.

### Submit1Click(sender, e)

Wywołanie akcji w wyniku kliknięcia przyscisku przesłania opinii przedmiotu pierwszego

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Wywołuje metodę InsertOpinion w celu wprowadzenia opinii do bazy.

Odpowiada za zniknięcie ze strony pól do przesyłania opinii oraz wyświetlenie pól z tekstem podziękowania oraz wyświetleniem unikalnego kodu do sprawdzenia czy opinia została poprawnie zapisana w bazie jak i wyświetlenie pola do wpisania kodu.

Wywołuje metody odpowiedzialne za przemiszanie tabel po dodaniu opinii.


### Submit2Click(sender, e)

Wywołanie akcji w wyniku kliknięcia przyscisku przesłania opinii przedmiotu drugiego

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Wywołuje metodę InsertOpinion w celu wprowadzenia opinii do bazy.

Odpowiada za zniknięcie ze strony pól do przesyłania opinii oraz wyświetlenie pól z tekstem podziękowania oraz wyświetleniem unikalnego kodu do sprawdzenia czy opinia została poprawnie zapisana w bazie jak i wyświetlenie pola do wpisania kodu.

Wywołuje metody odpowiedzialne za przemiszanie tabel po dodaniu opinii.


### Submit3Click(sender, e)

Wywołanie akcji w wyniku kliknięcia przyscisku przesłania opinii przedmiotu trzeciego

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Wywołuje metodę InsertOpinion w celu wprowadzenia opinii do bazy.

Odpowiada za zniknięcie ze strony pól do przesyłania opinii oraz wyświetlenie pól z tekstem podziękowania oraz wyświetleniem unikalnego kodu do sprawdzenia czy opinia została poprawnie zapisana w bazie jak i wyświetlenie pola do wpisania kodu.

Wywołuje metody odpowiedzialne za przemiszanie tabel po dodaniu opinii.


### SubmitButton1

Kontrolka SubmitButton1.

#### Remarks

Przycisk do przesłania opinii dla przedmiotu pierwszego.

### SubmitButton2

Kontrolka SubmitButton2.

#### Remarks

Przycisk do przesłania opinii dla przedmiotu drugiego.

### SubmitButton3

Kontrolka SubmitButton3.

#### Remarks

Przycisk do przesłania opinii dla przedmiotu trzeciego.

### Teacher1

Kontrolka Teacher1.

#### Remarks

Wyświetla prowadzącego przedmiotu pierwszego.

### Teacher2

Kontrolka Teacher2.

#### Remarks

Wyświetla prowadzącego przedmiotu drugiego.

### Teacher3

Kontrolka Teacher3.

#### Remarks

Wyświetla prowadzącego przedmiotu trzeciego.

### UserOpinionCheck(nr)

Metoda sprawdzająca, czy dla danego przedmiotu opinia została już przesłana

| Name | Description |
| ---- | ----------- |
| nr | *System.Int32*<br> |

#### Returns

Wartość logiczną

#### Remarks

Przekzywany metodzie numer nr decyduje o tym, który przedmiot jest sprawdzany pod kątem przesłania opinii.


## SiteMaster

Klasa MasterPage, która odpowiada za część wspólnych funkcjonalności wszytskich stron, np. za odpowiednie wyświetlanie nagłówka.

### LoginButton

Kontrolka LoginButton.

#### Remarks

Przycisk logowania.

### LoginClick(sender, e)

Metoda przycisku logowania

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Jeśli użytkownik jest zalogowany, służy wylogowaniu. Wtedy nadpisuje ciasteczko nowym, w którym nazwa użytkownika to 1

Dla niezalogowanego użytkownika kieruje na stronę logowania

Dla zalogowanego prowadzącego służy do wylogowania. Wtedy usuwa zmienną sesyjną przechowującą informację o zalogowanym prowadzącym.


### Page_Load(sender, e)

Metoda wywoływana przy załadowaniu strony.

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks

Jeśli użytkownik jest już zalogowany, zmienia treść przycisku logowania na "Wyloguj się" oraz ukrywa przycisk rejestracji.

### ReadCookie

Metoda odczytująca nazwę użytkownika z ciasteczka.

#### Returns

Zaszyfrowaną nazwę użytkownika lub 1 dla niezalogowanego użytkownika

### RegisterButton

Kontrolka RegisterButton.

#### Remarks

Przycisk rejestracji.

### RegisterClick(sender, e)

Przycisk rejestracji, kieruje niezalogowanego użytkownika na stronę rejestracji.

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

### TeacherButton

Kontrolka TeacherButton.

#### Remarks

Przycisk panelu dla prowadzących.

### TeacherClick(sender, e)

Metoda przycisku Panel dla prowadzących.

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks

Kieruje zalogowanego prowadzącego na stronę główną panelu dla prowadzących, gdzie wyświetlane są opinie o jego przediotach. Niezalogowanego użytkownika kieruje na stronę logowania dla prowadzących.


## TeacherDefault

Klasa strony głównej Panelu dla prowadzących

### Average1

Kontrolka Average1.

#### Remarks

Pole z wypisaną średnią ocen dla przedmiotu pierwszego.

### Average2

Kontrolka Average2.

#### Remarks

Pole z wypisaną średnią ocen dla przedmiotu drugiego.

### Average3

Kontrolka Average3.

#### Remarks

Pole z wypisaną średnią ocen dla przedmiotu trzeciego.

### Decrypt(cipherText)

Metoda odszyfrowująca opinie.

| Name | Description |
| ---- | ----------- |
| cipherText | *System.String*<br> |

#### Returns

Odszyfrowaną treść opinii słownej

### GetData(groupnr)

Metoda zaciągająca dane z tabel z opiniami oraz użytkownikami, którzy przesłali opinie i wypełnia nimi tabele na stronie.

| Name | Description |
| ---- | ----------- |
| groupnr | *System.Int32*<br> |

#### Remarks


W zależności od przekazanego numer grupy przypisuje do wewnętrznej zmiennej odpowiednią nazwę grupy oraz wypełnia odpowiednie tabele na stronie.

W pierwszym kroku metoda zaciąga słowne opinie o przemdiocie i odszyfrowuje je oraz usuwa ostatni wiersz, jeśli ilość wierszy jest nieparzysta.

W następnym kroku pobiera dane o użytkownikach, którzy wysłali opinię do odpowiedniego przedmiotu.

Następnie pobiera dane o zaznaczonych opcjach wyboru wielokrotnego (ucinając ostatni nieparzysty wiersz), odszyfrowuje a następnie odczytuje zapisane indeksy opinii oraz przypisuje ilości zaznaczonych opcji do pomocniczej tabeli

Następnie pobiera dane o zaznaczonych opcjach wyboru jednokrotnego (ucinając ostatni nieparzysty wiersz), odszyfrowuje a następnie odczytuje zapisane indeksy opinii oraz przypisuje ilości zaznaczonych opcji do pomocniczej tabeli, a także wylicza średnią ocen

W ostatnim kroku przypisuje odpowiednie tabele do tabeli wyświetlanych na stronie celem zaprezentowania odpowiednich danych


### Header1

Kontrolka Header1.

#### Remarks

Tytuł do tabel dla przedmiotu pierwszego.

### Header2

Kontrolka Header2.

#### Remarks

Tytuł do tabel dla przedmiotu drugiego.

### Header3

Kontrolka Header3.

#### Remarks

Tytuł do tabel dla przedmiotu trzeciego.

### OpinionIndexes1

Kontrolka OpinionIndexes1.

#### Remarks

Tabela z ilością zaznaczonych opcji wielokrotnego wyboru do przedmiotu pierwszego.

### OpinionIndexes2

Kontrolka OpinionIndexes2.

#### Remarks

Tabela z ilością zaznaczonych opcji wielokrotnego wyboru do przedmiotu drugiego.

### OpinionIndexes3

Kontrolka OpinionIndexes3.

#### Remarks

Tabela z ilością zaznaczonych opcji wielokrotnego wyboru do przedmiotu trzeciego.

### OpinionNumbers1

Kontrolka OpinionNumbers1.

#### Remarks

Tabela z ilością zaznaczonych opcji jednokrotnego wyboru do przemdiotu pierwszego.

### OpinionNumbers2

Kontrolka OpinionNumbers2.

#### Remarks

Tabela z ilością zaznaczonych opcji jednokrotnego wyboru do przemdiotu drugiego.

### OpinionNumbers3

Kontrolka OpinionNumbers3.

#### Remarks

Tabela z ilością zaznaczonych opcji jednokrotnego wyboru do przemdiotu trzeciego.

### Opinions1

Kontrolka Opinions1.

#### Remarks

Tabela z opiniami słownymi do przedmiotu pierwszego.

### Opinions2

Kontrolka Opinions2.

#### Remarks

Tabela z opiniami słownymi do przedmiotu drugiego.

### Opinions3

Kontrolka Opinions3.

#### Remarks

Tabela z opiniami słownymi do przedmiotu trzeciego.

### Page_Load(sender, e)

Metoda wywoływana przy załadowaniu strony głównej panelu dla prowadzących.

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks

Jeśli żaden prowadzący nie jest zalogowany, przekierowuje na stronę logowania dla prowadzących. Jeśli jest, odczytuje odpowiednie nazwy przedmiotów z zmiennych sesyjnych i przypisuje je do nagłówków nad tabelami. Wywołuje odpowiednie metody GetData celem wypełnienia tabel z opiniami o przedmiotach

### UsersWithOpinionSend1

Kontrolka UsersWithOpinionSend1.

#### Remarks

Tabela z użytkownikami, którzy wysłali opinię do przedmiotu pierwszego.

### UsersWithOpinionSend2

Kontrolka UsersWithOpinionSend2.

#### Remarks

Tabela z użytkownikami, którzy wysłali opinię do przedmiotu drugiego.

### UsersWithOpinionSend3

Kontrolka UsersWithOpinionSend3.

#### Remarks

Tabela z użytkownikami, którzy wysłali opinię do przedmiotu trzeciego.


## TeacherLogin

klasa strony do logowania dla prowadzących.

### EmailLabel

Kontrolka EmailLabel.

#### Remarks

Etykieta do pola do wpisania loginu prowadzącego.

### EmailTxt

Kontrolka EmailTxt.

#### Remarks

Pole do wpisania loginu prowadzącego.

### EmailValidator

Kontrolka EmailValidator.

#### Remarks

Walidator służący upewnieniu się, że pole loginu nie będzie puste przy logowaniu.

### ErrorMessage

Kontrolka ErrorMessage.

#### Remarks

Wyświetla tekst o błędzie w przypadku niepowodzenia logowania.

### FailureMessage

Kontrolka FailureMessage.

#### Remarks

Wyświetla tekst o błędzie w przypadku niepowodzenia logowania.

### FailureText

Kontrolka FailureText.

#### Remarks

Wyświetla tekst o błędzie w przypadku niepowodzenia logowania.

### LoggedInText

Kontrolka LoggedInText.

#### Remarks

Pole wyświetlające komunikat, jeśli prowadzący jest już zalogowany.

### LoginButton

Kontrolka LoginButton.

#### Remarks

Przycisk logowania. Wywołuje metodą odpowiedzialną za zalogowanie prowadzącego.

### LoginClick(sender, e)

Metoda wywoływana przy naciśnięciu przycisku logowania.

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks

Sprawdza czy login i hasło są prawidłowe. Przy powodzeniu zapisuje informację o zalogowanym prowadzącym w zmiennej sesyjnej oraz przekierowuje na stronę główną panelu dla prowadzących. Przy niepowodzeniu wyświetla odpowiedni komunikat.

### Page_Load(sender, e)

Metoda wywoływana przy załadowaniu strony

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks

Jeśli prowadzący jest już zalogowany, wyświetla odpowiedni komunikat i ukrywa pola logowania.

### PassValidator

Kontrolka PassValidator.

#### Remarks

Walidator służący upewnieniu się, że pole hasła nie będzie puste przy logowaniu.

### PasswordLabel

Kontrolka PasswordLabel.

#### Remarks

Etykieta do pola do wpisania hasła prowadzącego.

### PasswordTxt

Kontrolka PasswordTxt.

#### Remarks

Pole do wpisania hasła prowadzącego.

### ReadSubject

Odczytuje przedmioty prowadzącego i zapisuje w zmiennych sesyjnych.


## WebForm1

Klasa strony logowania

### EmailCheck(email)

Metoda do sprawdzania, czy podany mail istnieje już w bazie

| Name | Description |
| ---- | ----------- |
| email | *System.String*<br> |

#### Returns

Wartość logiczną

### EmailLabel

Kontrolka EmailLabel.

#### Remarks

Etykieta do pola do wpisania adresu e-mail.

### EmailTxt

Kontrolka EmailTxt.

#### Remarks

Pole do wpisania adresu e-mail.

### EmailValidator

Kontrolka EmailValidator.

#### Remarks

Walidator zapewniający, że pole adresu e-mail nie jest puste przy logowaniu.

### Encrypt(clearText)

Metoda służąca do szyfrowania

| Name | Description |
| ---- | ----------- |
| clearText | *System.String*<br> |

#### Returns

Zaszyfrowany ciąg znaków

#### Remarks

Służy do sprawdzania podanego hasła z zaszyfrowanym hasłem podanym przy rejestracji.

### ErrorMessage

Kontrolka ErrorMessage.

#### Remarks

Wyświetla komunikat błędu w przypadku błędy przy logowaniu.

### FailureMessage

Kontrolka FailureMessage.

#### Remarks

Wyświetla komunikat błędu w przypadku błędy przy logowaniu.

### FailureText

Kontrolka FailureText.

#### Remarks

Wyświetla komunikat błędu w przypadku błędy przy logowaniu.

### GetGroupID(email)

Pobiera grupę użytownika na podstawie podanego maila.

| Name | Description |
| ---- | ----------- |
| email | *System.String*<br> |

#### Returns

ID grupy użytkownika

### GetTeachers(email)

Pobiera prowadzących użytkownika na podstawie maila oraz zapisuje ich w zmiennych sesyjnych.

| Name | Description |
| ---- | ----------- |
| email | *System.String*<br> |

### GetYear(email)

Pobiera rocznik na podstawie podanego maila

| Name | Description |
| ---- | ----------- |
| email | *System.String*<br> |

#### Returns

Rocznik w formie liczby całkowitej

### LoggedInText

Kontrolka LoggedInText.

#### Remarks

Pole wyświetlające tekst o wyniku logowaniu lub o tym, że użytkownik jest już zalogowany, kiedy zalogowany użytkownik przejdzie na stronę logowania.

### LoginButton

Kontrolka LoginButton.

#### Remarks

Przysik logowania. Uruchamia funkcję sprawdzającą, czy podane dane logowania są poprawne.

### LoginClick(sender, e)

Metoda wywoływana przez przycisk logowania.

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Sprawdza czy podany mail istnieje w bazie i jeśli tak, sprawdza czy hasło zgadza się z tym podanym przy rejestracji

W przypadku sukcesu przekierowuje na stronę główną oraz zapisuje w zmiennych sesyjnych informację o tym, że użytkownik jest zalogowany oraz o jego roczniku, grupie, przedmiotach.


### Page_Load(sender, e)

Funkcja wywoływana przy ładowaniu strony logowania

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Funkcja sprawdza czy użytkownik jest już zalogowany. Dla zalogowanego zamiast pól do logowania jest wyświetlany komunikat.

Korzysta z metody ReadCookie


### PassCheck(email, pass)

Metoda do sprawdzania, czy dla danego maila podane hasło jest prawidłowe

| Name | Description |
| ---- | ----------- |
| email | *System.String*<br> |
| pass | *System.String*<br> |

#### Returns

Wartość logiczną

### PassValidator

Kontrolka PassValidator.

#### Remarks

Walidator zapewniający, że pole hasła nie jest puste przy logowaniu.

### PasswordLabel

Kontrolka PasswordLabel.

#### Remarks

Etykieta do pola do wpisania hasła.

### PasswordTxt

Kontrolka PasswordTxt.

#### Remarks

Pole do wpisania hasła.

### ReadCookie

Odczytuje zaszyfrowaną nazwę użytkowika z ciasteczka.

#### Returns

Zaszyfrowaną nazwę użytkownika lub 1, jeśli nie jest zalogowany

### SetCookie(username)

Ustawia po stronie użytkownika ciasteczko z nazwą użytkownika oraz kluczem szyfrującym po zalogowaniu.

| Name | Description |
| ---- | ----------- |
| username | *System.String*<br> |

#### Remarks

Po udanym logowaniu zapisuje w ciasteczku zaszyfrowaną nazwę użytkownika oraz klucz prywatny algorytmu RSa do odszfyrowania tej nazwy na innych podstronach aplikacji.


## WebForm2

Klasa strony rejestracji.

### ConfirmPasswordLabel

Kontrolka ConfirmPasswordLabel.

#### Remarks

Etykieta do pola do wpisania powtórzonego hasła.

### ConfirmPasswordTxt

Kontrolka ConfirmPasswordTxt.

#### Remarks

Pole do wpisania powtórzonego hasła.

### ConfPassValidator

Kontrolka ConfPassValidator.

#### Remarks

Walidator zapewniający, że pole do wpisania powtórzonego hasła nie jest puste.

### EmailCheck(email)

Metoda sprawdzająca czy podany mail istnieje już w bazie.

| Name | Description |
| ---- | ----------- |
| email | *System.String*<br> |

#### Returns

Wartość logiczną

### EmailLabel

Kontrolka EmailLabel.

#### Remarks

Etykieta do pola do wpisania adresu e-mail.

### EmailTxt

Kontrolka EmailTxt.

#### Remarks

Pole do wpisania adresu e-mail.

### EmailValidator

Kontrolka EmailValidator.

#### Remarks

Walidator zapewniający, że pole do wpisania adresu e-mail nie jest puste.

### Encrypt(clearText)

Metoda służąca szyfrowaniu hasła

| Name | Description |
| ---- | ----------- |
| clearText | *System.String*<br> |

#### Returns

Zaszyfrowany ciąg znaków

### ErrorMessage

Kontrolka ErrorMessage.

#### Remarks

Wyświetla błąd przy ieudanej rejestracji.

### Group

Kontrolka Group.

#### Remarks

Lista do wyboru grupy.

### GroupText

Kontrolka GroupText.

#### Remarks

Etykieta do listy wyboru grupy.

### InsertRecord(email, password, groupid)

Metoda odpowiadając za wpisanie nowe użytkownika do tabeli Users.

| Name | Description |
| ---- | ----------- |
| email | *System.String*<br> |
| password | *System.String*<br> |
| groupid | *System.String*<br> |

#### Remarks

W pierwszym kroku metoda pobiera na podstawie grupy oraz rocznika przedmioty, aby wpisać je następnie wraz z użytkownikiem i hasłem w odpowiednie pola w tabeli.

### LoggedInText

Kontrolka LoggedInText.

#### Remarks

Pole wyświetlające komunikat o tym, że użytkownik jest już zalogowany. Widoczne, jeśli zalogowany użytkownik przejdzie na stronę rejestracji.

### Page_Load(sender, e)

Metoda wywoływana przy załadowaniu strony rejestracji

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks

Metoda sprawdza, czy użytkownik jest już zalogowany. Dla zalogowanego użytkownika zamiast pól rejestracji wyświetlany jest komunikat.

### PassValidator

Kontrolka PassValidator.

#### Remarks

Walidator zapewniający, że pole do wpisania hasła nie jest puste.

### PasswordLabel

Kontrolka PasswordLabel.

#### Remarks

Etykieta do pola do wpisania hasła.

### PasswordTxt

Kontrolka PasswordTxt.

#### Remarks

Pole do wpisania hasła.

### ReadCookie

Metoda odczytująca nazwę użytkownika z ciasteczka.

#### Returns

Zaszyfrowaną nazwę użytkownika lub 1, jeśli nie jest zalogowany

### RegisterButton

Kontrolka RegisterButton.

#### Remarks

Przycisk rejestracji. Wywołuje metodę odpowiadającą za rejestrację użytkownika i ewentualne wpisanie go do bazy przy sukcesie.

### RegisterClick(sender, e)

Metoda przycisku rejestracji.

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br> |
| e | *System.EventArgs*<br> |

#### Remarks


Metoda w kolejności sprawdza, czy podany mail jest w porpawnej domenie (student.up.krakow.pl), czy mail istnieje już w bazie, czy podane hasło oraz powtórzone hasło są takie samo oraz czy hasła spełnia odpowiednie kryteria (metoda ValidatePassword)

W przypadku sukcesu zapisuje użytkownika oraz hasło w bazie Users oraz przekierowuje na stronę logowania.


### ValidatePassword(password)

Metoda sprawdzająca, czy hasło jest odpowiednio silne.

| Name | Description |
| ---- | ----------- |
| password | *System.String*<br> |

#### Returns

Wartość logiczną

#### Remarks

Sprawdza w kolejności: czy hasło ma przynajmniej 8 znaków czy hasło zawiera min. 1 dużą literę, czy zawiera min. 1 cyfrę oraz min. 1 znak specjalny

### Year

Kontrolka Year.

#### Remarks

Lista do wyboru rocznika.

### YearText

Kontrolka YearText.

#### Remarks

Etykieta do listy wyboru rocznika.
