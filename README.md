# GumtreeScraper
A simple application to monitor gumtree for new listing and then alerts a user with a text message

This application uses clicksend.com to send the text messages, to use this application you will need an account. 
Then you enter your login information in the monitor method where the Username and Password field is "CHANGE_ME" 
you can get this information from the dashboard of your clicksend account.

You will also need to update the To value where it is "CHANGE_ME" you have to use the full number for example (+61412345678)
you can also change the From value where it is "Agentspades" to another option that is allowed in your country otherwise can omit this value completely.

Currently the software looks in the bicycles category for the gold coast region to change this update the searchLink variable in the Monitor() method to search for anything you want.

For correct cost estimation you can change the readonly variable COST to equal each message cost for your account/country.
