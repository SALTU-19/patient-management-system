<script>
import DraggableCard from './DraggableCard.vue';
export default {
    name: "DiseaseHistoryCard",
    components: {
        DraggableCard,
    },
    props: {
        diease: {
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
    <DraggableCard :title="diease.name" @expand="isExpanded = $event">
        <div class="flex flex-row items-center justify-between w-full mt-3">
            <div class="text-sm" v-if="isExpanded">
                {{ diease.explonation }}
            </div>
        </div>
    </DraggableCard>
</template>
<style lang="scss" scoped></style>