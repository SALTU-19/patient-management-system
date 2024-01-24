<script>
// import Header from "./Header.vue";
import Sidebar from "./Sidebar.vue";
export default {
	name: "LayoutDefault",
	components: {
		// Header,
		Sidebar,
	},
};
</script>

<template>
	<Header />
	<div class="flex items-center gap-6 pl-6 lg:pl-[190px] pr-6">
		<Sidebar />
		<main class="flex-1 w-full h-screen"><router-view /></main>
	</div>
</template>
