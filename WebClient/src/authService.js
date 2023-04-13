import { PublicClientApplication, LogLevel, EventType } from '@azure/msal-browser';

const loginRequest = {
    scopes: []
};

const accessRequest = {
    scopes: []
};

class AuthService {

    constructor($http) {
        this.$http = $http;

    }
    redirectHandled = () => this.pca.handleRedirectPromise();

    isSignedIn() {
        return !!this.getUser();
    }

    signIn() {
    
    }

    getUser() {
        return this.pca.getActiveAccount();
    }

    acquireToken() {
    }
}

export default AuthService;