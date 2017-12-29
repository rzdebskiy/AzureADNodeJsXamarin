
# AzureADNodeJsXamarin 

This sample demonstrates how to set up Node.js REST API service using OAuth2 protocol. Then this service is integrated with Azure Active Directory for API protection.  
Xamarin mobile client is used to test access to the service.

REST API service is built using Restify and MongoDB with the following features:
* A Node.js server running a REST API interface with JSON using MongoDB as persistent storage.
* REST APIs leveraging OAuth2 API protection for endpoints using Microsoft Azure Active Directory.

Node.js code is based on [WebAPI-Bearer-NodeJS](https://github.com/AzureADQuickStarts/WebAPI-Bearer-NodeJS) sample.

After installing and configuring REST API service you can use Xamarin client to list, add or delete some tasks on Node.js server using REST API calls. To access REST API a user should be authenticated through Azure Active Directory, get access token and then preset the token to Node.js leveraging OAuth2. For some users in Azure Active Directory tenant a Multi-Factor authentication might be enabled if necessary.

Xamarin code is based on [XamarinFormsMFASample](https://github.com/rzdebskiy/XamarinFormsMFASample). 
General authentication flow for this scenario is illustrated below. For more details please refer to [Authentication Scenarios for Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-authentication-scenarios#native-application-to-web-api).

![Authentication flow](https://github.com/ashapoms/AzureADNodeJsXamarin/blob/master/img/native_app_to_web_api.png)

## Installing and configuring REST API service on Node.js 

### Step 1: Register a Microsoft Azure AD Tenant
To use this sample, you will need a Microsoft Azure Active Directory Tenant. If you're not sure what a tenant is or how you would get one, read [What is an Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/active-directory-whatis)? or [Sign up for Azure as an organization](http://azure.microsoft.com/en-us/documentation/articles/sign-up-organization/). These docs should get you started on your way to using Microsoft Azure AD.

### Step 2: Register your Web API with your Microsoft Azure AD Tenant
After you get your Microsoft Azure AD tenant, add Node.js sample app to your tenant so you can use it to protect your API endpoints. To do that:
1. Login to your [Azure Subscription](https://portal.azure.com/) or [start free trial](https://azure.microsoft.com/en-us/offers/ms-azr-0044p).
2.	Go to “Azure Active Directory” -> “App registrations” and click "New application registration".
![Application registration](https://github.com/ashapoms/AzureADNodeJsXamarin/blob/master/img/AzureADAppRegistration.PNG)
3.	On the “Create” page give your app a name, for example “NodeJSBearerRestServer”, ensure that “Application type” set to “Web app / API”, fill in the “Sign-on URL” field with the value “[http://localhost:3000](http://localhost:3000)” and then click “Create”.
![Create WebApi](https://github.com/ashapoms/AzureADNodeJsXamarin/blob/master/img/CreateWebApiApp.PNG)
4.	Click on just created app (use “Search” field if necessary) and copy “Application ID” (often referred also as “Client ID”). Save this ID somewhere, you will use it in Node.js configuration later.
![ApplicationID](https://github.com/ashapoms/AzureADNodeJsXamarin/blob/master/img/ApplicationID.PNG)
5.	Also, you will need your Azure Active Directory “Tenant ID” (another term is “Directory ID”). On Azure portal go to “Azure Active Directory” -> “Properties”, copy “Directory ID” and save it for later use.
![TenantID](https://github.com/ashapoms/AzureADNodeJsXamarin/blob/master/img/TenantID.PNG)

### Step 3: Download Node.js for your platform
To successfully use this sample, you need a working installation of Node.js.
Install Node.js from [http://nodejs.org](http://nodejs.org/).

### Step 4: Install MongoDB on to your platform
To successfully use this sample, you must have a working installation of MongoDB. We will use MongoDB to make our REST API persistent across server instances.
Install MongoDB from [http://mongodb.org](http://www.mongodb.org/).
**NOTE**: This walkthrough assumes that you use the default installation and server endpoints for MongoDB.

### Step 5: Download the sample applications and modules
Next, clone the sample repo and install the NPM.
From your shell or command line:
```
$ git clone https://github.com/ashapoms/AzureADNodeJsXamarin
$ cd AzureADNodeJsXamarin/RestApiServer/node-server/
$ npm install
```
### Step 6: Configure your server using config.js
Update “identityMetadata” and “clientID” parameters in config.js file with “Tenant ID” and “Client ID” values copied early in Step 2. 
![Update Config.js](https://github.com/ashapoms/AzureADNodeJsXamarin/blob/master/img/ConfigJSUpdate.PNG)

### Step 7: Run the application
```
$ node server.js | bunyan
```
Now you have a server successfully running on http://localhost:3000. Your REST / JSON API Endpoint is [http://localhost:3000/api/tasks](http://localhost:3000/api/tasks). 

## Configuring Xamarin mobile client 

### Step 8: Register your Xamarin native app with your Microsoft Azure AD Tenant
To register your Xamarin app please complete steps 1-5 from [this guide](https://github.com/rzdebskiy/XamarinFormsMFASample).
### Step 9: Update your Xamarin mobile client
Finally, you should update “[MainPage.xaml.cs](https://github.com/ashapoms/AzureADNodeJsXamarin/blob/master/MFATest/MFATest/MainPage.xaml.cs)” with appropriate values.
![Update client](https://github.com/ashapoms/AzureADNodeJsXamarin/blob/master/img/XamarinMainPage.PNG)

## Useful notes, links and resources:

* [Authentication Scenarios for Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-authentication-scenarios)
* [Azure AD token reference](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-token-and-claims)
* [Azure AD Node.js web API getting started](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-devquickstarts-webapi-nodejs)
* [Azure AD Node.js web app getting started](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-devquickstarts-openidconnect-nodejs)

