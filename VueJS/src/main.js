import { createApp } from 'vue'
import "./styles/main.scss";
import router from "./router";
import store from "./store";

import App from './App.vue'

// createApp(App).mount('#app')
const app = createApp(App);

app.use(store).use(router).mount('#app');
