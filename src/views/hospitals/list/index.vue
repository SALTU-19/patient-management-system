<script>
import {
    DxDataGrid,
    DxColumn,
    DxPaging,
    DxPager,
} from "devextreme-vue/data-grid";
import ContentPanel from "@/components/layout/ContentPanel.vue";
import SearchBar from "@/components/forms/SearchBar.vue";
import AddHospitalModal from "@/views/hospitals/addModal/index.vue";
import { mapActions } from "vuex";
import { AtomSpinner } from "epic-spinners";
export default {
    name: "hospital",
    components: {
        DxDataGrid,
        DxColumn,
        DxPaging,
        DxPager,
        ContentPanel,
        SearchBar,
        AddHospitalModal,
        AtomSpinner,
    },
    props: {},
    data() {
        return {
            searchTerm: "",
            showAddHospitalModal: false,
            hospitals: [
                {
                    id: 1,
                    name: "Ali",
                    city: "İstanbul",
                    district: "Kadıköy",
                    mobile: "05555555555",
                },
                {
                    id: 2,
                    name: "David",
                    city: "İstanbul",
                    district: "Kadıköy",
                    mobile: "05555555555",
                },
                {
                    id: 3,
                    name: "Cristiano",
                    city: "İstanbul",
                    district: "Kadıköy",
                    mobile: "05555555555",
                },
                {
                    id: 4,
                    name: "Lionel",
                    city: "İstanbul",
                    district: "Kadıköy",
                    mobile: "05555555555",
                },
            ],
            isSaving: false,
            filteredHospitals: [],
            isLoading: true,
        };
    },
    computed: {
        filteredItems() {
            return this.hospitals.filter(
                (item) =>
                    item.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
                    item.city.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
                    item.mobile.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
                    item.district.toLowerCase().includes(this.searchTerm.toLowerCase())
            );
        },
    },
    methods: {
        // goHospitalDetail({ selectedRowsData }) {
        //     const data = selectedRowsData[0];
        //     this.$router.push(`hospitals/${data.id}`);
        // },
        ...mapActions(["getAllHospitals"]),

        async _getAllHospitals() {
            this.isLoading = true;
            try {
                this.hospitals = await this.getAllHospitals();
                this.isLoading = false;
            } catch (error) {
                console.log(error);
            }
        },
    },
    watch: {
        async isSaving(val) {
            if (this.isSaving) {
                await this._getAllHospitals();
            }
            // await this._getAllUsers();
        },
    },
    async mounted() {
        await this._getAllHospitals();
    },
};
</script>
<template>
    <ContentPanel>
        <template #header>
            <div class="w-[1090px] flex flex-row items-center justify-between">
                <SearchBar :items="hospitals" placeholder="Search Hospital" @update:search-term="searchTerm = $event"
                    class="w-full" />
                <div class="w-[150px]">
                    <button class="bg-primary text-black text-sm rounded-2xl px-4 py-2 "
                        @click="showAddHospitalModal = true">+ Add
                        Hospital</button>
                </div>
            </div>
        </template>
        <template #content>

            <div v-if="isLoading" class="flex justify-center items-center h-[500px]">
                <AtomSpinner :color="'#BEEBE5'" :animation-duration="1000" />
            </div>
            <div v-if="!isLoading" class="table-responsive">
                <DxDataGrid :data-source="filteredItems" class="clickable-row" :selection="{ mode: 'single' }">
                    <DxColumn data-field="name" alignment="center"></DxColumn>
                    <DxColumn data-field="city" alignment="center"></DxColumn>
                    <DxColumn data-field="mobile" alignment="center"></DxColumn>
                    <DxColumn data-field="district" alignment="center"></DxColumn>
                </DxDataGrid>
            </div>

        </template>
    </ContentPanel>
    <AddHospitalModal :showAddHospitalModal="showAddHospitalModal" @close-modal="showAddHospitalModal = false"
        @is-saving="isSaving = $event" />
</template>
<style lang="scss" scoped></style>
