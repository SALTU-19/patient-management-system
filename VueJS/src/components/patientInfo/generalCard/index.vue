<script>
export default {
	name: "GeneralCard",

	props: {
		title: {
			type: String,
			required: true,
		},
		contents: {
			type: Object,
			required: true,
		},
	},
	data() {
		return {};
	},
	computed: {},
	methods: {},
	mounted() {},
};
</script>
<template>
	<div class="flex flex-col items-center justify-center">
		<div class="flex flex-col items-center justify-center mb-3">
			<div class="text-2xl">{{ title }}</div>
		</div>
		<div
			class="flex flex-col items-center justify-center bg-primary rounded-2xl px-4 py-2"
		>
			<div class="custom-card">
				<div class="flex flex-col items-start justify-center">
					<div
						v-for="(value, key) in contents"
						:key="key"
						class="flex flex-row"
					>
						<div class="text-l font-semibold">{{ key }}:</div>
						<div class="text-l ml-4">{{ value }}</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>
<style>
.custom-card {
	width: 400px;
	min-height: 220px;

	/* Replace with your desired background color */
	border-radius: 1rem;
	/* Adjust as needed */
	padding: 1rem;
	/* Adjust as needed */
	display: flex;
	flex-direction: column;
}
</style>
