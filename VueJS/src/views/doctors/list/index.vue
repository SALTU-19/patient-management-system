<script>
import {
	DxDataGrid,
	DxColumn,
	DxPaging,
	DxPager,
} from "devextreme-vue/data-grid";
import ContentPanel from "@/components/layout/ContentPanel.vue";
import SearchBar from "@/components/forms/SearchBar.vue";
import AddDoctorModal from "@/views/doctors/addModal/index.vue";
import { mapActions } from "vuex";
import { AtomSpinner } from "epic-spinners";
export default {
	name: "doctor",
	components: {
		DxDataGrid,
		DxColumn,
		DxPaging,
		DxPager,
		ContentPanel,
		SearchBar,
		AddDoctorModal,
		AtomSpinner,
	},
	props: {},
	data() {
		return {
			searchTerm: "",
			showAddDoctorModal: false,
			doctors: [
				{
					id: 1,
					name: "Ali",
					surname: "Veli",
					email: "aliveli@mail.com",
					mobile: "05555555555",
					hospital: "Hospital 1",
				},
				{
					id: 2,
					name: "David",
					surname: "Beckham",
					email: "davidbeckham@mail.com",
					mobile: "05555555555",
					hospital: "Hospital 2",
				},
				{
					id: 3,
					name: "Cristiano",
					surname: "Ronaldo",
					email: "cristianoronaldo@mail.com",
					mobile: "05555555555",
					hospital: "Hospital 3",
				},
				{
					id: 4,
					name: "Lionel",
					surname: "Messi",
					email: "leomessi@mail.com",
					mobile: "05555555555",
					hospital: "Hospital 4",
				},
			],
			isSaving: false,
			filteredDoctors: [],
			isLoading: true,
		};
	},
	computed: {
		filteredItems() {
			return this.doctors.filter(
				(item) =>
					item.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
					item.surname.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
					item.email.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
					item.mobile.toLowerCase().includes(this.searchTerm.toLowerCase())
			);
		},
	},

	watch: {
		async isSaving(val) {
			if (this.isSaving) {
				await this._getAllUsers();
			}
			// await this._getAllUsers();
		},
	},

	methods: {
		// goDoctorDetail({ selectedRowsData }) {
		//     const data = selectedRowsData[0];
		//     this.$router.push(`doctors/${data.id}`);
		// },
		...mapActions(["getAllUsers"]),

		async _getAllUsers() {
			this.isLoading = true;
			try {
				this.doctors = await this.getAllUsers();
				this.isLoading = false;
			} catch (error) {
				console.log(error);
			}
		},
	},
	async mounted() {
		await this._getAllUsers();
	},
};
</script>
<template>
	<ContentPanel>
		<template #header>
			<div class="w-[1090px] flex flex-row items-center justify-between">
				<SearchBar :items="doctors" placeholder="Search Doctor" @update:search-term="searchTerm = $event"
					class="w-full" />
				<div class="w-[150px]">
					<button class="bg-primary text-black rounded-2xl px-4 py-2" @click="showAddDoctorModal = true">
						+ Add Doctor
					</button>
				</div>
			</div>
		</template>
		<template #content>
			<div v-if="isLoading" class="flex justify-center items-center h-[500px]">
				<AtomSpinner :color="'#BEEBE5'" :animation-duration="1000" />
			</div>
			<div v-if="!isLoading" class="table-responsive">
				<DxDataGrid :data-source="filteredItems" class="clickable-row" :selection="{ mode: 'single' }">
					<DxColumn data-field="name" alignment="center"></DxColumn>
					<DxColumn data-field="surname" alignment="center"></DxColumn>
					<DxColumn data-field="email" alignment="center"></DxColumn>
					<DxColumn data-field="mobile" alignment="center"></DxColumn>
				</DxDataGrid>
			</div>
		</template>
	</ContentPanel>
	<AddDoctorModal :showAddDoctorModal="showAddDoctorModal" @close-modal="showAddDoctorModal = false"
		@is-saving="isSaving = $event" />
</template>
<style lang="scss" scoped></style>
