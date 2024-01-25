<script>
import Nav from "../blocks/Nav.vue";
import Profile from "../blocks/Profile.vue";
// import IconSettings from "../icons/IconSettings.vue";
// import Profile from "../blocks/Profile.vue";
// import ProfileImage from "@/assets/img/profile-ismail-bican.jpg";

export default {
	name: "LayoutSidebar",
	data() {
		return {
			// ProfileImage,
			name: null,
			jobName: null,
			image: null,
			user: null,
		};
	},
	components: {
		Nav,
		Profile,
		// IconSettings, Profile
	},
	async mounted() {
		// get user info from local storage
		this.user = JSON.parse(localStorage.getItem("user"));
		// set user info to data
		this.name = this.user.name + " " + this.user.surname;
		this.jobName = this.user.role;
		this.image = this.user.imgUrl;

	},

};
</script>

<template>
	<aside class="sidebar items-start justify-between">
		<Nav class="mt-5" />
		<Profile width="94px" height="94px" borderWidth="8px" :name="name ? name : 'No Name'"
			:title="jobName ? jobName : 'No Job'" :image="image ? image : ProfileImage" class="mb-32 ml-7" />
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
	@apply fixed left-0 lg:flex flex-col bg-primary overflow-hidden px-8 py-4 h-full;
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
