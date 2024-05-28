<script>
import menuList from "@/data/menu";
// import { mapGetters } from "vuex";

export default {
	name: "TheNav",
	data() {
		return {
			menuList,
			selectedMenuItem: 1,
		};
	},
	// computed: {
	// 	...mapGetters(["userMe", "currentUserRole"]),
	// },
	methods: {
		handleMenuItemClick(menu) {
			this.selectedMenuItem = menu.id;
			// Additional logic or actions can be added here if needed
		},
		dividedPath(path) {
			return "/" + path.split("/")[1];
		},
	},
	mounted() {
		// check if the current route is in the menu list
		const currentRoute = this.dividedPath(this.$route.path);
		// const currentRoute = this.$route.path;

		const currentRouteIndex = this.menuList.findIndex((menu) => menu.path === currentRoute);
		this.selectedMenuItem = currentRouteIndex + 1;
	},
};
</script>

<template>
	<nav class="menu">
		<!-- <router-link v-for="menu in menuList" :key="menu.id" :to="menu.path" class="menu-item" active-class="active"
            @click="this.$store.dispatch('isOpenMobileMenu')">
            <component :is="menu.icon">
            </component>
        </router-link> -->


		<router-link v-for="menu in menuList" :key="menu.id" :to="menu.path" @click="handleMenuItemClick(menu)">
			<div :class="{ 'rounded-full bg-white': selectedMenuItem === menu.id }"
				class="flex flex-row items-center justify-start px-3" active-class="selected-menu-item">
				<component :is="menu.icon" class="menu-icon" active-class="active">
				</component>
				<span class="menu-text">{{ menu.text }}</span>
			</div>
		</router-link>
	</nav>
</template>

<style lang="scss" scoped>
.menu {
	@apply px-5;

	&-icon {
		@apply border-light h-14 w-14 mt-6 ml-2;
	}

	&-text {
		@apply text-black font-bold -ml-3 pr-3;
	}
}
</style>
