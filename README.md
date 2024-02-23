# I CECI ECOMMERCE

[![Demo](https://img.youtube.com/vi/ti_g2uBRbHw/0.jpg)](https://youtu.be/ti_g2uBRbHw) <--- Guarda il video demo. 


## Questa app creata in C# con ASP.NET Framework 8.0 utilizza un database SQL in cloud su Azure Microsoft, in modo da condividere a tutti i collaboratori del progetto un accessibilità ottimale.

### I dati sensibili come le chiavi dei client AUTH0 e la ConnectionString ad SQLDatabase vengono salvati su un file appsettings.json memorizzato nella directory della macchina dello sviluppatore in modo da rimanere nascosto e sicuro, utilizzando i NuGet Package: Microsoft.Extensions.Configuration e Microsoft.Extensions.Configuration.Json: 
     private IConfiguration Configuration { get; }
     public Login()
     {
      Configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .Build();
     }
  

Abbiamo creato un backup del serverl con le query di creazione tabelle e con i dati in vari formati per chi volesse testare l'app, tutto si trova un un branch a parte o dentro il main nella cartella ICeciDatabase.

## Componenti:
  ### Home :
           È la pagina iniziale che mostra la vetrina prodotti e permette all'utente di navigare come, 
           cercare, vedere i dettagli, aggiungere al carrello, registrarsi o fare login.
  ### ProductDetails :
           Una volta cliccato su un prodotto della Home, apre descrizione, rating, nome, 
           prezzo e permette di scegliere la quantità da aquistare con relativo prezzo totale 
           e mandarlo al carrello.
           Se l'utente modifica l'url con un id non disponibile o con qualsiasi stringa viene rimandato alla Home.
  ### Carrello :
           Il carrello mostra tutti gli articoli aggiunti e permette di modificarne le quantità, 
           eliminare un singolo prodotto, svuotare l'intero carrello, 
           visualizzare il totale da pagare e procedere al pagamento.
           Se in modalità ospite il carrello dice all'utente di registrarsi 
           o effettuare l'accesso con due bottoni di scelta.
  ### Checkout : 
           Si apre un form dove inserire i dati personali, 
           di spedizione e aggiungere la carta per procedere 
           al pagamento che dopo il loading e l'esito rimanda alla Home.
  ### SignUp :
           Permette di registrarsi creando un account sul database, 
           che può essere usato nei futuri login memorizzando gli articoli 
           aggiunti al carrello, inoltre permette nel caso di continuare 
           la navigazione come ospite o accedere tramite social.
  ### Login :
          Permette di accedere all'account registrato sul database, 
          consente di continuare come ospite o di accedere coi social.
  ### Admin : 
          La pagina admin è un pannello di controllo visibile solo se 
          l'utente loggato è validato come Admin nel database e consente 
          di modificare, eliminare e aggiungere prodotti, oltre alla 
          navigazione e il test di tutta l'app.
          Anche se l'utente tenta di accedere tramite url viene rimandato 
          alla home.
  ### UserPage : 
          Consente di modificare nome, email, password e immagine profilo 
          agli utenti loggati come clienti, admin o social, nel caso fosse 
          un utente ospite viene visualizzato un bottone di login.
  ### Altri componenti:
          Come css, javascript e vari aspx servono a rendere l'app
          accessibile sia a livello funzionale, eliminando qualsiasi vicolo 
          cieco all'utente e rendendo la navigazione ottimale, sia a livello 
          visivo durante varie transazioni e visualizzazioni.
          
           
