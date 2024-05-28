<script>
export default {
    name: "LayoutAuth",
};
</script>

<template>
    <div class="auth-wrapper ">
        <div class="auth-content w-1/2 ">
            <router-view />
        </div>
    </div>
</template>

<style lang="scss">
.auth {
    &-wrapper {
        @apply flex justify-end h-screen overflow-hidden;
    }

    &-content {
        @apply w-1/2 flex justify-center items-center p-4;
    }
}

// .bg-custom-image {
//   background-image: url('@/assets/img/Sign.jpg');
//   background-size: cover;
// }
.bg-custom-text {
    background-color: rgba(0, 0, 0, 0.5);
}
</style>