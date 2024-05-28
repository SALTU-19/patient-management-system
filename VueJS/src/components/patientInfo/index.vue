<script>
import GeneralCard from "@/components/patientInfo/generalCard/index.vue";

export default {
	name: "PatientInfo",
	components: {
		GeneralCard,
	},
	props: {
		demographicContents: {
			type: Object,
			required: true,
		},
		antropometricContents: {
			type: Object,
			required: true,
		},
		image: {
			type: String,
			required: true,
		},
	},
	data() {
		return {
			demographicTitle: "Demographic Information",
			antropometricTitle: "Antropometric Information",

		};
	},
	computed: {},
	methods: {},
	mounted() { },
};
</script>

<template>
	<div class="flex flex-row items-center justify-evenly mx-4 gap-6">
		<div>
			<div v-if="image" class="w-32 h-32 rounded-full overflow-hidden mb-5">
				<!-- <img src="@/components/assets/ProfilePicture.png" alt="Profile Picture" /> -->
				<img :src="image" alt="Profile Picture" />
			</div>
			<div v-if="!image" class="w-32 h-32 rounded-full overflow-hidden mb-5">
				<img src="@/components/assets/blank-profile.png" alt="Profile Picture" />
				<!-- <img :src="image" alt="Profile Picture" /> -->
			</div>
		</div>
		<div>
			<GeneralCard :title="demographicTitle" :contents="demographicContents" />
		</div>
		<div>
			<GeneralCard :title="antropometricTitle" :contents="antropometricContents" />
		</div>
	</div>
</template>
