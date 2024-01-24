<script>
export default {
    name: 'Card',
    components: {

    },
    props: {
        icon: {
            type: String,
            required: true,
            default: '@/components/assets/TimeProgress.svg',
        },
        title: {
            type: String,
            required: true,
        },
    },
    data() {
        return {

        }
    },
    computed: {

    },
    methods: {

    },
    mounted() {

    },
};
</script>
<template>
    <div class="flex flex-col items-center justify-center bg-gray-300 rounded-2xl px-4 py-6 cursor-pointer">
        <img src="@/components/assets/TimeProgress.png" />
        <div class="text-l mt-2 font-semibold">{{ title }}</div>
    </div>
</template>
<style lang="scss" scoped></style>