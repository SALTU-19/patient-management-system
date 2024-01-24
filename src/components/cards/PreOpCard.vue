<script>
import DraggableCard from './DraggableCard.vue';
export default {
    name: "PreOpCard",
    components: {
        DraggableCard,
    },
    props: {
        preOp: {
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
    <DraggableCard :title="preOp.surgeryDate" @expand="isExpanded = $event">
        <div class="grid grid-row-2 gap-4 items-start justify-between w-full mt-3" v-if="isExpanded">
            <div class="flex flex-row items-center  w-full ">
                <div class="text-sm">
                    Doctor Name:
                </div>
                <div class="text-sm ml-3">
                    {{ preOp.doctorName }}
                </div>
            </div>
            <div class="flex flex-row items-center  w-full ">
                <div class="text-sm">
                    Type Of Surgery:
                </div>
                <div class="text-sm ml-3">
                    {{ preOp.surgeryType }}
                </div>
            </div>
            <div class="flex flex-row items-center  w-full ">
                <div class="text-sm">
                    Patient Name:
                </div>
                <div class="text-sm ml-3">
                    {{ preOp.patientName }}
                </div>
            </div>
        </div>
    </DraggableCard>
</template>
<style lang="scss" scoped></style>