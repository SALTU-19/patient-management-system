<template>
    <div class="search-bar-container">
        <div class="flex flex-row  justify-between">
            <input type="text" v-model="searchTerm" @input="updateSearch" :placeholder="placeholder" />
            <div class="flex flex-row  justify-between">
                <IconFilter class="w-6 h-6" />
                <IconSearch class="w-6 h-6 ml-1" />
            </div>
        </div>
    </div>
</template>
  
<script>
import IconSearch from "@/components/icons/IconSearch.vue";
import IconFilter from "@/components/icons/IconFilter.vue";
export default {
    data() {
        return {
            searchTerm: "",
        };
    },
    components: {
        IconSearch,
        IconFilter,
    },
    methods: {
        updateSearch() {
            this.$emit("update:searchTerm", this.searchTerm);
        },
    },
    props: {
        items: {
            type: Array,
            required: true,
        },
        placeholder: {
            type: String,
            default: "Search...",
        },
    },
    emits: ["update:searchTerm"],
};
</script>
  
<style lang="scss" scoped>
.search-bar-container {

    /* Add styling for the container here */
    margin: 10px;
    /* Adjust as needed */
    padding: 10px;
    /* Adjust as needed */
    border: 2px solid #ccc;
    /* Add border styling as needed */
    border-radius: 30px;
    /* Add border-radius as needed */
}
</style>
  