<script>
import DraggableCard from './DraggableCard.vue';
export default {
    name: "DiseaseHistoryCard",
    components: {
        DraggableCard,
    },
    props: {
        drug: {
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
    <DraggableCard :title="drug.name" @expand="isExpanded = $event">
        <div class="grid grid-row-2 gap-4 items-start justify-between w-full mt-3" v-if="isExpanded">
            <div class="flex flex-row items-center  w-full ">
                <div class="text-sm">
                    Starting Date:
                </div>
                <div class="text-sm ml-3">
                    {{ drug.startingDate }}
                </div>
            </div>
            <div class="flex flex-row items-center  w-full ">
                <div class="text-sm">
                    Ending Date:
                </div>
                <div class="text-sm ml-3">
                    {{ drug.endingDate }}
                </div>
            </div>
            <div class="flex flex-row items-center  w-full ">
                <div class="text-sm">
                    Doctor Comment:
                </div>
                <div class="text-sm ml-3">
                    {{ drug.doctorComment }}
                </div>
            </div>
        </div>
    </DraggableCard>
</template>
<style lang="scss" scoped></style>