# KING_ICT_AKADEMIJA24_StjepanCecura
Repozitorij Stjepana Čečure za DEV test za KING ICT Akademiju 2024

Aplikacija se može testirati tako što se preuzme MicroSoft Visual Studio rješenje i pokrene.
Nakon što se otvori web preglednik, prikaže se nekoliko poglavlja. Implementirana poglavlja su Login i RestApi
Login se može testirati pomoću podataka bilo kojeg korisnika s https://dummyjson.com/users, na primjer: username=emilys, password=emilyspass, expiresInMins=10.

RestApi se može testirati na sljedeće načine:
Dohvačanje svih proizvoda
  Klik na "try it out" gumb pa zatim "execute" gumb
Dohvačanje jednog proizvoda
  Kao i dohvačanje svih proizvoda, uz unošenje jednog broja u polje za unos prije klika na execute
Dohvačanje proizvoda po imenu
  Identično dohvačanju jednog proizvoda preko ID, razlika je da se unosi naziv ili riječ iz naziva umjesto broja, poput riječi "pepper"
Filtriranje
  Unosimo željenu kategoriju, poput "beauty" i cijenu te biramo da li želimo proizvode s večom ili manjom cijenom od navedene
