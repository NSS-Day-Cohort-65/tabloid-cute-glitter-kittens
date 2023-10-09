# Tabloid Full Stack Group Project

## Setup
1. If this repo was generated for you by Github Classroom, clone this repo
1. If this repo is the template repo for this project and you see the "Use this template" button, first create a new repo with the template, and then clone the repo generated for your own account
1. In the top-level directory of the cloned project on your computer, run `dotnet user-secrets init`
1. Run `dotnet user-secrets set AdminPassword password` (you can choose a different password if you wish)
1. Run `dotnet user-secrets set TabloidDbConnectionString 'Host=localhost;Port=5432;Username=postgres;Password=password;Database=Tabloid'`
1. Run `dotnet restore`
1. Run `dotnet build`
1. Run `dotnet ef migrations add InitialCreate`
1. Run `dotnet ef database update`
1. Run `cd client`
1. Run `npm install`

## Test the Setup
1. Start debugging the API and run `npm start` in the `client` directory. 
1. You should see the login view when the UI opens. 
1. Attempt to login with `admina@strator.comx` and the password you set the value of `AdminPassword` to in the user-secrets
1. If the setup succeeded, you should see a welcome message, and a `User Profiles` menu option along with a logout button. 
