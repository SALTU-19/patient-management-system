<script>
import Nav from "../blocks/Nav.vue";
// import IconSettings from "../icons/IconSettings.vue";
// import Profile from "../blocks/Profile.vue";
// import ProfileImage from "@/assets/img/profile-ismail-bican.jpg";

export default {
	name: "LayoutSidebar",
	data() {
		return {
			// ProfileImage,
		};
	},
	components: {
		Nav,
		// IconSettings, Profile
	},
};
</script>

<template>
	<aside class="sidebar">
		<Nav />
		<!-- <Profile
			width="94px"
			height="94px"
			borderWidth="8px"
			name="İsmail Bican"
			title="Manager"
			:image="ProfileImage"
			class="mt-8 mb-10"
		/> -->
		<!-- <router-link
			to="/settings/Privacy"
			class="flex justify-center text-light-500 py-10 mt-auto transition-all"
			active-class="active"
			@click="this.$store.dispatch('isOpenMobileMenu')"
		>
			<IconSettings />
		</router-link> -->
	</aside>
</template>

<style lang="scss" scoped>
.sidebar {
	@apply fixed left-0 lg:flex flex-col rounded-xl bg-primary overflow-hidden px-8 py-4 h-full;
	min-height: calc(80vh - 120px);

	@media (max-width: 1024px) {
		@apply fixed -translate-x-full w-full h-full max-h-full overflow-y-auto invisible z-40 duration-500;

		&.active {
			@apply translate-x-0 visible;
		}
	}
}

.active {
	@apply text-primary;
}
</style>
