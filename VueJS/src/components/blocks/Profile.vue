<script>
export default {
    name: "TheProfile",
    props: {
        width: {
            type: String,
        },
        height: {
            type: String,
        },
        borderWidth: {
            type: String,
        },
        name: {
            type: String,
        },
        title: {
            type: String,
        },
        image: {
            type: String,
        },
    },
};
</script>

<template>
    <div class="profile">
        <!-- <div class="profile-image">
            <img :src="image" :alt="name ? name : 'Profile image'" />
        </div> -->
        <div v-if="image" class="profile-image">
            <!-- <img src="@/components/assets/ProfilePicture.png" alt="Profile Picture" /> -->
            <img :src="image" alt="Profile Picture" />
        </div>
        <div v-if="!image" class="profile-image">
            <img src="@/components/assets/blank-profile.png" alt="Profile Picture" />
            <!-- <img :src="image" alt="Profile Picture" /> -->
        </div>
        <div class="flex flex-col text-center" v-if="name && title">
            <h4 class="text-sm">{{ name }}</h4>
            <small class="text-xs font-light"> {{ title }}</small>
        </div>
    </div>
</template>

<style lang="scss" scoped>
.profile {
    @apply flex flex-col justify-center items-center gap-3;

    &-image {
        @apply border-light rounded-full bg-light -rotate-45 overflow-hidden cursor-pointer;
        width: 130px;
        height: 130px;
        border-width: 8px;

        img {
            @apply w-full h-full object-cover rotate-45;
        }
    }
}
</style>
