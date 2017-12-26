 // Don't commit this file to your public repos. This config is for first-run
exports.creds = {
    mongoose_auth_local: 'mongodb://localhost/tasklist', // Your mongo auth uri goes here
    identityMetadata: 'https://login.microsoftonline.com/<<Insert_your_tenant_ID_here>>/.well-known/openid-configuration', // This is customized for your tenant.
    // You may use the common endpoint for multi-tenant scenarios
    // if you do, make sure you set validateIssuer to false and specify an audience
    // as you won't get this from the Identity Metadata
    //
    //identityMetadata: 'https://login.microsoftonline.com/common/.well-known/openid-configuration',
    validateIssuer: false, // if you have validation on, you cannot have users from multiple tenants sign in
    passReqToCallback: false,
    loggingLevel: 'info', // valid are 'info', 'warn', 'error'. Error always goes to stderr in Unix.
    clientID: '<<Insert client ID of your REST API Server here>>',
    audience: 'https://graph.windows.net'
};
