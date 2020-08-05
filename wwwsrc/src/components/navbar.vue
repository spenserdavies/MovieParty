<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-primary">
    <router-link class="navbar-brand text-white" :to="{ name: 'home' }">
    <div class="row my-0 py-0">
      <div class="col-12 text-center mb-0 pb-0">
        <div class="logo-m my-0 py-0">M</div>
      </div>
    </div>
    <div class="row my-0 py-0">
      <div class="col-12 text-center my-0 py-0">
        <small>MovieParty</small>
      </div>
    </div>

    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li
          class="nav-item"
          v-if="$auth.isAuthenticated"
          :class="{ active: $route.name == 'dashboard' }"
        >
          <router-link class="nav-link" :to="{ name: 'dashboard' }"
            >My-Dashboard</router-link
          >
        </li>
      </ul>
      <span class="navbar-text"> <!-- NOTE @click="login" -->
        <button
          id="btn-login"
          class="btn btn-secondary"
          @click="login"
          v-if="!$auth.isAuthenticated"
        >
          Login
        </button>
        <button class="btn btn-danger" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      this.$store.dispatch("setBearer", this.$auth.bearer);
      console.log("this.$auth.user: ");
      console.log(this.$auth.user);
    },
    async logout() {
      this.$store.dispatch("resetBearer");
      await this.$auth.logout({ returnTo: window.location.origin });
    }
  }
};
</script>

<style>

/* font-family: 'Bilbo', cursive;             -- Adventure
font-family: 'Creepster', cursive;            -- Horror
font-family: 'Dancing Script', cursive;       -- Romance
font-family: 'IM Fell DW Pica SC', serif;     -- Fantasy
font-family: 'Lobster', cursive;              -- Logo
font-family: 'Nosifer', cursive;              -- Thriller/Mystery
font-family: 'Playfair Display', serif;       -- Drama
font-family: 'Rammetto One', cursive;         -- Animated
font-family: 'Ruslan Display', cursive;       -- Sci-fi
font-family: 'Russo One', sans-serif;         -- Action
font-family: 'Sarpanch', sans-serif;          -- Crime
font-family: 'Satisfy', cursive;              -- RomCom
font-family: 'Sigmar One', cursive;           -- Comedy         */

.logo-m{
  font-family: 'Lobster', cursive;
  font-size: 32px;
  margin-bottom: 0;
  padding-bottom: 0;
}
</style>
