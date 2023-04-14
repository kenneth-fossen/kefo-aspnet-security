import { createApp } from 'vue'
import App from './App.vue'
import AuthService from './Authservice';
import AuthInterceptor from './interceptor';
import './assets/main.css'
import axios from 'axios';


axios.interceptors.request.use(AuthInterceptor.request);
window.authService = new AuthService(axios);
window.authService.signIn();



createApp(App).mount('#app')
