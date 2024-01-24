<script>
import IconSearch from "../icons/IconSearch.vue";
import IconAngleDown from "../icons/IconAngleDown.vue";

export default {
    name: "TheInput",
    props: {
        type: {
            type: String,
            default: "text",
        },
        inputText: {
            type: String,
        },
        placeholder: {
            type: String,
        },
        outline: {
            type: Boolean,
        },
        search: {
            type: Boolean,
        },
        required: {
            type: Boolean,
        },
        verify: {
            type: Boolean,
        },
        error: {
            type: Boolean,
        },
        modelValue: [String, Number],
    },
    methods: {
        keyDownValue(event) {
            // this.currentVal = event.target.value
            this.name
                ? this.$emit("inputChange", this.name, event.target.value)
                : this.$emit("inputChange", event.target.value);
        },

        handleNumInput(status) {
            if (status === "increase") {
                this.$refs.inputNumber.value++;
            } else {
                this.$refs.inputNumber.value--;
            }
            this.$emit("update:modelValue", this.$refs.inputNumber.value);
        },
    },
    emits: ["update:modelValue", "inputChange"],
    components: { IconSearch, IconAngleDown },
};
</script>

<template>
    <div :class="[
        outline ? 'input-outline' : 'input',
        { 'input-error': error },
        { required: required },
        { 'input-password': verify },
        { 'input-search': search },
    ]">
        <input @keyup="keyDownValue" :value="modelValue" :type="type" :placeholder="placeholder"
            @focusout="$emit('focusOut', $event.target.value)" :class="[
                type === 'number' && 'input-number',
                type === 'color' && 'input-color',
            ]" @input="$emit('update:modelValue', $event.target.value)" ref="inputNumber" />
        <div class="input-number-icons" v-if="type === 'number'">
            <button type="button" @click="handleNumInput('increase')">
                <IconAngleDown class="rotate-180" />
            </button>
            <button type="button" @click="handleNumInput('decrease')">
                <IconAngleDown />
            </button>
        </div>
        <IconSearch width="16" height="16" class="input-icon" v-if="search" />
        <span class="input-text" v-if="inputText"> {{ inputText }} </span>
    </div>
</template>

<style lang="scss" scoped>
.input {
    @apply relative flex items-center gap-2.5 w-full text-xs rounded-lg pr-3.5 overflow-hidden;

    input {
        @apply flex-1 bg-light py-3 pl-3.5;

        &::placeholder {
            @apply text-light-500;
        }
    }

    &-text {
        @apply text-light-500;
    }

    &-outline {
        @apply relative text-primary text-xs border border-light-500 rounded-lg overflow-hidden;

        input {
            @apply w-full h-full py-2.5 px-3;

            &::placeholder {
                @apply text-light-500;
            }
        }

        &:not(.input-password) {
            input {
                @apply text-primary-700;
            }
        }

        &.required {
            @apply border-danger;

            input {
                @apply text-danger;
            }
        }
    }

    &-password {
        @apply flex items-center h-[36px] overflow-hidden;

        input {
            @apply text-primary text-[42px] tracking-[10px] text-center -mt-1.5;
        }
    }

    &-search {
        @apply relative;

        input {
            @apply pl-10;
        }
    }

    &-icon {
        @apply absolute top-2/4 -translate-y-2/4 left-3 text-light-500;
    }

    &-color {
        @apply p-0 #{!important};

        &::-webkit-color-swatch {
            @apply border-none rounded-md;
        }
    }

    &-error {
        @apply border border-rose-500 text-primary transition-all;
    }

    &-number {
        @apply pr-7 #{!important};

        &::-webkit-inner-spin-button {
            @apply hidden;
        }

        &-icons {
            @apply absolute top-2/4 right-2 -translate-y-2/4 flex flex-col gap-1.5 text-light-500;
        }
    }
}
</style>