<script>
import DraggableCard from './DraggableCard.vue';
export default {
    name: "PeriodicVisitHistoryCard",
    components: {
        DraggableCard,
    },
    props: {
        periodicVisit: {
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
    <DraggableCard :title="periodicVisit.month" @expand="isExpanded = $event">
        <div class="grid grid-row-2 gap-4 items-start justify-between w-full mt-3" v-if="isExpanded">
            <div class="flex flex-row items-center  w-full ">
                <div class="text-sm">
                    Date:
                </div>
                <div class="text-sm ml-3">
                    {{ periodicVisit.date }}
                </div>
            </div>
            <div class="flex flex-row items-center  w-full ">
                <div class="text-sm">
                    Status:
                </div>
                <div class="text-sm ml-3">
                    {{ periodicVisit.status }}
                </div>
            </div>
        </div>
    </DraggableCard>
</template>
<style lang="scss" scoped></style>