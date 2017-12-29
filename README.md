
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
1.	Login to your Azure Subscription or start free trial.
2.	Go to “Azure Active Directory” -> “App registrations” and click "New application registration".
