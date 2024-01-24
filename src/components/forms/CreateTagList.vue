<script>
import IconClose from "../icons/IconClose.vue";
import Input from "./Input.vue";
import Select from "./Select.vue";
export default {
    components: { IconClose, Input, Select },
    name: "CreateTagList",
    data() {
        return {
            tagValue: "",
            tagList: this.defaultValue,
        };
    },
    props: {
        modelValue: Array,
        resetTaglist: Number,
        options: Array,
        placeholder: String,
        scrollHeight: String,
        defaultValue: {
            type: Array,
            default: () => [],
        },
        disabled: [String, Array, Object],
    },
    emits: ["update:modelValue"],
    methods: {
        addTag() {
            if (this.tagValue) {
                this.tagList.push({ id: new Date(), name: this.tagValue });
                this.tagValue = "";
                this.setModelValue;
            }
        },
        deleteTag(id) {
            this.tagList = this.tagList.filter((tag) => tag.id !== id);
            this.setModelValue;
        },
    },
    computed: {
        setModelValue() {
            return this.$emit("update:modelValue", this.tagList);
        },
    },
    updated() {
        this.setModelValue;
    },
    watch: {
        'resetTaglist'() {
            this.tagList = [];
        }
    },
};
</script>

<template>
    <div class="tag" :class="disabled && 'disabled'">
        <Input v-if="!options" v-model="tagValue" :placeholder="placeholder" @keypress.enter="addTag" outline />
        <Select v-else v-model="tagList" :options="options" :checked="tagList" :placeholder="placeholder" outline multiple
            search />
        <ul class="tag-list" v-if="tagList.length > 0" :style="{ maxHeight: scrollHeight }"
            :class="scrollHeight && 'has-scroll mt-2'">
            <li v-for="tag in tagList" :key="tag.id" class="tag-list-item">
                {{ tag.name }}
                <button type="button" class="tag-list-delete-btn" @click="deleteTag(tag.id)">
                    <IconClose width="4" height="4" />
                </button>
            </li>
        </ul>
    </div>
</template>

<style lang="scss" scoped>
.tag {
    &-list {
        @apply flex flex-wrap gap-2 py-2.5;

        &-item {
            @apply relative text-white text-xs rounded-lg bg-light-500 py-2 px-3;

            &:hover {
                .tag-list-delete-btn {
                    @apply scale-100 opacity-100;
                }
            }
        }

        &-delete-btn {
            @apply absolute -top-0.5 -right-0.5 flex justify-center items-center w-3 h-3 rounded-full bg-primary-700 scale-0 opacity-0 transition-all;
        }
    }

    &.disabled {
        @apply rounded-lg bg-light-100 pointer-events-none;
    }
}
</style>