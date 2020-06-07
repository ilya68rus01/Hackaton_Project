// JS
import "./js/";
import { store } from "./store";
import axios from "axios";
import VueAxios from "vue-axios";
import VueRouter from "vue-router";
//import carousel from "vue-owl-carousel";
// SCSS
import "./assets/scss/main.scss";

// CSS (example)
window.Vue = require("vue");
Vue.use(VueRouter);
Vue.use(VueAxios, axios);
import mainp from "./components/mainp.vue";
import maint from "./components/maint.vue";
// Vue components (for use in html)

/*Vue.component(
  "center-content-game",
  require("./components/center/center-content-game.vue").default
);*/
// Vue init
const routes = [
  { path: "/", component: mainp },
  { path: "/finish", component: maint }
];
const router = new VueRouter({
  routes
});
const app = new Vue({
  el: "#app",
  router,
  store
});
