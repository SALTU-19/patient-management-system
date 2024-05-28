<script>
import IconClose from "../icons/IconClose.vue";

export default {
    name: "TheModal",
    props: {
        title: {
            type: String,
        },
        showModal: {
            type: Boolean,
            required: true,
        },
        noPadding: {
            type: Boolean,
        },
        fixedHeight: Boolean,
        sm: Boolean,
        md: Boolean,
        xs: Boolean
    },
    components: { IconClose },
};
</script>

<template>
    <Transition name="modal">
        <div class="modal" :class="fixedHeight && 'fixed-height'" v-if="showModal">
            <div class="modal-overlay" @click="$emit('closeModal')"></div>
            <div class="modal-inner max-w-[1060px]"
                :class="{ 'max-w-[600px]': sm, 'max-w-[670px]': md, 'max-w-[445px]': xs, }">
                <div class="modal-header">
                    {{ title }}
                    <button type="button" @click="$emit('closeModal')">
                        <IconClose class="text-light-500" />
                    </button>
                </div>
                <div class="modal-content" :class="{ 'p-8': !noPadding }">
                    <slot name="content"></slot>
                </div>
                <div class="modal-footer" v-if="this.$slots.footer">
                    <slot name="footer"></slot>
                </div>
            </div>
        </div>
    </Transition>
</template>

<style lang="scss">
.modal {
    @apply absolute top-0 left-0 flex items-center justify-center w-full min-h-screen p-5 z-50 transition-all;

    &-overlay {
        @apply fixed top-0 left-0 w-full h-full bg-black/[85%] -z-10;
    }

    &-inner {
        @apply w-full rounded-xl bg-white transition-all;
    }

    &.fixed-height {
        .modal-content {
            @apply flex flex-col flex-1 h-full;
        }

        .modal-inner {
            @apply flex flex-col sm:min-h-[600px];
        }
    }

    &-header {
        @apply flex justify-between items-center gap-2 border-b border-light p-8;
    }

    &-footer {
        @apply flex flex-wrap justify-end items-center gap-2 px-8 mb-8;
    }

    &-section {
        @apply border-b border-light p-8;

        &:not(:last-child) {
            @apply border-r;
        }
    }

    &-enter-from,
    &-leave-to {
        @apply opacity-0;

        .modal-inner {
            @apply translate-y-4;
        }
    }
}
</style>