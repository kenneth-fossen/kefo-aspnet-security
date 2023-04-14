<script>
export default {
    data() {
      return {
        flag: '',
      }
    },
    components: {},
    
    methods: {
      flagString() {
        return this.flag;
      },
      async fetchData() {
        const token = await window.authService.acquireToken();
        console.log(token);
        const response = await fetch('https://localhost:5001/Flag',{
            method: 'GET',
            headers: { Authentication: 'Bearer ' + token }
           })
          .then(data => data.text());
        console.log(response);
        this.flag = response;
      }
    }
}
</script>

<template>
  <header>
    
  </header>

  <main>
    <div>
      <button @click="fetchData">fetchData</button>
    </div>
    <div>
      Secret will show here: {{ flagString() }}
    </div>
  </main>
</template>

<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>