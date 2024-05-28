<script>
import {
	DxDataGrid,
	DxColumn,
	DxPaging,
	DxPager,
} from "devextreme-vue/data-grid";
import ContentPanel from "@/components/layout/ContentPanel.vue";
import SearchBar from "@/components/forms/SearchBar.vue";
import AddPatientModal from "@/views/patients/addModal/index.vue";
import { mapActions } from "vuex";
import { AtomSpinner } from "epic-spinners";
export default {
	name: "patient",
	components: {
		DxDataGrid,
		DxColumn,
		DxPaging,
		DxPager,
		ContentPanel,
		SearchBar,
		AddPatientModal,
		AtomSpinner,

	},
	props: {},
	data() {
		return {
			searchTerm: "",
			showAddPatientModal: false,
			patients: [
				{
					id: 1,
					name: "Ali",
					surname: "Veli",
					mail: "aliveli@mail.com",
					phone: "05555555555",
				},
				{
					id: 2,
					name: "David",
					surname: "Beckham",
					mail: "davidbeckham@mail.com",
					phone: "05555555555",
				},
				{
					id: 3,
					name: "Cristiano",
					surname: "Ronaldo",
					mail: "cristianoronaldo@mail.com",
					phone: "05555555555",
				},
				{
					id: 4,
					name: "Lionel",
					surname: "Messi",
					mail: "leomessi@mail.com",
					phone: "05555555555",
				},
			],
			filteredPatients: [],
			isSaving: false,
			isLoading: true,
		};
	},
	computed: {
		filteredItems() {
			return this.patients.filter(
				(item) =>
					item.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
					item.surname.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
					item.mail.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
					item.phone.toLowerCase().includes(this.searchTerm.toLowerCase())
			);
		},
	},
	methods: {
		goPatientDetail({ selectedRowsData }) {
			const data = selectedRowsData[0];
			this.$router.push(`patients/${data.uId}`);
		},
		...mapActions(["getAllPatients"]),

		async _getAllPatients() {
			this.isLoading = true;
			try {
				this.patients = await this.getAllPatients();
				this.isLoading = false;
			} catch (error) {
				console.log(error);
			}
		},
	},

	watch: {
		async isSaving(val) {
			if (this.isSaving) {
				await this._getAllPatients();
			}
			// await this._getAllUsers();
		},
	},
	async mounted() {
		await this._getAllPatients();
	},
};
</script>
<template>
	<ContentPanel>
		<template #header>
			<div class="w-[1090px] flex flex-row items-center justify-between">
				<SearchBar :items="patients" placeholder="Search Patient" @update:search-term="searchTerm = $event"
					class="w-full" />
				<div class="w-[150px]">
					<button class="bg-primary text-black rounded-2xl px-4 py-2 " @click="showAddPatientModal = true">+ Add
						Patient</button>
				</div>
			</div>
		</template>
		<template #content>
			<div v-if="isLoading" class="flex justify-center items-center h-[500px]">
				<AtomSpinner :color="'#BEEBE5'" :animation-duration="1000" />
			</div>
			<div v-if="!isLoading" class="table-responsive">
				<DxDataGrid :data-source="filteredItems" class="clickable-row" :selection="{ mode: 'single' }"
					@selection-changed="goPatientDetail">
					<DxColumn data-field="name" alignment="center"></DxColumn>
					<DxColumn data-field="surname" alignment="center"></DxColumn>
					<DxColumn data-field="mail" alignment="center"></DxColumn>
					<DxColumn data-field="phone" alignment="center"></DxColumn>
				</DxDataGrid>
			</div>

		</template>
	</ContentPanel>
	<AddPatientModal :showAddPatientModal="showAddPatientModal" @close-modal="showAddPatientModal = false"
		@save="isSaving = $event" />
</template>
<style lang="scss" scoped></style>
