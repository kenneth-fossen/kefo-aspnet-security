const AuthInterceptor = {
    request: function(request) {
        return window.authService.acquireToken()
            .then(token => {
                if (token) {
                    request.headers['Authorization'] = `Bearer ${token}`;
                }
                return request;
            });
    }
};

export default AuthInterceptor;