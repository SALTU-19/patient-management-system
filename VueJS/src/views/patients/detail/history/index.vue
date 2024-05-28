
<script>
import ContentPanel from '@/components/layout/ContentPanel.vue';
import IconBack from '@/components/icons/IconBack.vue';
import PatientInfo from '@/components/patientInfo/index.vue';
import Card from '@/components/cards/Card.vue';
import tabBar from '@/components/blocks/tabBar.vue';
import DiseaseHistoryCard from '@/components/cards/DiseaseHistoryCard.vue';
import DrugHistoryCard from '@/components/cards/DrugHistoryCard.vue';
import SurgeryHistoryCard from '@/components/cards/SurgeryHistoryCard.vue';
import historyMenuList from '@/data/historyMenu';
import AddDiseaseHistoryModal from "@/views/patients/detail/history/diseaseHistoryModal/addModal.vue";
import AddDrugHistoryModal from "@/views/patients/detail/history/drugHistoryModal/addModal.vue";
import AddSurgeryHistoryModal from "@/views/patients/detail/history/surgeryHistoryModal/addModal.vue";
import EditDiseaseHistoryModal from "@/views/patients/detail/history/diseaseHistoryModal/editModal.vue";
import EditDrugHistoryModal from "@/views/patients/detail/history/drugHistoryModal/editModal.vue";
import EditSurgeryHistoryModal from "@/views/patients/detail/history/surgeryHistoryModal/editModal.vue";
import DeleteDiseaseHistoryModal from "@/views/patients/detail/history/diseaseHistoryModal/deleteModal.vue";
import DeleteDrugHistoryModal from "@/views/patients/detail/history/drugHistoryModal/deleteModal.vue";
import DeleteSurgeryHistoryModal from "@/views/patients/detail/history/surgeryHistoryModal/deleteModal.vue";
import { mapActions } from 'vuex';
import { AtomSpinner } from 'epic-spinners';
export default {
    name: 'PatientHistory',
    components: {
        ContentPanel,
        IconBack,
        PatientInfo,
        Card,
        tabBar,
        DiseaseHistoryCard,
        DrugHistoryCard,
        SurgeryHistoryCard,
        AddDiseaseHistoryModal,
        AddDrugHistoryModal,
        AddSurgeryHistoryModal,
        EditDiseaseHistoryModal,
        EditDrugHistoryModal,
        EditSurgeryHistoryModal,
        DeleteDiseaseHistoryModal,
        DeleteDrugHistoryModal,
        DeleteSurgeryHistoryModal,
        AtomSpinner,
    },
    props: {},
    data() {
        return {
            id: this.$route.params.id,
            title: 'HISTORY',
            selectedMenuItem: 1,
            historyMenuList: historyMenuList,
            showAddDiseaseHistoryModal: false,
            showAddDrugHistoryModal: false,
            showAddSurgeryHistoryModal: false,
            showEditDiseaseHistoryModal: false,
            showEditDrugHistoryModal: false,
            showEditSurgeryHistoryModal: false,
            showDeleteDiseaseHistoryModal: false,
            showDeleteDrugHistoryModal: false,
            showDeleteSurgeryHistoryModal: false,
            dieasesList: [
                {
                    id: 1,
                    name: 'Diabetes',
                    explonation: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 2,
                    name: 'Hypertension',
                    explonation: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 3,
                    name: 'Heart Disease',
                    explonation: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 4,
                    name: 'Lung Disease',
                    explonation: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 5,
                    name: 'Kidney Disease',
                    explonation: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                }
            ],
            drugList: [
                {
                    id: 1,
                    name: 'Majezik',
                    startingDate: '12.12.2020',
                    endingDate: '12.12.2021',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 2,
                    name: 'Insulin',
                    startingDate: '12.12.2020',
                    endingDate: '12.12.2021',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 3,
                    name: 'Insulin',
                    startingDate: '12.12.2020',
                    endingDate: '12.12.2021',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 4,
                    name: 'Insulin',
                    startingDate: '12.12.2020',
                    endingDate: '12.12.2021',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 5,
                    name: 'Insulin',
                    startingDate: '12.12.2020',
                    endingDate: '12.12.2021',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                }
            ],
            surgeryList: [
                {
                    id: 1,
                    name: 'Majezik',
                    date: '12.12.2020',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 2,
                    name: 'Insulin',
                    date: '12.12.2020',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 3,
                    name: 'Insulin',
                    date: '12.12.2020',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 4,
                    name: 'Insulin',
                    date: '12.12.2020',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                },
                {
                    id: 5,
                    name: 'Insulin',
                    date: '12.12.2020',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing el',
                }
            ],
            buttonTitle: 'Add History',
            demographicContents: {
                Age: 32,
                Sex: "Female",
                Name: "Ali",
                Surname: "Veli",
                Phone: "05555555555",
                Address: "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            },
            antropometricContents: {
                Size: "180 cm",
                Weight: "80 kg",
                BMI: "24.69",
                BodyMass: "Normal",
            },
            image: "",
            isSaving: false,
            selectedDiseaseHistory: null,
            selectedDrugHistory: null,
            selectedSurgeryHistory: null,
            isLoading: true,
            uid: "",
        }
    },
    computed: {

    },

    methods: {
        ...mapActions(['getPatient']),
        clickAddHistory() {
            console.log(this.selectedMenuItem);
            if (this.selectedMenuItem == 1) {
                this.showAddDiseaseHistoryModal = true;
            } else if (this.selectedMenuItem == 2) {
                this.showAddDrugHistoryModal = true;
            } else if (this.selectedMenuItem == 3) {
                this.showAddSurgeryHistoryModal = true;
            }
        },
        convertDateFormat(inputDateString) {
            // Create a new Date object using the input date string
            var dateObject = new Date(inputDateString);

            // Get the individual components of the date
            var day = dateObject.getUTCDate();
            var month = dateObject.getUTCMonth() + 1; // Months are zero-based, so we add 1
            var year = dateObject.getUTCFullYear();

            // Format the date components in "DD.MM.YYYY" format
            var formattedDate = `${day}.${month}.${year}`;

            return formattedDate;
        },

        checkEditDiseaseHistory(val, item) {
            if (val) {
                this.selectedDiseaseHistory = item;
                this.showEditDiseaseHistoryModal = true;
            }
        },
        checkEditDrugHistory(val, item) {
            if (val) {
                this.selectedDrugHistory = item;
                this.showEditDrugHistoryModal = true;
            }
        },
        checkEditSurgeryHistory(val, item) {
            if (val) {
                this.selectedSurgeryHistory = item;
                this.showEditSurgeryHistoryModal = true;
            }
        },
        checkDeleteDiseaseHistory(val, item) {
            if (val) {
                // this.selectedDiseaseHistory = item;
                this.uid = item.uId;
                this.showDeleteDiseaseHistoryModal = true;
            }
        },
        checkDeleteDrugHistory(val, item) {
            if (val) {
                this.uid = item.uId;
                this.showDeleteDrugHistoryModal = true;
            }
        },
        checkDeleteSurgeryHistory(val, item) {
            if (val) {
                this.uid = item.uId;
                this.showDeleteSurgeryHistoryModal = true;
            }
        },



        async _getPatient() {
            this.isLoading = true;

            const response = await this.getPatient({ uid: this.id });
            console.log(response);

            this.demographicContents.Address = response.address;
            this.demographicContents.Age = response.age;
            this.demographicContents.Name = response.name;
            this.demographicContents.Surname = response.surname;
            this.demographicContents.Phone = response.phone;
            this.demographicContents.Sex = "Male";

            this.antropometricContents.BMI = response.bmi;
            this.antropometricContents.BodyMass = response.bodyMassIndex;
            this.antropometricContents.Size = response.size.toString() + " cm";
            this.antropometricContents.Weight = response.weight.toString() + " kg";

            this.image = response.image;

            this.dieasesList = response.diseaseHistory;
            this.drugList = response.drugHistory;

            this.drugList.forEach(element => {
                element.startingDate = this.convertDateFormat(element.startingDate);
                element.endingDate = this.convertDateFormat(element.endingDate);
            });

            this.surgeryList = response.surgeryHistory;

            this.surgeryList.forEach(element => {
                element.date = this.convertDateFormat(element.date);
            });

            this.isLoading = false;
        },

    },
    async mounted() {
        this.id = this.$route.params.id;
        this.buttonTitle = '+ Add Disease History';
        await this._getPatient();

        console.log(this.id);

    },
    watch: {
        async isSaving(val) {
            if (this.isSaving) {
                await this._getPatient();
                this.isSaving = false;
            }
            // await this._getAllUsers();
        },
        selectedMenuItem: function (val) {
            if (val == 1) {
                this.buttonTitle = '+ Add Disease History';
            } else if (val == 2) {
                this.buttonTitle = '+ Add Drug History';
            } else if (val == 3) {
                this.buttonTitle = '+ Add Surgery History';
            }
        }


    },
};
</script>
<template>
    <ContentPanel>
        <template #header>
            <div class="flex flex-row items-center justify-between">
                <div class="flex items-center justify-center cursor-pointer" @click="$router.go(-1)">
                    <div class="w-8 h-8 flex items-center justify-center ">
                        <IconBack />
                    </div>
                    <div class="ml-4">Go Back</div>

                </div>
                <div class="font-semibold ml-96 ">{{ title }}</div>
            </div>
        </template>
        <template #content>
            <div v-if="isLoading" class="flex justify-center items-center h-[500px]">
                <AtomSpinner :color="'#BEEBE5'" :animation-duration="1000" />
            </div>
            <div v-if="!isLoading">
                <div class="flex flex-col gap-6">
                    <PatientInfo :antropometric-contents="antropometricContents" :demographic-contents="demographicContents"
                        :image="image" />
                    <div class="flex flex-row justify-between items-center">
                        <tabBar @selected-menu-item="selectedMenuItem = $event" :menuList="historyMenuList" />
                        <button class="bg-primary text-black rounded-2xl px-4 py-2 " @click="clickAddHistory">{{
                            buttonTitle }}</button>
                    </div>
                </div>
                <div v-if="selectedMenuItem == 1" class="flex flex-col gap-6 mt-6 overflow-y-auto"
                    style="max-height: 300px;">
                    <DiseaseHistoryCard v-for="disease in dieasesList" :key="disease.id" :diease="disease"
                        @edit="checkEditDiseaseHistory($event, disease)"
                        @delete="checkDeleteDiseaseHistory($event, disease)" />
                </div>
                <div v-if="selectedMenuItem == 2" class="flex flex-col gap-6 mt-6 overflow-y-auto"
                    style="max-height: 300px;">
                    <DrugHistoryCard v-for="drug in drugList" :key="drug.id" :drug="drug"
                        @edit="checkEditDrugHistory($event, drug)" @delete="checkDeleteDrugHistory($event, drug)" />
                </div>
                <div v-if="selectedMenuItem == 3" class="flex flex-col gap-6 mt-6 overflow-y-auto"
                    style="max-height: 300px;">
                    <SurgeryHistoryCard v-for="surgery in surgeryList" :key="surgery.id" :surgery="surgery"
                        @edit="checkEditSurgeryHistory($event, surgery)"
                        @delete="checkDeleteSurgeryHistory($event, surgery)" />
                </div>
            </div>
        </template>
    </ContentPanel>
    <AddDiseaseHistoryModal :showAddDiseaseHistoryModal="showAddDiseaseHistoryModal" :patientUID="id"
        @close-modal="showAddDiseaseHistoryModal = false" @is-saving="isSaving = $event" />
    <AddDrugHistoryModal :showAddDrugHistoryModal="showAddDrugHistoryModal" :patientUID="id"
        @close-modal="showAddDrugHistoryModal = false" @is-saving="isSaving = $event" />
    <AddSurgeryHistoryModal :showAddSurgeryHistoryModal="showAddSurgeryHistoryModal" :patientUID="id"
        @close-modal="showAddSurgeryHistoryModal = false" @is-saving="isSaving = $event" />
    <EditDiseaseHistoryModal :showEditDiseaseHistoryModal="showEditDiseaseHistoryModal"
        :selectedDiseaseHistory="selectedDiseaseHistory" @close-modal="showEditDiseaseHistoryModal = false"
        @is-saving="isSaving = $event" />
    <EditDrugHistoryModal :showEditDrugHistoryModal="showEditDrugHistoryModal" :selectedDrugHistory="selectedDrugHistory"
        @close-modal="showEditDrugHistoryModal = false" @is-saving="isSaving = $event" />
    <EditSurgeryHistoryModal :showEditSurgeryHistoryModal="showEditSurgeryHistoryModal"
        :selectedSurgeryHistory="selectedSurgeryHistory" @close-modal="showEditSurgeryHistoryModal = false"
        @is-saving="isSaving = $event" />
    <DeleteDiseaseHistoryModal :showDeleteDiseaseHistoryModal="showDeleteDiseaseHistoryModal" :uid="uid"
        @close-modal="showDeleteDiseaseHistoryModal = false" />
    <DeleteDrugHistoryModal :showDeleteDrugHistoryModal="showDeleteDrugHistoryModal" :uid="uid"
        @close-modal="showDeleteDrugHistoryModal = false" />
    <DeleteSurgeryHistoryModal :showDeleteSurgeryHistoryModal="showDeleteSurgeryHistoryModal" :uid="uid"
        @close-modal="showDeleteSurgeryHistoryModal = false" />
</template>
<style lang="scss" scoped></style>