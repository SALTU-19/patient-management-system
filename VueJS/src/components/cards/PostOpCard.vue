<script>
import DraggableCard from './DraggableCard.vue';
export default {
    name: "PostOpCard",
    components: {
        DraggableCard,
    },
    props: {
        postOp: {
            type: Object,
            required: true,
        },
    },
    data() {
        return {
            isExpanded: false,
        };
    },
    methods: {

    },
    mounted() {

    },

};


</script>
<template>
    <DraggableCard :title="postOp.surgeryDate" @expand="isExpanded = $event">
        <div class="grid grid-row-2 gap-4 items-start justify-between w-full mt-3" v-if="isExpanded">
            <div class="flex flex-row items-center  w-full ">
                <div class="text-sm">
                    Doctor Comment:
                </div>
                <div class="text-sm ml-3">
                    {{ postOp.doctorComment }}
                </div>
            </div>
        </div>
    </DraggableCard>
</template>
<style lang="scss" scoped></style>