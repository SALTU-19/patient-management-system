<script>
import IconCheck from "../icons/IconCheck.vue";

export default {
    name: "TheCheckbox",
    components: { IconCheck },
    props: {
        text: {
            type: String,
        },
        modelValue: {
            type: String,
        },
        checked: {
            type: Boolean,
        },
        checkColor: {
            type: String,
        },
    },
    emits: ["update:modelValue"],
    computed: {
        hasCheckColor() {
            return this.checkColor ? this.checkColor : "#008b7f";
        },
    },
};
</script>

<template>
    <label class="checkbox">
        <input type="checkbox" :value="text" :checked="checked" @input="$emit('update:modelValue', $event.target.value)" />
        <span class="checkbox-icon">
            <IconCheck width="10" height="8" />
        </span>
        <span v-if="text" class="checkbox-text"> {{ text }} </span>
    </label>
</template>

<style lang="scss" scoped>
.checkbox {
    @apply flex items-center gap-2.5 cursor-pointer;

    input {
        @apply hidden;

        &:checked+.checkbox-icon {
            @apply text-white border-transparent;
            background-color: v-bind(hasCheckColor);
        }
    }

    &-icon {
        @apply flex justify-center items-center w-5 h-5 text-transparent border border-light-500 rounded overflow-hidden transition-all;
    }

    &-text {
        @apply text-xs;
    }
}
</style>