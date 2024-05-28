<script>

// import Auth from "@/components/layout/Auth.vue";
import Default from "@/components/layout/Default.vue";
import Auth from "@/components/layout/Auth.vue";


export default {
  name: "App",
  components: {
    Default,
    Auth,
  },
  data() {
    return {
      layout: null,
    };
  },
  watch: {
    $route(to) {
      this.layout = to.meta.layout !== undefined ? to.meta.layout : "Default";
    },
  },
};
</script>

<template>
  <component :is="layout"></component>
</template>