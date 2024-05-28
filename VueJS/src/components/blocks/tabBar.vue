<script>
export default {
    name: "TabBar",
    data() {
        return {
            selectedMenuItem: 1,
        };
    },
    props: {
        menuList: {
            type: Array,
            default: () => [],
        },
    },
    methods: {
        handleMenuItemClick(menuId) {
            this.selectedMenuItem = menuId;
            this.$emit("selected-menu-item", menuId);
        },
    },
    mounted() {
        this.selectedMenuItem = 1;
    },
    emits: ["selected-menu-item"],
};
</script>

<template>
    <nav class="px-5 flex flex-row items-center justify-between gap-52 ">
        <div v-for="menu in menuList" :key="menu.id" @click="handleMenuItemClick(menu.id)">
            <div :class="{ 'rounded-full bg-[#FFE600] p-3 pr-1': selectedMenuItem === menu.id }"
                class="flex flex-row items-center  ">
                <span class="text-black font-bold mr-3 cursor-pointer">{{ menu.name }}</span>
            </div>
        </div>
    </nav>
</template>

<style lang="scss" scoped></style>