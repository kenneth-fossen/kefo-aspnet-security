import { PublicClientApplication, LogLevel, EventType } from '@azure/msal-browser';

const loginRequest = {
    scopes: [
        '1851a809-314c-4d44-9844-382ce9f64f85/.default'
    ]
};

const accessRequest = {
    scopes: ['api://1851a809-314c-4d44-9844-382ce9f64f85/SecretFlag']
};

class AuthService {

    constructor($http) {
        this.permissionsRequest = [];
        this.accessGroupRequest = [];
        this.$http = $http;

        this.pca = new PublicClientApplication({
            auth: {
                clientId: '1851a809-314c-4d44-9844-382ce9f64f85',
                authority: 'https://login.microsoftonline.com/e5d441e9-b0fb-4458-a4d7-15d2b4cfc193',
                redirectUri: 'http://localhost:5173/',
            },
            cache: {
                cacheLocation: 'sessionStorage'
            },
            system: {
                loggerOptions: {
                    loggerCallback(loglevel, message) {
                        console.log(message);
                    },
                    logLevel: LogLevel.Error
                }
            }
        });
    }
    redirectHandled = () => this.pca.handleRedirectPromise();

    isSignedIn() {
        return !!this.getUser();
    }

    signIn() {
        const accounts = this.pca.getAllAccounts();
        if (accounts.length > 0) this.pca.setActiveAccount(accounts[0]);

        this.pca.handleRedirectPromise().then((response) => {
            if (response !== null) { return; }

            if (!accounts || accounts.length === 0) { this.pca.loginRedirect(loginRequest); }
            else { this.pca.acquireTokenSilent(loginRequest); }
        });

        this.pca.addEventCallback((event) => {
            if (event.eventType === EventType.LOGIN_SUCCESS && event.payload) {
                const payload = event.payload;
                const account = payload.account;
                this.pca.setActiveAccount(account);
            }
        });
    }

    signOut() {
        this.pca.logoutRedirect().then(() => {
            sessionStorage.clear();
            window.location.reload();
        });
    }


    getUser() {
        return this.pca.getActiveAccount();
    }

    acquireToken() {
        return this.pca.handleRedirectPromise().then( () =>
            this.pca.acquireTokenSilent(accessRequest)
                .then(token => token.accessToken)
        );
    }
}

export default AuthService;