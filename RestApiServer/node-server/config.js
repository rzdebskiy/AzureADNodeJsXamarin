 // Don't commit this file to your public repos. This config is for first-run
 exports.creds = {
     mongoose_auth_local: 'mongodb://localhost/tasklist', // Your mongo auth uri goes here
     identityMetadata: 'https://login.microsoftonline.com/48dbe29b-87ee-4ffb-a678-111bc2c32099/.well-known/openid-configuration', // This is customized for your tenant.
     // You may use the common endpoint for multi-tenant scenarios
     // if you do, make sure you set validateIssuer to false and specify an audience
     // as you won't get this from the Identity Metadata
     //
     //identityMetadata: 'https://login.microsoftonline.com/common/.well-known/openid-configuration',
     validateIssuer: false, // if you have validation on, you cannot have users from multiple tenants sign in
 	 passReqToCallback: false,
     loggingLevel: 'info', // valid are 'info', 'warn', 'error'. Error always goes to stderr in Unix.
     clientID: '4ecc99d5-06d4-4b94-bf4f-5a6c55902791',
     audience: 'https://graph.windows.net'
 };
