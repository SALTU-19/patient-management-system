<script>
import IconArrowDropDown from '../icons/IconArrowDropDown.vue';
import IconArrowDropUp from '../icons/IconArrowDropUp.vue';
import IconEdit from '../icons/IconEdit.vue';
import IconTrash from '../icons/IconTrash.vue';
export default {
    name: 'DraggableCard',
    components: {
        IconArrowDropDown,
        IconArrowDropUp,
        IconEdit,
        IconTrash,
    },
    props: {
        title: {
            type: String,
            required: true,
        },
    },
    data() {
        return {
            isExpanded: false,
            edit: false,
            delete: false,
        }
    },
    computed: {

    },
    methods: {
        clickEdit() {
            // console.log("edit");
            this.edit = !this.edit;
            this.$emit('edit', this.edit);
        },
        clickDelete() {
            this.delete = !this.delete;
            this.$emit('delete', this.delete);
        },

    },
    mounted() {

    },
    emits: ['delete', 'edit', 'expand'],
};
</script>
<template>
    <div class="flex flex-col items-center justify-center bg-gray-300 rounded-2xl px-4 py-6 "
        @click="isExpanded = !isExpanded; $emit('expand', isExpanded)">
        <div class="flex flex-row items-center justify-between w-full">
            <div class="text-l mt-2 font-semibold">{{ title }}</div>
            <div class="flex flex-row items-center justify-center">
                <IconEdit class="w-4 h-4 mr-2 cursor-pointer" @click="clickEdit()" />
                <IconTrash class="w-5 h-5 cursor-pointer" @click="clickDelete()" />
                <IconArrowDropDown class="w-6 h-6 mr-2 cursor-pointer" v-if="!isExpanded" />
                <IconArrowDropUp class="w-6 h-6 mr-2 cursor-pointer" v-if="isExpanded" />
            </div>
        </div>
        <slot></slot>
    </div>
</template>
<style lang="scss" scoped></style>