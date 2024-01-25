<script>
import IconAngleDown from "../icons/IconAngleDown.vue";
import IconCheck from "../icons/IconCheck.vue";
import Checkbox from "./CheckBox.vue";

export default {
    name: "TheSelect",

    components: { IconAngleDown, IconCheck, Checkbox },
    props: {
        placeholder: {
            type: String,
            required: true,
        },
        modelValue: {
            type: [Array, String],
        },
        options: {
            type: [Array, String],
            required: false,
            default: [],
        },
        name: {
            type: String,
        },
        outline: {
            type: Boolean,
        },
        multiple: {
            type: Boolean,
        },
        error: {
            type: Boolean,
        },
        optionHoverColor: {
            type: String,
        },
        nameField: {
            type: String,
            required: false,
            default: "name",
        },
        defaultSelected: {
            type: String,
            default: null,
        },
        checked: Array,
        search: Boolean,
    },
    data() {
        return {
            selectedOption: this.defaultSelected,
            isOpenSelect: false,
            selectedFilters: [],
            searchVal: "",
        };
    },
    emits: ["update:modelValue", "cmbxChange"],
    methods: {
        handleSelect() {
            this.isOpenSelect = !this.isOpenSelect;
        },
        closeSelect() {
            this.isOpenSelect = false;
        },
        filteredData() {
            if (this.searchVal.length > 0 && this.search) {
                return this.options.filter((item) =>
                    item[this.nameField]
                        .toLowerCase()
                        .includes(this.searchVal.toLowerCase())
                );
            }
            return this.options;
        },
        selectOption(option) {
            this.selectedOption = option;
            this[this.nameField]
                ? this.$emit("cmbxChange", this[this.nameField], this.selectedOption)
                : this.$emit("cmbxChange", this.selectedOption);
        },
        selectFilter(option) {
            const hasFilter = this.selectedFilters.some((item) => item === option);
            if (hasFilter) {
                this.selectedFilters = this.selectedFilters.filter(
                    (item) => item !== option
                );
                this.$emit("update:modelValue", this.selectedFilters);
            } else {
                this.selectedFilters.push(option);
                this.$emit("update:modelValue", this.selectedFilters);
            }
            this.$emit("filterAdded", this.selectedFilters);
        },
        setValue(e) {
            this.$emit("update:modelValue", e.target.value);
            this.handleSelect();
        },
    },
    updated() {
        if (this.multiple && this.checked) this.selectedFilters = this.checked;
    },
    computed: {
        checkOptionHoverColor() {
            return this.optionHoverColor ? this.optionHoverColor : "#ec6608";
        },
    },
};
</script>

<template>
    <div class="select" :class="[
        { active: isOpenSelect },
        { 'select-outline': outline, 'select-error': error },
    ]" @click="handleSelect" @mouseleave="closeSelect">
        <div class="select-header">
            <div class="line-clamp-1" :class="{ 'text-primary-700': selectedOption }">
                <template v-if="!multiple">
                    {{ selectedOption ? selectedOption : placeholder }}
                </template>
                <template v-else>
                    {{
                        selectedFilters.length === 1
                        ? selectedFilters[0][nameField]
                        : selectedFilters.length > 0 && selectedFilters.length !== 0
                            ? `${selectedFilters[0][nameField]} and ${selectedFilters.length - 1
                            } other`
                            : placeholder
                    }}
                </template>
            </div>
            <div class="select-icon">
                <IconAngleDown />
            </div>
        </div>
        <div class="select-content">
            <ul class="select-list" :class="{ 'select-list-scroll': options.length > 5 }">
                <li class="p-2" v-if="search">
                    <input v-model="searchVal" type="text" placeholder="Search Data" class="select-search"
                        @click="isOpenSelect = false" />
                </li>
                <li class="select-list-item" :class="[
                    multiple ? 'pl-2' : 'pl-6',
                    { selected: placeholder == selectedOption },
                ]" @click="selectOption(placeholder)" v-if="!multiple && placeholder">
                    <div class="select-list-icon" v-if="placeholder == selectedOption">
                        <IconCheck />
                    </div>
                    {{ placeholder }}
                </li>
                <li class="select-list-item" :class="[
                    multiple ? 'pl-2' : 'pl-6',
                    filteredData()[index].disabled ? 'hidden' : '',
                    { selected: option[nameField] == selectedOption && !multiple },
                ]" v-for="(option, index) in filteredData()" :key="option.id" @click="selectOption(option[nameField])">
                    <template v-if="!multiple">
                        <label class="select-label">
                            <input type="text" :value="option[nameField]" @click="setValue($event)" class="hidden" />
                            <div class="select-list-icon" v-if="option[nameField] == selectedOption">
                                <IconCheck />
                            </div>
                            {{ !option.disabled ? option[nameField] : "Taken" }}
                        </label>
                    </template>
                    <Checkbox :text="option[nameField]" :value="option[nameField]" checkColor="#ec6608"
                        @change="selectFilter(option)" v-if="multiple" />
                </li>
            </ul>
        </div>
    </div>
</template>

<style lang="scss" scoped>
.select {
    @apply relative w-full cursor-pointer select-none;

    &-header {
        @apply flex justify-between items-center gap-1 text-xs rounded-lg py-3 px-3.5;
    }

    &:not(.select-outline) {
        .select-header {
            @apply bg-light;
        }
    }

    &-icon {
        @apply flex justify-center items-center text-light-500 w-3 h-3 transition-all;
    }

    &-content {
        @apply absolute left-0 top-full translate-y-4 w-full rounded-lg bg-dark p-1 z-10 opacity-0 invisible transition-all;

        &::after {
            @apply absolute left-0 bottom-full w-full h-4;
            content: "";
        }
    }

    &-list {
        @apply flex flex-col gap-y-px;

        &-item {
            @apply relative text-white text-sm rounded py-1 pr-2 transition-all;

            &:hover,
            &.selected {
                background-color: v-bind(checkOptionHoverColor);
            }
        }

        &-icon {
            @apply flex justify-center items-center absolute top-1/2 left-2 -translate-y-1/2;
        }
    }

    &-label {
        @apply cursor-pointer;

        &::after {
            @apply absolute top-0 left-0 w-full h-full;
            content: "";
        }
    }

    &-list-scroll {
        @apply max-h-[150px] overflow-auto pr-1;

        &::-webkit-scrollbar {
            @apply w-1 rounded-full bg-gray;
        }

        &::-webkit-scrollbar-thumb {
            @apply rounded-full bg-light-500;
        }
    }

    &.active {
        .select-icon {
            @apply rotate-180;
        }

        .select-content {
            @apply translate-y-2.5 opacity-100 visible;
        }
    }

    &-outline {
        .select-header {
            @apply text-light-500 py-2.5 px-3 border border-light-500;
        }
    }

    &-error {
        .select-header {
            @apply border border-rose-500 transition-all;
        }
    }

    &-search {
        @apply w-full text-xs text-gray-300 border-b border-gray-300 p-1;

        &::placeholder {
            @apply text-gray-300;
        }
    }
}
</style>