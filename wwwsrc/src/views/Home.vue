<template>
  <div class="home">
    <div id="carousel" class="carousel slide carousel-fade" data-ride="carousel" data-interval="3000" data-pause="false">
      <div class="card bg-primary">

      <div class="card welcome-card bg-info align-items-center py-3 m-2 shadow">
        <h2>Welcome To</h2>
        <h1>MovieParty</h1>
        <br>
        <p>Please Log In To Continue</p>
      </div>
      </div>
      <div class="carousel-inner">
        <div class="carousel-item active">
          <img src="../assets/7balltheater.jpg" class="d-block w-100" alt="">
        </div>
        <div class="carousel-item">
          <img src="../assets/centralcinema.jpg" class="d-block w-100" alt="">
        </div>
        <div class="carousel-item">
          <img src="../assets/insidetheater.jpg" class="d-block w-100" alt="">
        </div>
      </div>
    </div>
    
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>

<style>
#carousel{
  position: relative;
}
#carousel > .card{
  position: abosulte;
  bottom: -150px;
  left: 150px;
  width: 20%;
  z-index: 1500;
}
#carousel > .carousel-inner{
  position: absolute;
  top: 0px;
}
</style>