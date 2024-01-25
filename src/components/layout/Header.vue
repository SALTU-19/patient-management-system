<script>



export default {
    name: "LayoutHeader",
    data() {
        return {
            options: [
                {
                    id: 1,
                    name: "Option 1",
                },
                {
                    id: 2,
                    name: "Option 2",
                },
                {
                    id: 3,
                    name: "Option 3",
                },
            ],
            optionsBreed: [
                {
                    id: 1,
                    name: "%80",
                },
                {
                    id: 2,
                    name: "%60",
                },
                {
                    id: 3,
                    name: "%40",
                },
            ],
            selectFarm: {
                select: null,
            },
            showNotification: false,
        };
    },
    components: {



    },
    computed: {
        // ...mapGetters(["isOpenMobileMenu"]),
    },
    methods: {
        showNotificationWindow() {
            this.showNotification = !this.showNotification;
        },
        handleForm() {
            this.showVerifyField = true;
        },
    },
};
</script>

<template>
    <div>
        <header class="flex justify-between items-end bg-primary  py-3 px-7">


            <div class="flex justify-center ml-20">
                <span class="font-bold text-black">Hastane</span>
            </div>


            <button class="bg-white text-black rounded-2xl px-4 py-2" @click="this.$router.push('/sign-in')">
                Logout
            </button>

        </header>


    </div>
</template>

<style lang="scss" scoped></style>