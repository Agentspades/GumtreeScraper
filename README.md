# GumtreeScraper
A simple application to monitor gumtree for new listing and then alerts a user with an SMS message

This application makes use of both clicksend.com (sending sms messages) and Bitly.com (link shortening) so you will accounts for both of these setup.
After creating the required accounts you can edit the information at the top of GUI.cs and this will allow the application to monitor anything you like on gumtree.com.au.
The parameters have been set to "CHANGE_ME" with a comment what each is for, the refresh interval gets a random number appened to it to alow for a more random run of each thread.

This application is easy to setup and use with an easy to use GUI. This has been created using Visual Studio to edit and compile this software with Visual Studio just open the .sln solution file and edit the required params and compile and run.
