import { mergeAlias } from 'vite';
<script>
import {
	DxDataGrid,
	DxColumn,
	DxPaging,
	DxPager,
} from "devextreme-vue/data-grid";
import ContentPanel from "@/components/layout/ContentPanel.vue";
import SearchBar from "@/components/forms/SearchBar.vue";
import { mapActions } from "vuex";
import { AtomSpinner } from "epic-spinners";
export default {
	name: "schedule",
	components: {
		DxDataGrid,
		DxColumn,
		DxPaging,
		DxPager,
		ContentPanel,
		SearchBar,
		AtomSpinner,
	},
	props: {},
	data() {
		return {
			searchTerm: "",
			surgeryHistoryList: [],
			schedules: [
				{
					id: 1,
					patientName: "Ali",
					surgeryName: "Surgery 1",
					surgeryDate: "01.01.2021",
					status: "Active",
					doctor: "Doctor 1",
				},
				{
					id: 2,
					patientName: "David",
					surgeryName: "Surgery 2",
					surgeryDate: "01.01.2021",
					status: "Active",
					doctor: "Doctor 2",
				},
				{
					id: 3,
					patientName: "Cristiano",
					surgeryName: "Surgery 3",
					surgeryDate: "01.01.2021",
					status: "Active",
					doctor: "Doctor 3",
				},
				{
					id: 4,
					patientName: "Lionel",
					surgeryName: "Surgery 4",
					surgeryDate: "01.01.2021",
					status: "Active",
					doctor: "Doctor 4",
				},
			],
			filteredSchedules: [],
			isLoading: true,
		};
	},
	computed: {
		filteredItems() {
			return this.schedules.filter(
				(item) =>
					item.patientName
						.toLowerCase()
						.includes(this.searchTerm.toLowerCase()) ||
					item.surgeryName
						.toLowerCase()
						.includes(this.searchTerm.toLowerCase()) ||
					item.surgeryDate
						.toLowerCase()
						.includes(this.searchTerm.toLowerCase()) ||
					item.status.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
					item.doctor.toLowerCase().includes(this.searchTerm.toLowerCase())
			);
		},
	},
	methods: {
		...mapActions(["getAllPreOps", "getUser", "getPatient"]),
		convertDateFormat(inputDateString) {
			// Create a new Date object using the input surgeryDate string
			var surgeryDateObject = new Date(inputDateString);

			// Get the individual components of the surgeryDate
			var day = surgeryDateObject.getUTCDate();
			var month = surgeryDateObject.getUTCMonth() + 1; // Months are zero-based, so we add 1
			var year = surgeryDateObject.getUTCFullYear();

			// Format the surgeryDate components in "DD.MM.YYYY" format
			var formattedDate = `${day}.${month}.${year}`;

			return formattedDate;
		},
		calculateStatus(surgeryDate) {
			var surgeryDateObject = new Date(surgeryDate);
			var today = new Date();
			if (surgeryDateObject > today) {
				return "Active";
			} else {
				return "Completed";
			}
		},
		async _getAllPreOps() {
			let doctor;
			let patient;
			let schedule;
			let _schedules = [];
			this.isLoading = true;
			this.surgeryHistoryList = await this.getAllPreOps();


			for (let i = 0; i < this.surgeryHistoryList.length; i++) {
				doctor = await this.getUser({
					uid: this.surgeryHistoryList[i].doctorId,
				});
				patient = await this.getPatient({
					uid: this.surgeryHistoryList[i].patientUId,
				});
				// this.surgeryHistoryList[i].doctorName = doctor.name + " " + doctor.surname;
				// this.surgeryHistoryList[i].patientName = patient.name + " " + patient.surname;
				schedule = {
					id: this.surgeryHistoryList[i].id,
					patientName: patient.name + " " + patient.surname,
					surgeryName: this.surgeryHistoryList[i].surgeryType,
					surgeryDate: this.convertDateFormat(
						this.surgeryHistoryList[i].surgeryDate
					),
					status: this.calculateStatus(this.surgeryHistoryList[i].surgeryDate),
					doctor: doctor.name + " " + doctor.surname,
				};
				_schedules.push(schedule);
			}
			this.schedules = _schedules;
			this.isLoading = false;
		},
	},
	async mounted() {
		await this._getAllPreOps();
	},
};
</script>
<template>
	<ContentPanel>
		<template #header>
			<div class="w-[1090px] flex flex-row items-center justify-between">
				<SearchBar :items="schedules" placeholder="Search Schedule" @update:search-term="searchTerm = $event"
					class="w-full" />
			</div>
		</template>
		<template #content>
			<div v-if="isLoading" class="flex justify-center items-center h-[500px]">
				<AtomSpinner :color="'#BEEBE5'" :animation-duration="1000" />
			</div>
			<div v-if="!isLoading" class="table-responsive">
				<DxDataGrid :data-source="filteredItems" class="clickable-row" :selection="{ mode: 'single' }">
					<DxColumn data-field="patientName"></DxColumn>
					<DxColumn data-field="surgeryName"></DxColumn>
					<DxColumn data-field="surgeryDate"></DxColumn>
					<DxColumn data-field="status"></DxColumn>
					<DxColumn data-field="doctor"></DxColumn>
				</DxDataGrid>
			</div>
		</template>
	</ContentPanel>
</template>
<style lang="scss" scoped></style>
