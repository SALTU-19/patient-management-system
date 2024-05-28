<script>
export default {
	name: "ContentPanel",
	props: {},
};
</script>

<template>
	<div class="content-panel">
		<div class="content-panel-header" v-if="this.$slots.header">
			<slot name="header"></slot>
		</div>
		<div class="content-panel-content">
			<slot name="content"></slot>
		</div>
	</div>
</template>

<style lang="scss" scoped>
.content-panel {
	@apply w-full h-full rounded-xl lg:pl-[150px] lg:pr-[50px] py-5;

	&-header {
		@apply flex flex-wrap justify-between;
	}

	&-content {
		@apply flex flex-col justify-between mt-5;
	}
}
</style>
